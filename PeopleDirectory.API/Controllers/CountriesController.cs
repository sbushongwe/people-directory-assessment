using Microsoft.AspNetCore.Mvc;
using PeopleDirectory.Core.Services;

namespace PeopleDirectory.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ICountryService _service;

    public CountriesController(ICountryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var countries = await _service.GetAllAsync();

        return Ok(countries);
    }
}