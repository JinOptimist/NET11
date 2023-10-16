using GamerShop.Controllers.Attributes;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models.Football
{
    public class FootballClubViewModel<T>
    {
        [Filter]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Stadium { get; set; }
        
        public string CreatorName { get; set; }
        [Filter]
        [Required]
        public T FootballLeagueinfo { get; set; }
        public IEnumerable<int> SelectedLigue { get; set; }

        public IEnumerable<Hashtable> SelectedFilters { get; set; }
    }

}
