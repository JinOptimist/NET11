using FootballApi.Attributes;
using FootballApi.Service;
using FootballApi.VIewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Text;
using System.Text.Json;

namespace FootballApi.EndPoints
{
    [DisplayNameForSwagger("Club")]
    public static class ClubEndPoints
    {
        public static void AddClubEndPoints(this WebApplication app) 
        {
            app.MapGet("/GetAll", GetAll);
            app.MapGet ("/GetClubsForPaginator", GetClubsForPaginator);
            app.MapPost("/Save", SaveClub);
            app.MapDelete("/Remove",RemoveClub);


        }
        private static IResult GetAll(IClubService clubService)
        {
            var clubs = clubService.GetClubs();

            return Results.Content(JsonSerializer.Serialize(clubs), "application/json", Encoding.UTF8);


        }
        private static IResult GetClubsForPaginator(IClubService clubService, int page = 1,int perPage = 10) 
        {

            var paginator = clubService.GetForPaginator(page, perPage);
            return Results.Content(JsonSerializer.Serialize(paginator), "application/json",Encoding.UTF8);


        }
        private static IResult SaveClub(IClubService clubService, [FromBody] ClubViewModel club)
        {
            clubService.Save(club);
            return Results.Ok(true);


        }
        private static IResult RemoveClub(IClubService clubService,int id)
        {
            clubService.Delete(id);
            return Results.Ok(true);


        }
    }
}
