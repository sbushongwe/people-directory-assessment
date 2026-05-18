using PeopleDirectory.Core.DTOs;

namespace PeopleDirectory.Core.Services;

public interface ICityService
{
    Task<IEnumerable<CityDto>> GetByCountryAsync(int countryId);
}