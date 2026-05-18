using PeopleDirectory.Core.DTOs;
using PeopleDirectory.Core.Interfaces;

namespace PeopleDirectory.Core.Services;

public class CountryService : ICountryService
{
    private readonly ICountryRepository _repository;

    public CountryService(ICountryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CountryDto>> GetAllAsync()
    {
        var countries = await _repository.GetAllCountriesAsync();

        return countries.Select(c => new CountryDto
        {
            Id = c.Id,
            Name = c.Name
        });
    }
}