using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.DataMigrator;
using MediaVisualizer.Services;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register the DbContext with the connection string
builder.Services.AddDbContext<MediaVisualizerDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MediaVisualizerDB")));

// Register the repositories
builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();
builder.Services.AddScoped<IMangaRepository, MangaRepository>();
builder.Services.AddScoped<IManwhaRepository, ManwhaRepository>();

// Register the migrators
builder.Services.AddScoped<ISeedsMigratorRepository, SeedsMigratorRepository>();
builder.Services.AddScoped<IAnimeMigratorRepository, AnimeMigratorRepository>();

// Register the services
builder.Services.AddScoped<IAnimeService, AnimeService>();
builder.Services.AddScoped<IMangaService, MangaService>();
builder.Services.AddScoped<IManwhaService, ManwhaService>();
builder.Services.AddScoped<ISeedMigratorService, SeedsMigratorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Media Visualizer Api");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();