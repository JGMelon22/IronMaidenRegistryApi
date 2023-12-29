using IronMaidenRegistry.Infrastructure.Configuration;
using IronMaidenRegistry.Infrastructure.Configuration.Seeding;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new InstrumentConfiguration());
        modelBuilder.ApplyConfiguration(new MemberConfiguration());
        modelBuilder.ApplyConfiguration(new MemberSongConfiguration());
        modelBuilder.ApplyConfiguration(new SongConfiguration());

        InitialSeeding.Seed(modelBuilder);
    }
}