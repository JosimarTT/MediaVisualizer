using MediaVisualizer.DataAccess;
using MediaVisualizer.DataAccess.Repositories;
using MediaVisualizer.DataImporter;
using MediaVisualizer.DataImporter.Importers;
using MediaVisualizer.Services;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
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
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

// Register the services
builder.Services.AddScoped<IAnimeService, AnimeService>();
builder.Services.AddScoped<IMangaService, MangaService>();
builder.Services.AddScoped<IManwhaService, ManwhaService>();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

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

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();