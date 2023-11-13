using Azure;
using FootballApi.DatabaseStuff;
using FootballApi.DatabaseStuff.Repositories.Clubs;
using FootballApi.DatabaseStuff.Repositories.Leagues;
using FootballApi.EndPoints;
using FootballApi.Service;
using FootballApi.Service.SweggerServices;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var dbContextResolver = new Startup();
dbContextResolver.RegisterDbContext(builder.Services);

builder.Services.AddScoped<IClubRepository, ClubRepository>();
builder.Services.AddScoped<ILeagueRepository, LeagueRepository>();

builder.Services.AddScoped<ILeagueService, LeagueService>();
builder.Services.AddScoped<IClubService, ClubService>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => 
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Contact = new OpenApiContact
        {
            Url = new Uri("https://t.me/voolker29")
        },
        Title = "Football api for GamerShop"

    });
    options.TagActionsBy(api =>
    {
        return api.Rename();
    });

    options.DocInclusionPredicate((name, api) =>true);
} );
var app = builder.Build();

new Seed().Fill(app.Services);

app.UseSwagger(); 
app.UseSwaggerUI();
app.AddClubEndPoints();
app.AddLeagueEndPoints();

app.Run();
