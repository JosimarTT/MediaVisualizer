using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register as Windows service
builder.Host.UseWindowsService();
builder.Services.AddWindowsService();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        corsPolicyBuilder =>
        {
            corsPolicyBuilder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// Register the DbContext with the connection string
builder.Services.AddDbContext<MediaVisualizerDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MediaVisualizerDB")));

// Register the repositories
builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();
builder.Services.AddScoped<IMangaRepository, MangaRepository>();
builder.Services.AddScoped<IManwhaRepository, ManwhaRepository>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();

// Register the services
builder.Services.AddScoped<IAnimeService, AnimeService>();
builder.Services.AddScoped<IMangaService, MangaService>();
builder.Services.AddScoped<IManwhaService, ManwhaService>();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ITagService, TagService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "Media Visualizer Api");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();