using FootballApi.DatabaseStuff.Models;

namespace FootballApi.Service
{
    public interface IClubService
    {
        IEnumerable<Club> GetClubs();

    }
}
