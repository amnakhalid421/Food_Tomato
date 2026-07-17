using FoodDeliveryMvc.Data;
using FoodDeliveryMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryMvc.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = DbSeeder.AdminRole)]
public class OrdersController : Controller
{
    private readonly ApplicationDbContext _db;

    public OrdersController(ApplicationDbContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        var orders = await _db.Orders.Include(o => o.User).OrderByDescending(o => o.CreatedAt).ToListAsync();
        return View(orders);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateStatus(int orderId, OrderStatus status)
    {
        var order = await _db.Orders.FindAsync(orderId);
        if (order == null) return NotFound();
        order.Status = status;
        await _db.SaveChangesAsync();
        return Json(new { success = true, status = order.Status.ToString() });
    }
}
