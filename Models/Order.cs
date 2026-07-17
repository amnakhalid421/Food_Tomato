using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryMvc.Models;

public enum OrderStatus
{
    Pending,
    FoodProcessing,
    OutForDelivery,
    Delivered,
    Cancelled
}

public class Order
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }

    [Required, StringLength(120)]
    public string CustomerName { get; set; } = string.Empty;

    [Required, StringLength(180)]
    public string DeliveryAddress { get; set; } = string.Empty;

    [Required, StringLength(30)]
    public string PhoneNumber { get; set; } = string.Empty;

    [Column(TypeName = "decimal(10,2)")]
    public decimal TotalAmount { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public Payment? Payment { get; set; }
}
