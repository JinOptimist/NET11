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

        public IEnumerable<ClubViewModel> GetClubs()
        {
            return _clubRepository.GetAll().Select(x => new ClubViewModel
            {
                Id = x.Id,
                IdUserCreator = x.IdUserCreator,
                Name = x.Name,
                Stadium = x.Stadium,
                League = new ShortLeagueViewModel 
                {
                    Id = x.League.Id,
                    ShortName = x.League.ShortName,
                    Country  = x.League.Country
                }
            }); ;
        }

        public PaginatorViewModel<ClubViewModel> GetForPaginator(int page, int perPage)
        {
           var dataMode =  _clubRepository.GetForPaginator(page, perPage, MapToDataModel);

            return MapToView(dataMode);

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
                ShortName = clubModel.League.ShortName,
                Id = clubModel.League.Id,
                Country = clubModel.League.Country

            }

        };

        private PaginatorViewModel<ClubViewModel> MapToView(PaginatorDataModel<ClubDataModel> dataModel)
        => new PaginatorViewModel<ClubViewModel>
        {
            Count = dataModel.Count,
            Page = dataModel.Page,
            PerPage = dataModel.PerPage,
            Items = dataModel.Items.Select(x => new ClubViewModel
            {
                IdUserCreator = x.IdUserCreator,
                Name = x.Name,
                Id = x.id,
                Stadium = x.Stadium,
                League = new ShortLeagueViewModel
                {
                    Id = x.League.Id,
                    ShortName = x.League.ShortName,
                    Country = x.League.Country
                }
            }).ToList(),
        };
    }
}
