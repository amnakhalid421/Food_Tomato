using FoodDeliveryMvc.Data;
using FoodDeliveryMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryMvc.Controllers;

[Authorize]
public class OrdersController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public OrdersController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
    {
        _db = db;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User)!;
        var orders = await _db.Orders.Where(o => o.UserId == userId).OrderByDescending(o => o.CreatedAt).ToListAsync();
        return View(orders);
    }

    public async Task<IActionResult> Details(int id)
    {
        var userId = _userManager.GetUserId(User)!;
        var order = await _db.Orders.Include(o => o.OrderDetails).ThenInclude(d => d.FoodItem).FirstOrDefaultAsync(o => o.Id == id && o.UserId == userId);
        return order == null ? NotFound() : View(order);
    }
}
