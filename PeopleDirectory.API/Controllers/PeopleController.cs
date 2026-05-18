using Microsoft.AspNetCore.Mvc;
using PeopleDirectory.Core.DTOs;
using PeopleDirectory.Core.Entities;
using PeopleDirectory.Core.Services;

namespace PeopleDirectory.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    private readonly IPersonService _personService;

    public PeopleController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var people = await _personService.GetAllAsync();

        return Ok(people);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var person = await _personService.GetByIdAsync(id);

        if (person == null)
            return NotFound();

        return Ok(person);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePersonDto dto)
    {
        await _personService.CreateAsync(dto);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdatePersonDto dto)
    {
        await _personService.UpdateAsync(dto);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _personService.DeleteAsync(id);

        return NoContent();
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(
    [FromQuery] string term,
    [FromQuery] int? countryId,
    [FromQuery] int? cityId)
    {
        var results = await _personService.SearchAsync(
            term,
            countryId,
            cityId);

        return Ok(results);
    }

    [HttpGet("suggestions")]
    public async Task<IActionResult> Suggestions(string term)
    {
        var results = await _personService.GetSuggestionsAsync(term);

        return Ok(results);
    }
}