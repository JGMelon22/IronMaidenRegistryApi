using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace IronMaidenRegistry.DTOs.Instrument;

public record InstrumentInput(
    [Required(AllowEmptyStrings = false, ErrorMessage = "Required field!")]
    [AllowedValues("Bass", "Guitar", "Drum", "Keyboard")]
    string Name
);