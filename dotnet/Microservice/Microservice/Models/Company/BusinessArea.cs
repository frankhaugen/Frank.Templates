namespace Microservice.Models.Company
{
    public class BusinessArea
    {
        [JsonPropertyName("beskrivelse")] public string? Description { get; set; }

        [JsonPropertyName("kode")] public string? Code { get; set; }
    }
}