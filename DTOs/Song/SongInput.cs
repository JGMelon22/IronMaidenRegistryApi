using System.ComponentModel.DataAnnotations;
using IronMaidenRegistry.DTOs.MemberSong;

namespace IronMaidenRegistry.DTOs.Song;

public record SongInput(
    [Required(AllowEmptyStrings = false, ErrorMessage = "Required field!")]
    [MaxLength(ErrorMessage = "Song name cannot exceed 50 characters!")]
    string Name,

    [Required(ErrorMessage = "Required field!")]
    [Range(1, 30, ErrorMessage = "Song duration must be between 1 and 30 minutes!")]
    byte DurationInMinutes,

    [Required(ErrorMessage = "Required field!")]
    [Range(0.0, 5.0, ErrorMessage = "Average Score must be between 0.0 and 5.0!")]
    byte AverageScore,

    [Required(AllowEmptyStrings = false, ErrorMessage = "Member Id is required!")]
    List<MemberSongInput> MembersSongs
);
