using FootballApi.DatabaseStuff.DataModels;
using FootballApi.DatabaseStuff.DataModels.Football;
using FootballApi.DatabaseStuff.Models;
using FootballApi.DatabaseStuff.Repositories.Clubs;
using FootballApi.DatabaseStuff.Repositories.Leagues;
using FootballApi.VIewModels;

namespace FootballApi.Service
{
    public class ClubService : IClubService
    {
        private IClubRepository _clubRepository;
        private ILeagueRepository _leagueRepository;

        public ClubService(IClubRepository clubRepository, ILeagueRepository leagueRepository)
        {
            _clubRepository = clubRepository;
            _leagueRepository = leagueRepository;
        }

        public IEnumerable<Club> GetClubs()
        {
            return _clubRepository.GetAll();
        }

        public PaginatorDataModel<ClubDataModel> GetForPaginator(int page, int perPage)
        {

            return _clubRepository.GetForPaginator(page, perPage, MapToDataModel);

        }

        public void Save(ClubViewModel footClub)
        {

            _clubRepository.Save(new Club
            {
                Name = footClub.Name,
                Stadium = footClub.Stadium,
                League = _leagueRepository.Get(footClub.League.Id),
                IdUserCreator = footClub.IdUserCreator,
            });
        }
        public void Delete(int id)
        {
            _clubRepository.Remove(id);
        }

        private ClubDataModel MapToDataModel(Club clubModel)
        => new ClubDataModel
        {
            id = clubModel.Id,
            IdUserCreator = clubModel.IdUserCreator,
            Name = clubModel.Name,
            Stadium = clubModel.Stadium,
            League = new ShortLeagueDataModel
            {
                IdUserCreator = clubModel.League.IdUserCreator,
                ShortName = clubModel.League.ShortName,

            }

        };

    }
}
