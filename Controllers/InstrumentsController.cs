using IronMaidenRegistry.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IronMaidenRegistry.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstrumentsController : ControllerBase
{
    private readonly IInstrumentRepository _repository;
    public InstrumentsController(IInstrumentRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllInstrumentsAsync()
    {
        var instruments = await _repository.GetAllInstrumentsAsync();
        return instruments.Data != null
            ? Ok(instruments)
            : NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInstrumentByIdAsync(Guid id)
    {
        var instrument = await _repository.GetInstrumentByIdAsync(id);
        return instrument.Data != null
            ? Ok(instrument)
            : NotFound(instrument);
    }
}