using FootballApi.Attributes;
using FootballApi.Service;
using FootballApi.VIewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace FootballApi.EndPoints
{
    [DisplayNameForSwagger("League")]
    public static class LeagueEndPoints
    {
        public static void AddLeagueEndPoints(this WebApplication app)
        {
            app.MapGet("/League/GetAll", GetAll);
            app.MapGet("/League/GetLimitedAmount", GetLimitedAmount);
            app.MapGet("/League/GetForPaginator", GetForPaginator);
            app.MapGet("/League/Count", Count);
            app.MapGet("/League/Get", Get);
            app.MapPost("/League/Save", Save);
            app.MapDelete("/League/Delete", Delete);


        }

        private static IResult GetAll(ILeagueService leagueService)
        {
            var leagues = leagueService.GetLeagues();
            return Results.Content(JsonSerializer.Serialize(leagues), "application/json", Encoding.UTF8); 
        }

        private static IResult GetLimitedAmount(ILeagueService leagueService,int amount)
        {
            var leagues = leagueService.GetLimetedAmount(amount);
            return Results.Content(JsonSerializer.Serialize(leagues), "application/json", Encoding.UTF8); ;
        }

        private static IResult GetForPaginator(ILeagueService leagueService, int page = 1, int perPage = 10)
        {
            var leagues = leagueService.GetForPaginator(page,perPage);
            return Results.Content(JsonSerializer.Serialize(leagues), "application/json", Encoding.UTF8);
        }

        private static IResult Save(ILeagueService leagueService,[FromBody] LeagueViewModel league)
        {
            leagueService.Save(league);
            return Results.Ok();
        }
        private static IResult Delete(ILeagueService leagueService,int id)
        {
            leagueService.Delete(id);
            return Results.Ok();
        }

        private static IResult Count(ILeagueService leagueService)
        {
            return Results.Ok(leagueService.Count());
        }
        private static IResult Get(ILeagueService leagueService, int count, int skip)
        {
            var leagues = leagueService.Get(count, skip);
            return Results.Content(JsonSerializer.Serialize(leagues), "application/json", Encoding.UTF8);
        }
    }
}
