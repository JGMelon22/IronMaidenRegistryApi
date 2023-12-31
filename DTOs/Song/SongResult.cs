namespace IronMaidenRegistry.DTOs.Song;

public record SongResult
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public byte DurationInMinutes { get; init; }
    public byte AverageScore { get; init; }
}