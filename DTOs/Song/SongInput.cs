using IronMaidenRegistry.DTOs.MemberSong;

namespace IronMaidenRegistry.DTOs.Song;

public record SongInput(
    string Name,
    byte DurationInMinutes,
    byte AverageScore,
    List<MemberSongInput> MembersSongs
);
