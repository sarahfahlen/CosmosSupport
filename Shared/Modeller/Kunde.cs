using System.ComponentModel.DataAnnotations;

namespace SupportWebApp.Shared.Modeller;

public class Kunde
{
    [Required]
    public int KundeId { get; set; }

    [Required(ErrorMessage = "Navn er påkrævet.")]
    [StringLength(50, ErrorMessage = "Navn må højst være 50 tegn.")]
    public string Navn { get; set; } = default!;

    [Required(ErrorMessage = "Email er påkrævet.")]
    [EmailAddress(ErrorMessage = "Ugyldig e-mailadresse.")]
    public string Email { get; set; } = default!;

    [Required(ErrorMessage = "Telefon er påkrævet.")]
    [Phone(ErrorMessage = "Telefonnummer er ugyldigt.")]
    public string Telefon { get; set; } = default!;
}