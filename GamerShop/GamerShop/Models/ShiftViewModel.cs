using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models;

public class ShiftViewModel
{
    [Required]
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "ShiftStart is required")]
    public string ShiftStart { get; set; }
    
    [Required(ErrorMessage = "ShiftFinish is required")]
    public string ShiftFinish { get; set; }
    
    [Required(ErrorMessage = "Date is required")]
    public string Date { get; set; }
    
    [Required(ErrorMessage = "Salary is required")]
    public string Salary { get; set; }
}