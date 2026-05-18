using Microsoft.EntityFrameworkCore;
using PeopleDirectory.Core.Entities;
using PeopleDirectory.Core.Interfaces;
using PeopleDirectory.Infrastructure.Data;

namespace PeopleDirectory.Infrastructure.Repositories;

public class CountryRepository : Repository<Country>, ICountryRepository
{
    public CountryRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Country>> GetAllCountriesAsync()
    {
        return await _context.Countries
            .OrderBy(c => c.Name)
            .ToListAsync();
    }
}
