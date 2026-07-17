using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryMvc.Models;

public class OrderDetail
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order? Order { get; set; }
    public int FoodItemId { get; set; }
    public FoodItem? FoodItem { get; set; }
    public int Quantity { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal UnitPrice { get; set; }

    [NotMapped]
    public decimal LineTotal => UnitPrice * Quantity;
}
