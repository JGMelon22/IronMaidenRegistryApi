using IronMaidenRegistry.DTOs.Instrument;

namespace IronMaidenRegistry.Interfaces;

public interface IInstrumentRepository
{
    Task<ServiceResponse<List<InstrumentResult>>> GetAllInstrumentsAsync();
    Task<ServiceResponse<InstrumentResult>> GetInstrumentByIdAsync(Guid id);
    Task<ServiceResponse<InstrumentResult>> AddInstrumentAsync(InstrumentInput newInstrument);
    Task<ServiceResponse<InstrumentResult>> UpdateInstrumentAsync(Guid id, InstrumentInput updatedInstrument);
    Task RemoveInstrumentAsync(Guid id);
}