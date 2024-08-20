using AutoMapper;
using EatsyAPI.Data;
using EatsyAPI.Data.Dtos;
using EatsyAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace EatsyAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RequestController : ControllerBase
{
    private EatsyContext _context;
    private IMapper _mapper;

    public RequestController(EatsyContext eatsyContext, IMapper mapper)
    {
        _context = eatsyContext;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ReadRequestDto> GetAllRequest()
    {
        return _mapper.Map<List<ReadRequestDto>>(_context.Requests.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetRequestById(Guid id)
    {
        var request = _context.Requests.FirstOrDefault(f => f.Id == id);
        if (request == null)
        {
            var requestDto = _mapper.Map<ReadRequestDto>(request);
            return Ok(requestDto);
        }

        return NotFound();
    }

    [HttpPost]
    public IActionResult SaveRequest([FromBody] CreateRequestDto dto)
    {
        Request request = _mapper.Map<Request>(dto);
        _context.Requests.Add(request);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetRequestById), new { Id = request.Id }, dto);
    }
}
