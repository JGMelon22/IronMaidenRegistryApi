using IronMaidenRegistry.DTOs.Song;

namespace IronMaidenRegistry.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SongsController : ControllerBase
{
    private readonly ISongRepository _repository;

    public SongsController(ISongRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSongsAsync()
    {
        var songs = await _repository.GetAllSongsAsync();
        return songs.Data != null
            ? Ok(songs)
            : NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSongByIdAsync(Guid id)
    {
        var song = await _repository.GetSongByIdAsync(id);
        return song.Data != null
            ? Ok(song)
            : NotFound(song);
    }

    [HttpPost]
    public async Task<IActionResult> AddSongAsync(SongInput newSong)
    {
        var song = await _repository.AddSongAsync(newSong);
        return song.Data != null
            ? Ok(song)
            : NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateSongAsync(Guid id, SongInput updatedSong)
    {
        var song = await _repository.UpdateSongAsync(id, updatedSong);
        return song.Data != null
            ? Ok(song)
            : BadRequest(song);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveSongAsync(Guid id)
    {
        var song = await _repository.RemoveSongAsync(id);
        return song.Success
            ? NoContent()
            : NotFound(song);
    }
}