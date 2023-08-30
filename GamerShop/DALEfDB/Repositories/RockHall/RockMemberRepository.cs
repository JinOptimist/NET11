using DALInterfaces.Models.RockHall;
using DALInterfaces.Repositories.RockHall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALEfDB.Repositories.RockHall
{
    public class RockMemberRepository : BaseRepository<RockMember>, IRockMemberRepository
    {
        public RockMemberRepository(WebContext context) : base(context)
        {
        }

        public RockMemberPaginatorDataModel GetRockMemberPaginatorDataModel(int page, int perPage)
        {
            var count = _dbSet.Count();

            var rockMembers = _dbSet
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .Select(dbRockMember => new RockMember
                {
                    Id = dbRockMember.Id,
                    FullName = dbRockMember.FullName,
                    EntryYear = dbRockMember.EntryYear,
                    Genre = dbRockMember.Genre,
                    YearOfBirth = dbRockMember.YearOfBirth,
                    CreatorId = dbRockMember.CreatorId,
                }).ToList();
            
            return new RockMemberPaginatorDataModel
            {
                Count = count,
                Page = page,
                PerPage = perPage,
                RockMembers = rockMembers
            };

        }
    }
}
