using IronMaidenRegistry.DTOs.Instrument;

namespace IronMaidenRegistry.Infrastructure.Repositories;

public class InstrumentRepository : IInstrumentRepository
{
    private readonly AppDbContext _dbContext;

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

    public InstrumentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ServiceResponse<InstrumentResult>> AddInstrumentAsync(InstrumentInput newInstrument)
    {
        var serviceResponse = new ServiceResponse<InstrumentResult>();

        try
        {
            var instrument = new Instrument
            {
                Name = newInstrument.Name
            };

            await _dbContext.SaveChangesAsync();

            var instrumentResult = new InstrumentResult
            {
                Id = instrument.Id,
                Name = instrument.Name
            };

            serviceResponse.Data = instrumentResult;
        }

        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
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

            if (instruments is null)
                throw new Exception("Instruments list is empty!");

            var instrumentsMapped = new List<InstrumentResult>();

            foreach (var instrument in instruments)
            {
                var instrumentResult = new InstrumentResult
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

            if (instrument is null)
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

    public async Task<ServiceResponse<bool>> RemoveInstrumentAsync(Guid id)
    {
        var serviceResponse = new ServiceResponse<bool>();

        try
        {
            var instrument = await _dbContext.Instruments.FindAsync(id);

            if (instrument is null)
                throw new Exception($"Instrument with id {id} not found!");

            _dbContext.Remove(instrument);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<InstrumentResult>> UpdateInstrumentAsync(Guid id,
        InstrumentInput updatedInstrument)
    {
        var serviceResponse = new ServiceResponse<InstrumentResult>();

        try
        {
            var instrument = await _dbContext.Instruments.FindAsync(id);

            if (instrument is null)
                throw new Exception($"Instrument with id {id} not found!");

            instrument.Name = updatedInstrument.Name;

            await _dbContext.SaveChangesAsync();

            var instrumentResult = new InstrumentResult
            {
                Id = instrument.Id,
                Name = instrument.Name
            };

            serviceResponse.Data = instrumentResult;
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }
}