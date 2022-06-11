namespace Microservice.Models.CompanyList
{
    public class Embedded
    {
        [JsonPropertyName("enheter")] public List<Company.Company>? Companies { get; set; }
    }
}