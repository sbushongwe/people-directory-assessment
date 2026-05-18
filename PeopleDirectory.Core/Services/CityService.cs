using PeopleDirectory.Core.DTOs;
using PeopleDirectory.Core.Interfaces;

namespace PeopleDirectory.Core.Services;

public class CityService : ICityService
{
    private readonly ICityRepository _repository;

    public CityService(ICityRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CityDto>> GetByCountryAsync(int countryId)
    {
        var cities = await _repository.GetCitiesByCountryAsync(countryId);

        return cities.Select(c => new CityDto
        {
            Id = c.Id,
            Name = c.Name
        });
    }
}