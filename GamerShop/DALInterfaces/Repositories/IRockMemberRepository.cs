using DALInterfaces.Models;

namespace DALInterfaces.Repositories
{
    public interface IRockMemberRepository
    {
        IEnumerable<RockMember> GetAll();
        void Save(RockMember member);

        void Delete(int id);
    }
}
