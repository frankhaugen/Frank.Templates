using Frank.Templates.Microservice.Models.Companies;

using RestSharp;

namespace Frank.Templates.Microservice.Services;

public class CompanyService : ICompanyService
{
    private readonly string _baseUrl = "https://data.brreg.no/enhetsregisteret/api";

    public async Task<RestResponse<Company>> GetCompanyAsync(long registrationNumber)
    {
        if (registrationNumber <= 0) throw new ArgumentException("Invalid value: 'organizationNumber'", nameof(registrationNumber));

        var request = new RestRequest($"{_baseUrl}/enheter/{registrationNumber}");
        var client = new RestClient();
        var response = await client.ExecuteAsync<Company>(request);

        return response;
    }

    public async Task<RestResponse<CompaniesList>> SearchForLegalEntityAsync(string? companyName = null, string? town = null, int currentPage = 0, int pageSize = 20)
    {
        var request = new RestRequest($"{_baseUrl}/enheter");

        if (!string.IsNullOrWhiteSpace(companyName))
            request.AddQueryParameter("navn", companyName);
        if (!string.IsNullOrWhiteSpace(town))
            request.AddQueryParameter("postadresse.poststed", town);

        request.AddQueryParameter("page", currentPage);
        request.AddQueryParameter("size", pageSize);

        var client = new RestClient();
        var response = await client.ExecuteAsync<CompaniesList>(request);

        return response;
    }
}