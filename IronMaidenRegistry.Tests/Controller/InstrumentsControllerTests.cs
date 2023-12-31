using FakeItEasy;
using FluentAssertions;
using IronMaidenRegistry.Controllers;
using IronMaidenRegistry.Domain.Entities;
using IronMaidenRegistry.DTOs.Instrument;
using IronMaidenRegistry.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IronMaidenRegistry.Tests.Controller;

public class InstrumentsControllerTests
{
    private readonly InstrumentsController _instrumentsController;
    private readonly IInstrumentRepository _instrumentRepository;

    public InstrumentsControllerTests()
    {
        _instrumentRepository = A.Fake<IInstrumentRepository>();

        // SUT
        _instrumentsController = new InstrumentsController(_instrumentRepository);
    }

    [Fact]
    public void InstrumentsController_GetAllInstrumentsAsync_ReturnsInstruments()
    {
        // Arrange
        var instruments = A.Fake<ServiceResponse<List<InstrumentResult>>>();
        A.CallTo(() => _instrumentRepository.GetAllInstrumentsAsync()).Returns(instruments);

        // Act
        var result = _instrumentsController.GetAllInstrumentsAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<IActionResult>>();
    }

    [Fact]
    public void InstrumentsController_GetInstrumentByIdAsync_ReturnsInstrument()
    {
        // Arrange
        Guid id = Guid.NewGuid();
        var instrument = A.Fake<ServiceResponse<InstrumentResult>>();
        A.CallTo(() => _instrumentRepository.GetInstrumentByIdAsync(id)).Returns(instrument);

        // Act 
        var result = _instrumentsController.GetInstrumentByIdAsync(id);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<IActionResult>>();
    }

    [Fact]
    public void InstrumentsController_AddInstrumentAsync_ReturnsInstrument()
    {
        // Arrange 
        var newInstrument = A.Fake<InstrumentInput>();
        var instrumentResult = A.Fake<ServiceResponse<InstrumentResult>>();
        A.CallTo(() => _instrumentRepository.AddInstrumentAsync(newInstrument)).Returns(instrumentResult);

        // Act
        var result = _instrumentsController.AddInstrumentAsync(newInstrument);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<IActionResult>>();
    }

    [Fact]
    public void InstrumentsController_UpdateInstrumentAsync_ReturnsInstrument()
    {
        // Arrange
        Guid id = Guid.NewGuid();
        var updatedInstrument = A.Fake<InstrumentInput>();
        var instrumentResult = A.Fake<ServiceResponse<InstrumentResult>>();
        A.CallTo(() => _instrumentRepository.UpdateInstrumentAsync(id, updatedInstrument)).Returns(instrumentResult);

        // Act
        var result = _instrumentsController.UpdateInstrumentAsync(id, updatedInstrument);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<IActionResult>>();
    }

    [Fact]
    public void InstrumentsController_RemoveInstrumentAsync_ReturnsSuccess()
    {
        // Arrange
        Guid id = Guid.NewGuid();
        var success = A.Fake<ServiceResponse<bool>>();
        A.CallTo(() => _instrumentRepository.RemoveInstrumentAsync(id)).Returns(success);

        // Act
        var result = _instrumentsController.RemoveInstrumentAsync(id);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<IActionResult>>();
    }
}