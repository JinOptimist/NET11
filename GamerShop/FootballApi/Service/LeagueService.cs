using FootballApi.DatabaseStuff.DataModels;
using FootballApi.DatabaseStuff.DataModels.Football;
using FootballApi.DatabaseStuff.Models;
using FootballApi.DatabaseStuff.Repositories.Leagues;
using FootballApi.VIewModels;

namespace FootballApi.Service
{
    public class LeagueService : ILeagueService
    {
        private ILeagueRepository _leagueRepository;
        public LeagueService(ILeagueRepository leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }
        public int Count()
        {
            return _leagueRepository.Count();
        }

        public void Delete(int id)
        {
            _leagueRepository.Remove(id);
        }

        public IEnumerable<ShortLeagueViewModel> Get(int count, int skipCount)
        => _leagueRepository.Get(count, skipCount).Select(x=> new ShortLeagueViewModel
        { 
         ShortName = x.ShortName,
         Country = x.Country,
         Id = x.Id,

        }).ToList();

        public PaginatorViewModel<LeagueViewModel> GetForPaginator(int page, int perPage)
        {
             var dataModel = _leagueRepository.GetForPaginator(page, perPage, MapToDataModel);
             return MapToView(dataModel);       
        }

        public IEnumerable<LeagueViewModel> GetLeagues()
        {
            return _leagueRepository.GetAll().Select(x => new LeagueViewModel
            {
                Country = x.Country,
                Id = x.Id,
                IdUserCreator = x.IdUserCreator,
                Name = x.Name,
                ShortName = x.ShortName
            }).ToList();

        }

        public IEnumerable<ShortLeagueViewModel> GetLimetedAmount(int amount)
        => _leagueRepository.GetLimetedAmount(amount).Select(x => new ShortLeagueViewModel
        {
            ShortName = x.ShortName,
            Id = x.Id,
            Country = x.Country,
        }).ToList();

        public void Save(LeagueViewModel league)
        {
            _leagueRepository.Save(new League
            {
                Country = league.Country,
                IdUserCreator = league.IdUserCreator,
                Name = league.Name,
                ShortName = league.ShortName

            });
        }

        private LeagueDataModel MapToDataModel(League league)
        => new LeagueDataModel
        {
            ShortName = league.ShortName,
            Country = league.Country,
            Name = league.Name,
            IdUserCreator = league.IdUserCreator,
            Id = league.Id,
        };

        private PaginatorViewModel<LeagueViewModel> MapToView(PaginatorDataModel<LeagueDataModel> dataModel)
        => new PaginatorViewModel<LeagueViewModel>
        {
            Count = dataModel.Count,
            Page = dataModel.Page,
            PerPage = dataModel.PerPage,
            Items = dataModel.Items.Select(x => new LeagueViewModel
            {
                Country = x.Country,
                Id = x.Id,
                Name = x.Name,
                IdUserCreator = x.IdUserCreator,
                ShortName = x.ShortName,


            }).ToList(),

        };
    }
}
