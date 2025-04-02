using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using MediaVisualizer.Web.Api;
using MediaVisualizer.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Register as Windows service
builder.Host.UseWindowsService();
builder.Services.AddWindowsService();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register HttpClient
builder.Services.AddScoped<HttpClient>();
var apiBaseUrl = builder.Configuration.GetSection("ApiSettings:BaseUrl").Value!;
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

// Register Api Services
builder.Services.AddScoped<IAnimeApi, AnimeApi>();
builder.Services.AddScoped<IMangaApi, MangaApi>();
builder.Services.AddScoped<IManwhaApi, ManwhaApi>();
builder.Services.AddScoped<IBrandApi, BrandApi>();
builder.Services.AddScoped<IArtistApi, ArtistApi>();
builder.Services.AddScoped<ITagApi, TagApi>();
builder.Services.AddScoped<IFileStreamApi, FileStreamApi>();

// Register Blazorise
builder.Services
    .AddBlazorise(options => { options.Immediate = true; })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseStatusCodePagesWithRedirects("/404");

await app.RunAsync();