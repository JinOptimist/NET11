using DALInterfaces.Models;
using DALInterfaces.Repositories;
using DALInterfaces.Models.Entities;

namespace DALWrongDB.Repositories
{
    public class RockMemberRepository : IRockMemberRepository
    {
        private static List<RockMembers> _members = new List<RockMembers>(){
            new RockMembers("The Beatles", "Psychedelic Rock", 1994, 1956),
            new RockMembers("Queen", "Pop Rock", 1999, 1958),
            new RockMembers("John Bon Jovi", "Rock-N-Roll", 2001, 1973),
            new RockMembers("The Who", "Psychedelic Rock", 1988, 1963),
            new RockMembers("System Of Down", "Rock-N-Roll", 2003, 1993),
            new RockMembers("The Offspring", "Punk Rock", 2011, 1993),
            new RockMembers("System of a Down", "Hard Rock", 2001, 1973)
        };

    public IEnumerable<RockMembers> GetAll()
        {
            return _members;
        }

        public void Save(RockMembers member)
        {
            _members.Add(member);
        }

        public void Delete(int index)
        {
            _members.RemoveAt(index);
        }
    }
}
