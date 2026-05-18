using Microsoft.AspNetCore.Mvc;
using PeopleDirectory.Core.Services;

namespace PeopleDirectory.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : ControllerBase
{
    private readonly ICityService _service;

    public CitiesController(ICityService service)
    {
        _service = service;
    }

    [HttpGet("by-country/{countryId}")]
    public async Task<IActionResult> GetByCountry(int countryId)
    {
        var cities = await _service.GetByCountryAsync(countryId);

        return Ok(cities);
    }
}