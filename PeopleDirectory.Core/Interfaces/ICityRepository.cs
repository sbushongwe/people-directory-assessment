using PeopleDirectory.Core.Entities;

namespace PeopleDirectory.Core.Interfaces;

public interface ICityRepository : IRepository<City>
{
    Task<IEnumerable<City>> GetCitiesByCountryAsync(int countryId);
}