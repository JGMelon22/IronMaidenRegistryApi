namespace IronMaidenRegistry.DTOs.Member;

public record MemberResult
{
    public Guid Id { get; init; }
    public string FullName { get; init; } = null!;
    public DateOnly BirthDate { get; init; }
}
