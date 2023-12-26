namespace IronMaidenRegistry.Domain.Entities;

public class Member
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public Guid InstrumentId { get; set; }
    public Instrument? Instrument { get; set; }
    public List<MemberSong>? MembersSongs { get; set; }
}