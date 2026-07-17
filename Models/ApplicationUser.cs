using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryMvc.Models;

public class ApplicationUser : IdentityUser
{
    [Required, StringLength(80)]
    public string FullName { get; set; } = string.Empty;

    [StringLength(180)]
    public string? Address { get; set; }
}
