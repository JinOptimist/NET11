using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models.RockHall
{
    public class IsNotPatrickSwayzeAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return (string)value != "Patrick Swayze";
        }

        public override string FormatErrorMessage(string name)
        {
            return "Come on, Man!!! He is an actor, not a musician. Everybody knows it!!!";
        }
    }
}
