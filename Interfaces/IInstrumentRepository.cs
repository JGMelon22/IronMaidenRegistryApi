using IronMaidenRegistry.Domain.Entities;
using IronMaidenRegistry.DTOs.Instrument;

namespace IronMaidenRegistry.Interfaces;

public interface IInstrumentRepository
{
    Task<ServiceResponse<List<InstrumentResult>>> GetAllInstrumentsAsync();
    Task<ServiceResponse<InstrumentResult>> GetInstrumentByIdAsync(Guid id);
}