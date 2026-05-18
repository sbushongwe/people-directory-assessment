using PeopleDirectory.Core.Entities;

namespace PeopleDirectory.Core.Interfaces;

public interface ICountryRepository : IRepository<Country>
{
    Task<IEnumerable<Country>> GetAllCountriesAsync();
}