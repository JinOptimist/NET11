using FootballApi.Service;
using FootballApi.VIewModels;
using Microsoft.AspNetCore.Mvc;

namespace FootballApi.EndPoints
{
    public static class AddClubEndPoints
    {
        public static void AddEndPoints(this WebApplication app) 
        {
            app.MapGet("/GetAll", GetAll);
            app.MapGet ("/GetClubsForPaginator", GetClubsForPaginator);
            app.MapPost("/Save", SaveClub);
            app.MapDelete("/Remove",RemoveClub);


        }
        private static IResult GetAll(IClubService clubService)
        {
            var clubs = clubService.GetClubs()
                                    .Select(x => new ClubViewModel 
                                     { 
                                       Id =  x.Id ,
                                       IdUserCreator = x.IdUserCreator , 
                                       Name = x.Name , 
                                       Stadium = x.Stadium , 
                                       League = new ShortLeagueViewModel 
                                       { 
                                           Id = x.League.Id,
                                           ShortName = x.League.ShortName 
                                       } 
                                     });
            return Results.Ok(clubs);


        }

        private static IResult GetClubsForPaginator(IClubService clubService, int page = 1,int perPage = 10) 
        {
            var clubs = clubService.GetForPaginator(page, perPage);
            return Results.Ok(clubs);


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
