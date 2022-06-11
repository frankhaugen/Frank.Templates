namespace Microservice.Models.CompanyList
{
    public class CompaniesList
    {
        [JsonPropertyName("_embedded")] public Embedded? Data { get; set; }

        [JsonPropertyName("_links")] public Links? Links { get; set; }

        [JsonPropertyName("page")] public Page? Page { get; set; }
    }
}