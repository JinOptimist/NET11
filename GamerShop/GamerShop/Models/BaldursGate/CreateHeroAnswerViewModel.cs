using GamerShop.Models.CustomValidationAttribute;
using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models.BaldursGate
{
    public class CreateHeroAnswerViewModel
    {
        //public int Id { get; set; }
        //public IFormFile Avatar { get; set; }
        //[Required]
        //[AtLeastOneCapitalAtLeastOneNotCapital(ErrorMessage = "Хотя бы одну большую букву")]
        public string Name { get; set; }
        public int ClassId { get; set; }
        public int RaceId { get; set; }
        public int SubraceId { get; set; }
        public int OriginId { get; set; }
        //[Required]
        public int Bone { get; set; }
    }
}
