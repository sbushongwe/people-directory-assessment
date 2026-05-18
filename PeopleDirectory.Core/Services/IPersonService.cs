using PeopleDirectory.Core.DTOs;
using PeopleDirectory.Core.Entities;

namespace PeopleDirectory.Core.Services;

public interface IPersonService
{
    Task<IEnumerable<PersonDto>> GetAllAsync();

    Task<PersonDetailsDto> GetByIdAsync(int id);

    Task CreateAsync(CreatePersonDto dto);

    Task UpdateAsync(UpdatePersonDto dto);

    Task DeleteAsync(int id);

    Task<IEnumerable<PersonSearchResultDto>> SearchAsync(
    string term,
    int? countryId,
    int? cityId);

    Task<List<string>> GetSuggestionsAsync(string term);
}