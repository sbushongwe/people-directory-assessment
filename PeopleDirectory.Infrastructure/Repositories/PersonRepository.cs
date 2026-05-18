using Microsoft.EntityFrameworkCore;
using PeopleDirectory.Core.Entities;
using PeopleDirectory.Core.Interfaces;
using PeopleDirectory.Infrastructure.Data;

namespace PeopleDirectory.Infrastructure.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Person>> SearchAsync(
        string? term,
        int? countryId,
        int? cityId)
    {
        var query = _context.Persons
            .Include(p => p.Country)
            .Include(p => p.City)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(term))
        {
            term = term.ToLower().Trim();
            query = query.Where(p =>
                p.FirstName.ToLower().Contains(term)
                ||
                p.Surname.ToLower().Contains(term)
                ||
                (p.FirstName + " " + p.Surname)
                    .ToLower()
                    .Contains(term)
            );
        }

        if (countryId.HasValue)
        {
            query = query.Where(
                p => p.CountryId == countryId.Value);
        }

        if (cityId.HasValue)
        {
            query = query.Where(
                p => p.CityId == cityId.Value);
        }

        return await query.ToListAsync();
    }

    public async Task<Person> GetPersonDetailsAsync(int id)
    {
        return await _context.Persons
            .Include(p => p.Country)
            .Include(p => p.City)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Person>> GetAllPeopleAsync()
    {
        return await _context.Persons
            .Include(p => p.Country)
            .Include(p => p.City)
            .ToListAsync();
    }
}