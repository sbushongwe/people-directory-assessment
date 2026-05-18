namespace PeopleDirectory.Core.DTOs;

public class PersonDto
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string Surname { get; set; }

    public string Email { get; set; }

    public string MobileNumber { get; set; }

    public string Gender { get; set; }

    public string ProfilePictureUrl { get; set; }

    public string Country { get; set; }

    public string City { get; set; }

    public DateTime CreatedDate { get; set; }
}