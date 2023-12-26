namespace IronMaidenRegistry.Domain.Entities;

public class Instrument
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Member>? Members { get; set; }
}