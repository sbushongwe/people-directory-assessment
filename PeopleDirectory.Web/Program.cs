using PeopleDirectory.Web.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

builder.Services.Configure<ApiSettings>(
    builder.Configuration.GetSection("ApiSettings"));

builder.Services.Configure<AdminSettings>(
    builder.Configuration.GetSection("AdminSettings"));

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);

    options.Cookie.HttpOnly = true;

    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseSession();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();