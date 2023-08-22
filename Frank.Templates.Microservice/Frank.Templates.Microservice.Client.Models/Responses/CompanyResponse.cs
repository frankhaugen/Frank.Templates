namespace Frank.Templates.Microservice.Client.Models.Responses
{
    public class CompanyResponse
    {
        public long RegistrationNumber { get; set; }
        public long Employees { get; set; }

        public string? Name { get; set; }
        public string? Language { get; set; }

        public bool InCompanyRegistry { get; set; }
        public bool InTrustRegistry { get; set; }
        public bool InNgoRegistry { get; set; }
        public bool IsBankrupt { get; set; }
        public bool IsUnderLiquidation { get; set; }
        public bool InVatRegistry { get; set; }
        public bool IsUnderForcedLiquidation { get; set; }

        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }

        public VariantResponse? Variant { get; set; }
        public BusinessAreaResponse? BusinessArea { get; set; }
        public AddressResponse? PostalAddress { get; set; }
        public AddressResponse? BusinessAddress { get; set; }
        public Uri? Link { get; set; }
    }
}
