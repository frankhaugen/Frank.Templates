using AutoMapper;
using Microservice.Client.Models.Responses;
using Microservice.Models.Companies;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly ILogger<CompaniesController> _logger;
    private readonly IMapper _mapper;
    private readonly ICompanyService _companyService;

    public CompaniesController(ILogger<CompaniesController> logger, IMapper mapper, ICompanyService companyService)
    {
        _logger = logger;
        _mapper = mapper;
        _companyService = companyService;
    }

    [HttpGet(Name = "search")]
    [ProducesResponseType(typeof(CompaniesResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(string? companyName = null, string? town = null, int currentPage = 0, int pageSize = 20)
    {
        var companyList = await _companyService.SearchForLegalEntityAsync(companyName, town, currentPage, pageSize);

        if (!companyList.IsSuccessful || companyList.Data == null) return BadRequest(companyList.Content);

        var response = _mapper.Map<CompaniesList, CompaniesResponse>(companyList.Data);

        return Ok(response);
    }
}
