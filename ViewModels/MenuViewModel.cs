using FoodDeliveryMvc.Models;

namespace FoodDeliveryMvc.ViewModels;

public class MenuViewModel
{
    public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    public IEnumerable<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
    public int? CategoryId { get; set; }
    public string? Search { get; set; }
}
