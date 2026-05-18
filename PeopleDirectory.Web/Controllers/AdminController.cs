using Microsoft.AspNetCore.Mvc;
using PeopleDirectory.Web.Models;
using System.Text.Json;
using Microsoft.Extensions.Options;
using PeopleDirectory.Web.Configuration;

namespace PeopleDirectory.Web.Controllers;

public class AdminController : BaseAdminController
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;

    public AdminController(
      IHttpClientFactory httpClientFactory,
      IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;

        _apiSettings = apiSettings.Value;
    }

    public async Task<IActionResult> Index()
    {
        if (!IsLoggedIn())
        {
            return RedirectToLogin();
        }

        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync(
            $"{_apiSettings.BaseUrl}/people");

        var json = await response.Content.ReadAsStringAsync();

        var people = JsonSerializer.Deserialize<List<AdminPersonViewModel>>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        return View(people);
    }
}
