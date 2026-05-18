namespace PeopleDirectory.Core.DTOs;

public class PersonSearchResultDto
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public string Country { get; set; }

    public string City { get; set; }

    public string Email { get; set; }

    public string MobileNumber { get; set; }
}