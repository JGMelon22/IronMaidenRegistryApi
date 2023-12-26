using System.ComponentModel.DataAnnotations;

namespace IronMaidenRegistry.DTOs.Member;

public record MemberInput(
    [Required(AllowEmptyStrings = false, ErrorMessage = "Required field!")]
    [AllowedValues("Nicko McBrain", "Bruce Dickinson", "Steve Harris", "Dave Murray", "Adrian Smith", "Janick Gers", "Blaze Bayley", "Paul Di'Anno", "Clive Burr", "Dennis Stratton")]
    string FullName,

    [Required(ErrorMessage = "Required field!")]
    DateOnly BirthDate,

    [Required(ErrorMessage = "Instrument Id is required!")]
    Guid InstrumentId
);