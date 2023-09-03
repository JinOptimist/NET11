using DALInterfaces.Models.RockHall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALInterfaces.DataModels.RockHall
{
    public class RockMemberDataModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Genre { get; set; }
        public int EntryYear { get; set; }
        public int YearOfBirth { get; set; }
        public int CreatorId { get; set; }
        public string? CurrentBandName { get; set; }
    }
}
