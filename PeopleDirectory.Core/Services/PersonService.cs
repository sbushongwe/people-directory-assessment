using PeopleDirectory.Core.Entities;
using PeopleDirectory.Core.Interfaces;
using PeopleDirectory.Core.DTOs;

namespace PeopleDirectory.Core.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _repository;
    private readonly IEmailService _emailService;

    public PersonService(IPersonRepository repository,
    IEmailService emailService)
    {
        _repository = repository;

        _emailService = emailService;
    }

    public async Task<IEnumerable<PersonDto>> GetAllAsync()
    {
        var people = await _repository.GetAllPeopleAsync();

        return people.Select(p => new PersonDto
        {
            Id = p.Id,
            FirstName = p.FirstName,
            Surname = p.Surname,
            Email = p.Email,
            MobileNumber = p.MobileNumber,
            Gender = p.Gender,
            ProfilePictureUrl = p.ProfilePictureUrl,
            Country = p.Country.Name,
            City = p.City.Name,
            CreatedDate = p.CreatedDate
        });
    }

    public async Task<PersonDetailsDto> GetByIdAsync(int id)
    {
        var person = await _repository.GetPersonDetailsAsync(id);

        if (person == null)
            return null;

        return new PersonDetailsDto
        {
            Id = person.Id,
            FirstName = person.FirstName,
            Surname = person.Surname,
            Email = person.Email,
            MobileNumber = person.MobileNumber,
            Gender = person.Gender,
            ProfilePictureUrl = person.ProfilePictureUrl,
            Country = person.Country.Name,
            City = person.City.Name,
            CreatedDate = person.CreatedDate,
            CountryId = person.CountryId,
            CityId = person.CityId
        };
    }

    public async Task CreateAsync(CreatePersonDto dto)
    {
        var person = new Person
        {
            FirstName = dto.FirstName,
            Surname = dto.Surname,
            Email = dto.Email,
            MobileNumber = dto.MobileNumber,
            Gender = dto.Gender,
            ProfilePictureUrl = dto.ProfilePictureUrl,
            CountryId = dto.CountryId,
            CityId = dto.CityId,
            CreatedDate = DateTime.UtcNow
        };

        await _repository.AddAsync(person);

        await _repository.SaveChangesAsync();

        await _emailService.SendAsync(
            "Person Created",
            $"""
            A new person record was created.

            Name: {person.FirstName} {person.Surname}
            Email: {person.Email}
            Mobile: {person.MobileNumber}
            Gender: {person.Gender}
            Profile Picture URL: {person.ProfilePictureUrl}
            Created: {DateTime.UtcNow}
            """);
    }

    public async Task UpdateAsync(UpdatePersonDto dto)
    {
        var person = await _repository.GetByIdAsync(dto.Id);

        if (person == null)
            return;

        var oldValues =
            $"""
        OLD VALUES:
        First Name: {person.FirstName}
        Surname: {person.Surname}
        Email: {person.Email}
        Mobile: {person.MobileNumber}
        Gender: {person.Gender}
        Profile Picture URL: {person.ProfilePictureUrl}
        Country Id: {person.CountryId}
        City Id: {person.CityId}
        """;

        person.FirstName = dto.FirstName;
        person.Surname = dto.Surname;
        person.Email = dto.Email;
        person.MobileNumber = dto.MobileNumber;
        person.Gender = dto.Gender;
        person.ProfilePictureUrl = dto.ProfilePictureUrl;
        person.CountryId = dto.CountryId;
        person.CityId = dto.CityId;

        _repository.Update(person);

        await _repository.SaveChangesAsync();

        await _emailService.SendAsync(
            "Person Updated",
            $"""
        A person record was updated.

        {oldValues}

        NEW VALUES:
        First Name: {person.FirstName}
        Surname: {person.Surname}
        Email: {person.Email}
        Mobile: {person.MobileNumber}
        Gender: {person.Gender}
        Profile Picture URL: {person.ProfilePictureUrl}
        Country Id: {person.CountryId}
        City Id: {person.CityId}

        Updated: {DateTime.UtcNow}
        """);
    }

    public async Task DeleteAsync(int id)
    {
        var person = await _repository.GetByIdAsync(id);

        if (person == null)
            return;

        _repository.Delete(person);

        await _repository.SaveChangesAsync();
    }

    public async Task<IEnumerable<PersonSearchResultDto>> SearchAsync(
    string term,
    int? countryId,
    int? cityId)
    {
        var people = await _repository.SearchAsync(
            term,
            countryId,
            cityId);

        return people.Select(p => new PersonSearchResultDto
        {
            Id = p.Id,
            FullName = $"{p.FirstName} {p.Surname}",
            Country = p.Country.Name,
            City = p.City.Name,
            Email = p.Email,
            MobileNumber = p.MobileNumber
        });
    }

    public async Task<List<string>> GetSuggestionsAsync(string term)
    {
        if (string.IsNullOrWhiteSpace(term))
            return new List<string>();

        term = term.ToLower().Trim();

        var people = await _repository.GetAllAsync();

        return people
            .Where(p =>
                p.FirstName.ToLower().Contains(term)
                ||
                p.Surname.ToLower().Contains(term)
                ||
                ($"{p.FirstName} {p.Surname}")
                    .ToLower()
                    .Contains(term)
            )
            .Select(p => $"{p.FirstName} {p.Surname}")
            .Distinct()
            .Take(5)
            .ToList();
    }
}