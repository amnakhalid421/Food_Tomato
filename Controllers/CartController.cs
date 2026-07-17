using FoodDeliveryMvc.Data;
using FoodDeliveryMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryMvc.Controllers;

[Authorize]
public class CartController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public CartController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
    {
        _db = db;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index() => View(await GetCartAsync());

    [HttpPost]
    public async Task<IActionResult> Add(int foodItemId, int quantity = 1)
    {
        var userId = _userManager.GetUserId(User)!;
        var item = await _db.CartItems.FirstOrDefaultAsync(c => c.UserId == userId && c.FoodItemId == foodItemId);
        if (item == null)
        {
            _db.CartItems.Add(new CartItem { UserId = userId, FoodItemId = foodItemId, Quantity = Math.Max(1, quantity) });
        }
        else
        {
            item.Quantity += Math.Max(1, quantity);
        }

        await _db.SaveChangesAsync();
        return Json(await CartSummaryAsync(userId, "Item added to cart."));
    }

    [HttpPost]
    public async Task<IActionResult> UpdateQuantity(int cartItemId, int quantity)
    {
        var userId = _userManager.GetUserId(User)!;
        var item = await _db.CartItems.Include(c => c.FoodItem).FirstOrDefaultAsync(c => c.Id == cartItemId && c.UserId == userId);
        if (item == null) return NotFound();

        if (quantity <= 0) _db.CartItems.Remove(item);
        else item.Quantity = quantity;

        await _db.SaveChangesAsync();
        return Json(await CartSummaryAsync(userId, "Cart updated."));
    }

    [HttpPost]
    public async Task<IActionResult> Remove(int cartItemId)
    {
        var userId = _userManager.GetUserId(User)!;
        var item = await _db.CartItems.FirstOrDefaultAsync(c => c.Id == cartItemId && c.UserId == userId);
        if (item == null) return NotFound();

        _db.CartItems.Remove(item);
        await _db.SaveChangesAsync();
        return Json(await CartSummaryAsync(userId, "Item removed."));
    }

    private async Task<List<CartItem>> GetCartAsync()
    {
        var userId = _userManager.GetUserId(User)!;
        return await _db.CartItems.Include(c => c.FoodItem).ThenInclude(f => f!.Category).Where(c => c.UserId == userId).ToListAsync();
    }

    private async Task<object> CartSummaryAsync(string userId, string message)
    {
        var items = await _db.CartItems.Include(c => c.FoodItem).Where(c => c.UserId == userId).ToListAsync();
        return new { success = true, message, count = items.Sum(x => x.Quantity), total = items.Sum(x => x.LineTotal) };
    }
}
