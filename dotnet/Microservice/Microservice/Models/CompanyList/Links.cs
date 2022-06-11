namespace Microservice.Models.CompanyList
{
    public class Links
    {
        [JsonPropertyName("first")] public First? First { get; set; }

        [JsonPropertyName("self")] public Self? Self { get; set; }

        [JsonPropertyName("next")] public Next? Next { get; set; }

        [JsonPropertyName("last")] public Last? Last { get; set; }
    }
}