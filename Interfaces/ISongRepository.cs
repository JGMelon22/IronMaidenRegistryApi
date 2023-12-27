using IronMaidenRegistry.DTOs.Song;

namespace IronMaidenRegistry.Interfaces;

public interface ISongRepository
{
    Task<ServiceResponse<List<SongResult>>> GetAllSongsAsync();
    Task<ServiceResponse<SongResult>> GetSongByIdAsync(Guid id);
    Task<ServiceResponse<SongResult>> AddSongAsync(SongInput newSong);
}