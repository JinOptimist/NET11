using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models.Football
{
    public class FootballClubViewModel<T>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Stadium { get; set; }
        public string CreatorName { get; set; }
        [Required]
        public T FootballLeagueinfo { get; set; }
        public IEnumerable<int> SelectedLigue { get; set; }

    }

}
