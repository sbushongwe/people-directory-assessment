using PeopleDirectory.Core.DTOs;

namespace PeopleDirectory.Core.Services;

public interface ICountryService
{
    Task<IEnumerable<CountryDto>> GetAllAsync();
}