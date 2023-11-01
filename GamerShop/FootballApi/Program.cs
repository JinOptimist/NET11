using FootballApi.DatabaseStuff;
using FootballApi.DatabaseStuff.Repositories.Clubs;
using FootballApi.DatabaseStuff.Repositories.Leagues;
using FootballApi.EndPoints;
using FootballApi.Service;

var builder = WebApplication.CreateBuilder(args);

var dbContextResolver = new Startup();
dbContextResolver.RegisterDbContext(builder.Services);

builder.Services.AddScoped<IClubRepository, ClubRepository>();
builder.Services.AddScoped<ILeagueRepository, LeagueRepository>();

builder.Services.AddScoped<ILeagueService, LeagueService>();
builder.Services.AddScoped<IClubService, ClubService>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

new Seed().Fill(app.Services);

app.UseSwagger();
app.UseSwaggerUI();

AddClubEndPoints.AddEndPoints(app);

app.Run();
