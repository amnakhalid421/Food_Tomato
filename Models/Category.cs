using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryMvc.Models;

public class Category
{
    public int Id { get; set; }

    [Required, StringLength(60)]
    public string Name { get; set; } = string.Empty;

    [StringLength(180)]
    public string? ImageUrl { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
}
