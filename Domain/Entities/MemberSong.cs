namespace IronMaidenRegistry.Domain.Entities;

public class MemberSong
{
    public Guid MemberId { get; set; }
    public Member Member { get; set; } = null!;
    public List<MemberSong>? MembersSongs { get; set; }
}