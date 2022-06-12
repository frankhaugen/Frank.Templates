namespace Microservice.Models.Companies
{
    public class Embedded
    {
        [JsonPropertyName("enheter")] public List<Company> Companies { get; set; } = new List<Company>();
    }
}