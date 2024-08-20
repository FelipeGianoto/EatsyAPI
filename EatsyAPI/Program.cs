using EatsyAPI.Data;
using EatsyAPI.Extensions;
using EatsyAPI.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//MYSQL
var connectionString = builder.Configuration.GetConnectionString("MysqlDatabase");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("A connection string named 'MysqlDatabase' is not configured.");
}
builder.Services.AddDbContext<EatsyContext>(options => options.UseMySQL(connectionString));

//REDIS
builder.Services.AddStackExchangeRedisCache(options => options.Configuration = builder.Configuration.GetConnectionString("RedisCache"));

// Configurar AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Registro dos repositórios e serviços
FoodModule.RegisterServices(builder.Services);

// Configurar controllers e JSON
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
});

// Configurar comportamentos de API
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(x => x.Value!.Errors.Count > 0)
            .Select(x => new
            {
                Field = x.Key,
                Messages = x.Value!.Errors.Select(e => e.ErrorMessage)
            })
            .ToDictionary(x => x.Field, x => x.Messages);

        return new BadRequestObjectResult(new { errors });
    };
});

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline de solicitações HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

// app.UseHttpsRedirection(); // Descomente se HTTPS for necessário
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
