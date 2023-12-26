namespace IronMaidenRegistry.DTOs.Instrument;

public record InstrumentResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}
