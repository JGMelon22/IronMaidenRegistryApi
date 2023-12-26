using System.ComponentModel.DataAnnotations;

namespace IronMaidenRegistry.DTOs.Instrument;

public record InstrumentInput(
    [Required(AllowEmptyStrings = false, ErrorMessage = "Required field!")]
    [AllowedValues("Bass", "Guitar", "Drum", "Keyboard", "Vocals")]
    string Name
);