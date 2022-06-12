namespace Microservice.Models.Companies
{
    public class Variant
    {
        [JsonPropertyName("kode")] public string? Code { get; set; }

        [JsonPropertyName("beskrivelse")] public string? Description { get; set; }

        [JsonPropertyName("_links")] public Links? Links { get; set; }
    }
}