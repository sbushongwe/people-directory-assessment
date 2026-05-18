namespace PeopleDirectory.Core.Entities;

public class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string Surname { get; set; }

    public string Email { get; set; }

    public string MobileNumber { get; set; }

    public string Gender { get; set; }

    public string ProfilePictureUrl { get; set; }

    public int CountryId { get; set; }

    public Country Country { get; set; }

    public int CityId { get; set; }

    public City City { get; set; }

    public DateTime CreatedDate { get; set; }
}