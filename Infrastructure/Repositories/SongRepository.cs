using IronMaidenRegistry.DTOs.Song;

namespace IronMaidenRegistry.Infrastructure.Repositories;

public class SongRepository : ISongRepository
{
    private readonly Func<AppDbContext, Guid, Task<SongResult?>> GetById =
        EF.CompileAsyncQuery((AppDbContext context, Guid id) =>
            context.Songs.Select(s => new SongResult
            {
                Id = s.Id,
                Name = s.Name,
                DurationInMinutes = s.DurationInMinutes,
                AverageScore = s.AverageScore
            })
            .AsNoTracking()
            .FirstOrDefault(s => s.Id == id));

    private readonly AppDbContext _dbContext;

    public SongRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ServiceResponse<SongResult>> AddSongAsync(SongInput newSong)
    {
        var serviceResponse = new ServiceResponse<SongResult>();

        try
        {
            var song = new Song
            {
                Name = newSong.Name,
                DurationInMinutes = newSong.DurationInMinutes,
                AverageScore = newSong.AverageScore,
                MembersSongs = newSong.MembersSongs.Select(memberSongInput => new MemberSong
                {
                    MemberId = memberSongInput.MemberId
                }).ToList()
            };

            await _dbContext.Songs.AddAsync(song);
            await _dbContext.SaveChangesAsync();

            var songResult = new SongResult()
            {
                Id = song.Id,
                Name = song.Name,
                DurationInMinutes = song.DurationInMinutes,
                AverageScore = song.AverageScore
            };

            serviceResponse.Data = songResult;
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<SongResult>>> GetAllSongsAsync()
    {
        var serviceResponse = new ServiceResponse<List<SongResult>>();

        try
        {
            var songs = await _dbContext
                .Database
                .SqlQueryRaw<SongResult>(""" 
                                          SELECT SongId AS Id,
                                                 SongName AS Name,
                                                 DurationInMinutes AS DurationInMinutes,
                                                 AverageScore AS AverageScore
                                          FROM Songs;
                                          """)
                                         .AsNoTracking()
                                         .ToListAsync();

            if (songs is null)
                throw new Exception("Song list is empty!");

            var songMapped = new List<SongResult>();

            foreach (var song in songs)
            {
                var songResult = new SongResult()
                {
                    Id = song.Id,
                    Name = song.Name,
                    DurationInMinutes = song.DurationInMinutes,
                    AverageScore = song.AverageScore
                };

                songMapped.Add(songResult);
            }

            serviceResponse.Data = songMapped;

        }

        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<SongResult>> GetSongByIdAsync(Guid id)
    {
        var serviceResponse = new ServiceResponse<SongResult>();

        try
        {
            var song = await GetById(_dbContext, id);

            if (song is null)
                throw new Exception($"Song with id {id} not found!");

            serviceResponse.Data = song;
        }

        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }
}