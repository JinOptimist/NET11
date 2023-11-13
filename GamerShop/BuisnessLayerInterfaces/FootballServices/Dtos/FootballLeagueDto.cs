using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerInterfaces.FootballServices.Dtos
{
    public class FootballLeagueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Country { get; set; }
        public int IdUserCreator { get; set; }
    }
}
