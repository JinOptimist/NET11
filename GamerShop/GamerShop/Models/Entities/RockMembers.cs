using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GamerShop.Models.Entities
{
    public class RockMembers
    {
        public RockMembers(string fullName, string genre, int entryYear, int yearOfBirth)
        {
            FullName = fullName;
            Genre = genre;
            EntryYear = entryYear;
            YearOfBirth = yearOfBirth;
        }

        public string FullName { get; set; }
        public string Genre { get; set; }
        public int EntryYear { get; set; }
        public int YearOfBirth { get; set; }
    }
}
