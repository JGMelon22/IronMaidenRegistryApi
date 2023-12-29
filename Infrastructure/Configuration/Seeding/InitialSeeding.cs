namespace IronMaidenRegistry.Infrastructure.Configuration.Seeding;

public static class InitialSeeding
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Instrument
        Instrument bass = new Instrument()
        {
            Id = Guid.NewGuid(),
            Name = "Bass"
        };

        Instrument drum = new Instrument()
        {
            Id = Guid.NewGuid(),
            Name = "Drum"
        };

        Instrument guitar = new Instrument()
        {
            Id = Guid.NewGuid(),
            Name = "Guitar"
        };

        Instrument keyboard = new Instrument()
        {
            Id = Guid.NewGuid(),
            Name = "Keyboard"
        };

        Instrument vocals = new Instrument()
        {
            Id = Guid.NewGuid(),
            Name = "Vocals"
        };

        // Member
        Member adrian = new Member()
        {
            Id = Guid.NewGuid(),
            FullName = "Adrian Smith",
            BirthDate = new DateOnly(1957, 02, 27),
            InstrumentId = guitar.Id
        };

        Member blaze = new Member()
        {
            Id = Guid.NewGuid(),
            FullName = "Blaze Bayley",
            BirthDate = new DateOnly(1963, 05, 29),
            InstrumentId = vocals.Id
        };

        Member bruce = new Member()
        {
            Id = Guid.NewGuid(),
            FullName = "Bruce Dickson",
            BirthDate = new DateOnly(1958, 08, 07),
            InstrumentId = vocals.Id
        };

        Member clive = new Member()
        {
            Id = Guid.NewGuid(),
            FullName = "Clive Burr",
            BirthDate = new DateOnly(1957, 03, 07),
            InstrumentId = drum.Id
        };

        Member dave = new Member()
        {
            Id = Guid.NewGuid(),
            FullName = "Dave Murray",
            BirthDate = new DateOnly(1956, 12, 23),
            InstrumentId = guitar.Id
        };

        Member denis = new Member()
        {
            Id = Guid.NewGuid(),
            FullName = "Denis Stratton",
            BirthDate = new DateOnly(1952, 09, 27),
            InstrumentId = guitar.Id
        };

        Member janick = new Member()
        {
            Id = Guid.NewGuid(),
            FullName = "Janick Gers",
            BirthDate = new DateOnly(1957, 01, 27),
            InstrumentId = guitar.Id
        };

        Member nicko = new Member()
        {
            Id = Guid.NewGuid(),
            FullName = "Nicko McBrain",
            BirthDate = new DateOnly(1952, 06, 05),
            InstrumentId = drum.Id
        };

        Member paul = new Member()
        {
            Id = Guid.NewGuid(),
            FullName = "Paul Di'Anno",
            BirthDate = new DateOnly(1958, 05, 17),
            InstrumentId = vocals.Id
        };

        Member steve = new Member()
        {
            Id = Guid.NewGuid(),
            FullName = "Steve Harris",
            BirthDate = new DateOnly(1956, 03, 12),
            InstrumentId = bass.Id
        };

        // Song
        Song forTheGreaterGoodOfGod = new Song()
        {
            Id = Guid.NewGuid(),
            Name = "For the Greater Good of God",
            DurationInMinutes = 9,
            AverageScore = 4
        };

        Song fearOfTheDark = new Song()
        {
            Id = Guid.NewGuid(),
            Name = "Fear of the Dark",
            DurationInMinutes = 7,
            AverageScore = 4
        };

        Song prowler = new Song()
        {
            Id = Guid.NewGuid(),
            Name = "Prowler",
            DurationInMinutes = 4,
            AverageScore = 5
        };

        Song theTrooper = new Song()
        {
            Id = Guid.NewGuid(),
            Name = "The Trooper",
            DurationInMinutes = 4,
            AverageScore = 5
        };

        // // MemberSong
        MemberSong bruceFearOfTheDark = new MemberSong()
        {
            MemberId = bruce.Id,
            SongId = fearOfTheDark.Id
        };

        modelBuilder.Entity<Instrument>()
            .HasData(bass, drum, guitar, keyboard, vocals);

        modelBuilder.Entity<Member>()
            .HasData(adrian, blaze, bruce, clive, dave, denis, janick, nicko, paul, steve);

        modelBuilder.Entity<Song>()
            .HasData(forTheGreaterGoodOfGod, fearOfTheDark, prowler, theTrooper);

        modelBuilder.Entity<MemberSong>()
            .HasData(bruceFearOfTheDark);
    }
}