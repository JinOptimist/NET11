using FootballApi.Service;
using System.Text.Json;

namespace FootballApi.EndPoints
{
    public static class AddClubEndPoints
    {
        public static void AddEndPoints(this WebApplication app) 
        {
            app.MapGet("/ClubsList", GetClubList);
        
        }

        private static IResult GetClubList(IClubService clubService) 
        {
            var t = clubService.GetClubs().Take(2);

            return Results.Ok(t);


        }
    }
}
