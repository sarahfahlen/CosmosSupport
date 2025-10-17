using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace SupportWebApp.Shared.Modeller;

public class SupportHenvendelse
{
    // Cosmos DB kræver at 'id' er en string – her genereres et nyt numerisk id som tekst
    [JsonProperty(PropertyName = "id")]              // Cosmos (Newtonsoft)
    [JsonPropertyName("id")]                        // Blazor (System.Text.Json)
    public string Id { get; set; } = new Random().Next(1, 999999).ToString();

    [Required(ErrorMessage = "Kategori er påkrævet.")]
    [StringLength(40, ErrorMessage = "Kategori må højst være 40 tegn.")]
    [JsonProperty(PropertyName = "Kategori")]
    [JsonPropertyName("Kategori")]
    public string Kategori { get; set; } = default!;

    [Required(ErrorMessage = "Beskrivelse er påkrævet.")]
    [StringLength(500, ErrorMessage = "Beskrivelse må højst være 500 tegn.")]
    [JsonProperty(PropertyName = "Beskrivelse")]
    [JsonPropertyName("Beskrivelse")]
    public string Beskrivelse { get; set; } = default!;

    [DataType(DataType.DateTime)]
    [JsonProperty(PropertyName = "Dato")]
    [JsonPropertyName("Dato")]
    public DateTime Dato { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "Kundeoplysninger skal udfyldes.")]
    [JsonProperty(PropertyName = "Kunde")]
    [JsonPropertyName("Kunde")]
    public Kunde Kunde { get; set; } = new();
}