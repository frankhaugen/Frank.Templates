namespace Frank.Templates.Microservice.Models.Companies
{
    public class Page
    {
        [JsonPropertyName("size")] public int Size { get; set; }

        [JsonPropertyName("totalElements")] public int TotalElements { get; set; }

        [JsonPropertyName("totalPages")] public int TotalPages { get; set; }

        [JsonPropertyName("number")] public int Number { get; set; }
    }
}