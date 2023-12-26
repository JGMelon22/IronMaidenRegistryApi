using IronMaidenRegistry.Domain.Entities;
using IronMaidenRegistry.DTOs.Instrument;
using IronMaidenRegistry.Infrastructure.Data;
using IronMaidenRegistry.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IronMaidenRegistry.Infrastructure.Repositories;

public class InstrumentRepository : IInstrumentRepository
{
    private readonly Func<AppDbContext, Guid, Task<InstrumentResult?>> GetById =
        EF.CompileAsyncQuery((AppDbContext context, Guid id) =>

            context.Instruments
                .Select(i => new InstrumentResult
                {
                    Id = i.Id,
                    Name = i.Name
                })
                .AsNoTracking()
                .FirstOrDefault(i => i.Id == id));

    private readonly AppDbContext _dbContext;

    public InstrumentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ServiceResponse<List<InstrumentResult>>> GetAllInstrumentsAsync()
    {
        var serviceResponse = new ServiceResponse<List<InstrumentResult>>();

        try
        {
            var instruments = _dbContext
                .Database
                .SqlQueryRaw<InstrumentResult>("""
                                                SELECT InstrumentId AS Id,
                                                       InstrumentName AS Name
                                                FROM Instruments;                    
                                                """)
                                                .AsNoTracking()
                                                .ToList();

            var instrumentsMapped = new List<InstrumentResult>();

            foreach (var instrument in instruments)
            {
                var instrumentResult = new InstrumentResult()
                {
                    Id = instrument.Id,
                    Name = instrument.Name
                };

                instrumentsMapped.Add(instrumentResult);
            }

            serviceResponse.Data = instrumentsMapped;
        }

        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;

    }

    public async Task<ServiceResponse<InstrumentResult>> GetInstrumentByIdAsync(Guid id)
    {
        var serviceResponse = new ServiceResponse<InstrumentResult>();
        try
        {
            var instrument = await GetById(_dbContext, id);
            serviceResponse.Data = instrument;
        }

        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }
}