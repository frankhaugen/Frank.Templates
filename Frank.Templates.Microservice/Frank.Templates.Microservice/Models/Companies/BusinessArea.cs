namespace Frank.Templates.Microservice.Models.Companies
{
    public class BusinessArea
    {
        [JsonPropertyName("beskrivelse")] public string? Description { get; set; }

        [JsonPropertyName("kode")] public string? Code { get; set; }
    }
}