using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryMvc.Models;

public class FoodItem
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required, StringLength(500)]
    public string Description { get; set; } = string.Empty;

    [Column(TypeName = "decimal(10,2)")]
    [Range(0.01, 100000)]
    public decimal Price { get; set; }

    [StringLength(180)]
    public string ImageUrl { get; set; } = "/images/food_1.png";

    public bool IsAvailable { get; set; } = true;

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
