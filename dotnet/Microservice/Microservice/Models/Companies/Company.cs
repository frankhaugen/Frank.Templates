namespace Microservice.Models.Companies
{
    public class Company
    {
        [JsonPropertyName("organisasjonsnummer")] public long RegistrationNumber { get; set; }

        [JsonPropertyName("antallAnsatte")] public long Employees { get; set; }

        [JsonPropertyName("navn")] public string? Name { get; set; }

        [JsonPropertyName("maalform")] public string? Language { get; set; }

        [JsonPropertyName("registrertIForetaksregisteret")]
        public bool InCompanyRegistry { get; set; }

        [JsonPropertyName("registrertIStiftelsesregisteret")]
        public bool InTrustRegistry { get; set; }

        [JsonPropertyName("registrertIFrivillighetsregisteret")]
        public bool InNgoRegistry { get; set; }

        [JsonPropertyName("konkurs")] public bool IsBankrupt { get; set; }

        [JsonPropertyName("underAvvikling")] public bool IsUnderLiquidation { get; set; }

        [JsonPropertyName("registrertIMvaregisteret")]
        public bool InVatRegistry { get; set; }

        [JsonPropertyName("underTvangsavviklingEllerTvangsopplosning")]
        public bool IsUnderForcedLiquidation { get; set; }

        [JsonPropertyName("stiftelsesdato")] public DateTimeOffset CreationDate { get; set; }

        [JsonPropertyName("registreringsdatoEnhetsregisteret")]
        public DateTimeOffset RegistrationDate { get; set; }

        [JsonPropertyName("organisasjonsform")] public Variant? Variant { get; set; }

        [JsonPropertyName("postadresse")] public Address? PostalAddress { get; set; }

        [JsonPropertyName("naeringskode1")] public BusinessArea? BusinessArea { get; set; }

        [JsonPropertyName("forretningsadresse")] public Address? BusinessAddress { get; set; }

        [JsonPropertyName("_links")] public Links? Links { get; set; }
    }
}