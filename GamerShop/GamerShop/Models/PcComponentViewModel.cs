using System.ComponentModel.DataAnnotations;

namespace GamerShop.Models;

public class PcComponentViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Category is required")]
    public string Category { get; set; }
    
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Price is required")]
    public decimal Price { get; set; }

}