using IronMaidenRegistry.DTOs.Instrument;

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

    public Task<ServiceResponse<InstrumentResult>> AddInstrumentAsync(InstrumentInput newInstrument)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<List<InstrumentResult>>> GetAllInstrumentsAsync()
    {
        var serviceResponse = new ServiceResponse<List<InstrumentResult>>();

        try
        {
            var instruments = await _dbContext
                .Database
                .SqlQueryRaw<InstrumentResult>("""
                                                SELECT InstrumentId AS Id,
                                                       InstrumentName AS Name
                                                FROM Instruments;                    
                                                """)
                                                .AsNoTracking()
                                                .ToListAsync();
                                            
            if(instruments is null)
                throw new Exception($"Instruments list is empty!");

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

            if(instrument is null)
                throw new Exception($"Instrument with id {id} not found!");

            serviceResponse.Data = instrument;
        }

        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public Task RemoveInstrumentAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<InstrumentResult>> UpdateInstrumentAsync(Guid id, InstrumentInput newInstrument)
    {
        throw new NotImplementedException();
    }
}