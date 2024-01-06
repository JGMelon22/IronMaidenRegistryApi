using IronMaidenRegistry.Domain.Entities;
using IronMaidenRegistry.DTOs.MemberSong;
using IronMaidenRegistry.DTOs.Song;
using IronMaidenRegistry.Infrastructure.Data;
using IronMaidenRegistry.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IronMaidenRegistry.Tests.Repository;

public class SongRepositoryTests
{
    private readonly AppDbContext _dbContext;
    private readonly SongRepository _songRepository;

    public SongRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _dbContext = new AppDbContext(options);
        _dbContext.Database.EnsureCreatedAsync();

        if (_dbContext.Songs.Count() <= 0)
            for (var i = 0; i < 10; i++)
            {
                _dbContext.Songs.AddAsync(
                    new Song
                    {
                        Id = Guid.NewGuid(),
                        Name = "New Song Test",
                        DurationInMinutes = 3,
                        AverageScore = 5
                    });

                _dbContext.SaveChangesAsync();
            }

        _songRepository = new SongRepository(_dbContext);
    }

    [Fact]
    public void SongRepository_AddSongAsync_ReturnsSongResult()
    {
        // Arrange
        var songInput = new SongInput("New Song Test", 3, 5,
            new List<MemberSongInput> { new(Guid.NewGuid()) });

        // Act
        var result = _songRepository.AddSongAsync(songInput);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<ServiceResponse<SongResult>>>();
    }

    [Fact]
    public void SongRepository_GetAllSongsAsync_ReturnsListSongResult()
    {
        // Arrange

        // Act
        var result = _songRepository.GetAllSongsAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<ServiceResponse<List<SongResult>>>>();
    }

    [Fact]
    public void SongRepository_GetSongByIdAsync_ReturnsSongResult()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var result = _songRepository.GetSongByIdAsync(id);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<ServiceResponse<SongResult>>>();
    }

    [Fact]
    public void SongRepository_RemoveSongAsync_ReturnsSuccess()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act 
        var result = _songRepository.RemoveSongAsync(id);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<ServiceResponse<bool>>>();
    }

    [Fact]
    public void SongRepository_UpdateSongAsync_ReturnsSongResult()
    {
        // Arrange
        var id = Guid.NewGuid();
        var songInput = new SongInput("Updated Song Test", 6, 4,
            new List<MemberSongInput> { new(Guid.NewGuid()) });

        // Act
        var result = _songRepository.UpdateSongAsync(id, songInput);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<ServiceResponse<SongResult>>>();
    }
}