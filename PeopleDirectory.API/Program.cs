using Microsoft.EntityFrameworkCore;
using PeopleDirectory.Core.Configration;
using PeopleDirectory.Core.Interfaces;
using PeopleDirectory.Core.Services;
using PeopleDirectory.Infrastructure.Data;
using PeopleDirectory.Infrastructure.Repositories;
using PeopleDirectory.Infrastructure.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MainConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.Configure<EmailSettings>(
builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebApp",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowWebApp");

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
