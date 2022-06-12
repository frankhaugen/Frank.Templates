namespace Microservice.Models.Companies
{
    public class Address
    {
        [JsonPropertyName("land")] public string? Country { get; set; }

        [JsonPropertyName("landkode")] public string? CountryCode { get; set; }

        [JsonPropertyName("postnummer")] public string? ZipCode { get; set; }

        [JsonPropertyName("poststed")] public string? City { get; set; }

        [JsonPropertyName("adresse")] public List<string>? Street { get; set; }

        [JsonPropertyName("kommune")] public string? Municipality { get; set; }

        [JsonPropertyName("kommunenummer")] public string? MunicipalityNumber { get; set; }
    }
}