using Microsoft.EntityFrameworkCore;
using PeopleDirectory.Core.Entities;
using PeopleDirectory.Core.Interfaces;
using PeopleDirectory.Infrastructure.Data;


namespace PeopleDirectory.Infrastructure.Repositories;

public class CityRepository : Repository<City>, ICityRepository
{
    public CityRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<City>> GetCitiesByCountryAsync(int countryId)
    {
        return await _context.Cities
            .Where(c => c.CountryId == countryId)
            .OrderBy(c => c.Name)
            .ToListAsync();
    }
}