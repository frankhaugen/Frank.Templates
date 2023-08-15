using Frank.Templates.Microservice.Services;

namespace Frank.Templates.Microservice.Tests.Services;

public class CompanyServiceTests
{
    private readonly ITestOutputHelper _outputHelper;

    public CompanyServiceTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Fact()]
    public async Task GetCompanyAsyncTest()
    {
        _outputHelper.WriteLine("Starting test");

        var service = new CompanyService();

        var result = await service.GetCompanyAsync(996967158);

        _outputHelper.WriteLine(result.Content);

        _outputHelper.WriteLine("Ending test");
    }

    [Fact()]
    public async Task SearchForLegalEntityAsyncTest()
    {
        _outputHelper.WriteLine("Starting test");

        var service = new CompanyService();

        var result = await service.SearchForLegalEntityAsync("NRK");

        _outputHelper.WriteLine(result.Content);

        _outputHelper.WriteLine("Ending test");
    }
}
