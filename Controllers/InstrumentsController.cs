using IronMaidenRegistry.DTOs.Instrument;

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

    [HttpPost]
    public async Task<IActionResult> AddInstrumentAsync(InstrumentInput newInstrument)
    {
        var instrument = await _repository.AddInstrumentAsync(newInstrument);
        return instrument.Data != null
            ? Ok(instrument)
            : BadRequest(instrument);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateInstrumentAsync(Guid id, InstrumentInput updatedInstrument)
    {
        var instrument = await _repository.UpdateInstrumentAsync(id, updatedInstrument);
        return instrument.Data != null
            ? Ok(instrument)
            : BadRequest(instrument);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveInstrumentAsync(Guid id)
    {
        var instrument = await _repository.RemoveInstrumentAsync(id);
        return instrument.Success != false
            ? NoContent()
            : BadRequest(instrument);
    }
}