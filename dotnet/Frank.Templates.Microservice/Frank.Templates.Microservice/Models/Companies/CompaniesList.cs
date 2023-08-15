namespace Frank.Templates.Microservice.Models.Companies
{
    public class CompaniesList
    {
        [JsonPropertyName("_embedded")] public Embedded Data { get; set; } = new Embedded();

        [JsonPropertyName("_links")] public Links Links { get; set; } = new Links();

        [JsonPropertyName("page")] public Page Page { get; set; } = new Page();
    }
}