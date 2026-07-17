using FoodDeliveryMvc.Data;
using FoodDeliveryMvc.Models;
using FoodDeliveryMvc.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryMvc.Controllers;

[Authorize]
public class CheckoutController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public CheckoutController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
    {
        _db = db;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        var cart = await GetCartAsync(user!.Id);
        return View(new CheckoutViewModel { CustomerName = user.FullName, DeliveryAddress = user.Address ?? string.Empty, PhoneNumber = user.PhoneNumber ?? string.Empty, CartItems = cart });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> PlaceOrder(CheckoutViewModel model)
    {
        var userId = _userManager.GetUserId(User)!;
        var cart = await GetCartAsync(userId);
        if (!cart.Any()) ModelState.AddModelError(string.Empty, "Your cart is empty.");
        if (!ModelState.IsValid)
        {
            model.CartItems = cart;
            return View("Index", model);
        }

        var order = new Order
        {
            UserId = userId,
            CustomerName = model.CustomerName,
            DeliveryAddress = model.DeliveryAddress,
            PhoneNumber = model.PhoneNumber,
            TotalAmount = cart.Sum(c => c.LineTotal),
            Status = OrderStatus.FoodProcessing,
            OrderDetails = cart.Select(c => new OrderDetail { FoodItemId = c.FoodItemId, Quantity = c.Quantity, UnitPrice = c.FoodItem!.Price }).ToList()
        };
        order.Payment = new Payment { Amount = order.TotalAmount, IsPaid = false };

        _db.Orders.Add(order);
        _db.CartItems.RemoveRange(cart);
        await _db.SaveChangesAsync();
        return RedirectToAction("Details", "Orders", new { id = order.Id });
    }

    private Task<List<CartItem>> GetCartAsync(string userId) =>
        _db.CartItems.Include(c => c.FoodItem).Where(c => c.UserId == userId).ToListAsync();
}
