using FoodDeliveryMvc.Data;
using FoodDeliveryMvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryMvc.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _db;

    public HomeController(ApplicationDbContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        var model = new MenuViewModel
        {
            Categories = await _db.Categories.Where(c => c.IsActive).ToListAsync(),
            FoodItems = await _db.FoodItems.Include(f => f.Category).Where(f => f.IsAvailable).Take(8).ToListAsync()
        };
        return View(model);
    }
}
