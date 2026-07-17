using FoodDeliveryMvc.Data;
using FoodDeliveryMvc.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryMvc.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = DbSeeder.AdminRole)]
public class DashboardController : Controller
{
    private readonly ApplicationDbContext _db;

    public DashboardController(ApplicationDbContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        var model = new AdminDashboardViewModel
        {
            TotalUsers = await _db.Users.CountAsync(),
            TotalOrders = await _db.Orders.CountAsync(),
            TotalFoodItems = await _db.FoodItems.CountAsync(),
            TotalRevenue = await _db.Orders.Where(o => o.Status != Models.OrderStatus.Cancelled).SumAsync(o => (decimal?)o.TotalAmount) ?? 0
        };
        return View(model);
    }
}
