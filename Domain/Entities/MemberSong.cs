namespace IronMaidenRegistry.Domain.Entities;

public class MemberSong
{
    public Guid MemberId { get; set; }
    public Member Member { get; set; } = null!;
    public Guid SongId { get; set; }
    public Song Song { get; set; } = null!;
}