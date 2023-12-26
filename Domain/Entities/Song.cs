namespace IronMaidenRegistry.Domain.Entities;

public class Song
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public byte DurationInMinutes { get; set; }
    public byte AverageScore { get; set; }
    public List<MemberSong>? MembersSongs { get; set; }
}