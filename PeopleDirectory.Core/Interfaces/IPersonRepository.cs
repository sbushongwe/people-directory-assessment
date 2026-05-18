using PeopleDirectory.Core.Entities;

namespace PeopleDirectory.Core.Interfaces;

public interface IPersonRepository : IRepository<Person>
{
    Task<IEnumerable<Person>> SearchAsync(
    string? term,
    int? countryId,
    int? cityId);

    Task<Person> GetPersonDetailsAsync(int id);

    Task<IEnumerable<Person>> GetAllPeopleAsync();
}