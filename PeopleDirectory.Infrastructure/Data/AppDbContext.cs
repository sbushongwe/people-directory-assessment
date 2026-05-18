using Microsoft.EntityFrameworkCore;
using PeopleDirectory.Core.Entities;

namespace PeopleDirectory.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<AdminUser> AdminUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Person>()
            .HasOne(p => p.Country)
            .WithMany()
            .HasForeignKey(p => p.CountryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Person>()
            .HasOne(p => p.City)
            .WithMany()
            .HasForeignKey(p => p.CityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
