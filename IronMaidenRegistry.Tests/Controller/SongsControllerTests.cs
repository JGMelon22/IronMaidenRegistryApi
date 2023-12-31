using IronMaidenRegistry.Controllers;
using IronMaidenRegistry.Domain.Entities;
using IronMaidenRegistry.DTOs.Song;
using IronMaidenRegistry.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IronMaidenRegistry.Tests.Controller;

public class SongsControllerTests
{
    private readonly ISongRepository _songRepository;
    private readonly SongsController _songsController;

    public SongsControllerTests()
    {
        _songRepository = A.Fake<ISongRepository>();

        // SUT
        _songsController = new SongsController(_songRepository);
    }

    [Fact]
    public void SongsController_GetAllSongsAsync_ReturnsSongs()
    {
        // Arrange
        var songs = A.Fake<ServiceResponse<List<SongResult>>>();
        A.CallTo(() => _songRepository.GetAllSongsAsync()).Returns(songs);

        // Act
        var result = _songsController.GetAllSongsAsync();

        // Assert
        result.Should().BeOfType<Task<IActionResult>>();
    }

    [Fact]
    public void SongsController_GetSongByIdAsync_ReturnsSongs()
    {
        // Arrange
        var id = Guid.NewGuid();
        var songResult = A.Fake<ServiceResponse<SongResult>>();
        A.CallTo(() => _songRepository.GetSongByIdAsync(id)).Returns(songResult);

        // Act
        var result = _songsController.GetSongByIdAsync(id);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<IActionResult>>();
    }

    [Fact]
    public void SongsController_AddSongAsync_ReturnsSong()
    {
        // Arrange
        var newSong = A.Fake<SongInput>();
        var songResult = A.Fake<ServiceResponse<SongResult>>();
        A.CallTo(() => _songRepository.AddSongAsync(newSong)).Returns(songResult);

        // Act 
        var result = _songsController.AddSongAsync(newSong);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<IActionResult>>();
    }

    [Fact]
    public void SongsController_UpdateSongAsync_ReturnsSong()
    {
        // Arrange
        var id = Guid.NewGuid();
        var updatedSong = A.Fake<SongInput>();
        var songResult = A.Fake<ServiceResponse<SongResult>>();
        A.CallTo(() => _songRepository.UpdateSongAsync(id, updatedSong)).Returns(songResult);

        // Act
        var result = _songsController.UpdateSongAsync(id, updatedSong);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<IActionResult>>();
    }

    [Fact]
    public void SongsController_RemoveSongAsync_ReturnsSuccess()
    {
        // Arrange
        var id = Guid.NewGuid();
        var success = A.Fake<ServiceResponse<bool>>();
        A.CallTo(() => _songRepository.RemoveSongAsync(id)).Returns(success);

        // Act
        var result = _songsController.RemoveSongAsync(id);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<IActionResult>>();
    }
}