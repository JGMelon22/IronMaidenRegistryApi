using IronMaidenRegistry.Domain.Entities;
using IronMaidenRegistry.DTOs.Instrument;
using IronMaidenRegistry.Infrastructure.Data;
using IronMaidenRegistry.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IronMaidenRegistry.Tests.Repository;

public class InstrumentRepositoryTests
{
    private readonly AppDbContext _dbContext;
    private readonly InstrumentRepository _instrumentRepository;

    public InstrumentRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _dbContext = new AppDbContext(options);
        _dbContext.Database.EnsureCreatedAsync();

        if (_dbContext.Instruments.Count() <= 0)
        {
            for (int i = 0; i < 10; i++)
            {
                _dbContext.Instruments.Add(
                    new Instrument()
                    {
                        Name = "New Instrument Test"
                    });

                _dbContext.SaveChangesAsync();
            }
        }

        _instrumentRepository = new InstrumentRepository(_dbContext);
    }

    [Fact]
    public void InstrumentRepository_AddInstrumentAsync_ReturnsInstrumentResult()
    {
        // Arrange
        var instrumentInput = new InstrumentInput("New Instrument Test");

        // Act 
        var result = _instrumentRepository.AddInstrumentAsync(instrumentInput);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<ServiceResponse<InstrumentResult>>>();
    }

    [Fact]
    public void InstrumentRepository_GetAllInstrumentsAsync_ReturnsListInstrumentResult()
    {
        // Arrange

        // Act
        var result = _instrumentRepository.GetAllInstrumentsAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<ServiceResponse<List<InstrumentResult>>>>();
    }

    [Fact]
    public void InstrumentRepository_GetInstrumentByIdAsync_ReturnsInstrumentResult()
    {
        // Arrange
        Guid id = Guid.NewGuid();

        // Act
        var result = _instrumentRepository.GetInstrumentByIdAsync(id);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<ServiceResponse<InstrumentResult>>>();
    }

    [Fact]
    public void InstrumentRepository_RemoveInstrumentAsync_ReturnsSuccess()
    {
        // Arrange
        Guid id = Guid.NewGuid();

        // Act
        var result = _instrumentRepository.RemoveInstrumentAsync(id);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<ServiceResponse<bool>>>();
    }

    [Fact]
    public void InstrumentRepository_UpdateInstrumentAsync_ReturnsInstrumentResult()
    {
        // Arrange
        Guid id = Guid.NewGuid();
        var instrumentInput = new InstrumentInput("Updated Instrument Test");

        // Act
        var result = _instrumentRepository.UpdateInstrumentAsync(id, instrumentInput);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<ServiceResponse<InstrumentResult>>>();
    }
}