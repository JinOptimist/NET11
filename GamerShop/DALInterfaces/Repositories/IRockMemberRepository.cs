using DALInterfaces.Models;
using DALInterfaces.Models.Entities;

namespace DALInterfaces.Repositories
{
    public interface IRockMemberRepository
    {
        IEnumerable<RockMembers> GetAll();
        void Save(RockMembers member);

        void Delete(int index);
    }
}
