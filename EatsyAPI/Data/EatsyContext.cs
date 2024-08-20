using EatsyAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EatsyAPI.Data;

public class EatsyContext : DbContext
{
    public EatsyContext(DbContextOptions<EatsyContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<FoodRequest>()
        .Property(fc => fc.Id)
        .ValueGeneratedOnAdd();

        builder.Entity<FoodCategory>()
        .HasMany(e => e.Foods)
        .WithOne(e => e.FoodCategory)
        .HasForeignKey(e => e.FoodCategoryId)
        .IsRequired();

        builder.Entity<Request>()
            .HasMany(r => r.FoodRequests)
            .WithOne(r => r.Request)
            .HasForeignKey(r => r.RequestId)
            .IsRequired();
    }

    public DbSet<FoodCategory> FoodCategorys { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<FoodRequest> FoodRequests { get; set; }

}
