using DALInterfaces.Models;
using DALInterfaces.Repositories;

namespace DALWrongDB.Repositories
{
    public class RockMemberRepository : IRockMemberRepository
    {
        private static List<RockMember> _members = new List<RockMember>();

        public IEnumerable<RockMember> GetAll()
        {
            return _members;
        }

        public void Save(RockMember member)
        {
            var maxCurrentId = _members.Any()
                ? _members.Max(x => x.Id) : 0;
            member.Id = maxCurrentId + 1;
            _members.Add(member);
        }

        public void Delete(int id)
        {
            var entity = _members.First(x => x.Id == id);
            _members.Remove(entity);
        }
    }
}
