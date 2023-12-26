using IronMaidenRegistry.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IronMaidenRegistry.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Instrument> Instruments { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<MemberSong> MembersSongs { get; set; }

}