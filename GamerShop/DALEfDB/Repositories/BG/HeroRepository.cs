using DALInterfaces.DataModels.BG;
using DALInterfaces.Models;
using DALInterfaces.Models.BG;
using DALInterfaces.Repositories.BG;

namespace DALEfDB.Repositories.BG
{
    public class HeroRepository : BaseRepository<Hero>, IHeroRepository
    {
        public HeroRepository(WebContext context) : base(context) { }
        public HeroPaginatorDataModel GetHeroPaginatorDataModel(int page, int perPage)
        {
            var count = _dbSet.Count();
            var heros = _dbSet
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .Select(dbHero => new HeroDataModel()
                {
                    Id = dbHero.Id,
                   Bone = dbHero.Bone,
                   Name = dbHero.Name,
                   CreatorId = dbHero.UserCreator.Id,
                   Class = dbHero.Class.Name,
                   Race = dbHero.Race.Name,
                   Subrace = dbHero.Subrace.Name,
                   Оrigin = dbHero.Оrigin.History

                })
                .ToList();

            return new HeroPaginatorDataModel()
            {
                Count = count,
                Heros = heros,
                Page = page,
                PerPage = perPage,
            };
        }

    }

}
