using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryMvc.Models;

public class Payment
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order? Order { get; set; }

    [StringLength(40)]
    public string Method { get; set; } = "CashOnDelivery";

    [Column(TypeName = "decimal(10,2)")]
    public decimal Amount { get; set; }

    public bool IsPaid { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
