using FoodDeliveryMvc.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryMvc.ViewModels;

public class CheckoutViewModel
{
    [Required, StringLength(120)]
    public string CustomerName { get; set; } = string.Empty;

    [Required, StringLength(180)]
    public string DeliveryAddress { get; set; } = string.Empty;

    [Required, Phone, StringLength(30)]
    public string PhoneNumber { get; set; } = string.Empty;

    public IReadOnlyList<CartItem> CartItems { get; set; } = new List<CartItem>();
    public decimal Total => CartItems.Sum(x => x.LineTotal);
}
