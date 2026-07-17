using FoodDeliveryMvc.Data;
using FoodDeliveryMvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryMvc.Controllers;

public class MenuController : Controller
{
    private readonly ApplicationDbContext _db;

    public MenuController(ApplicationDbContext db) => _db = db;

    public async Task<IActionResult> Index(int? categoryId, string? search)
    {
        var model = await BuildMenuAsync(categoryId, search);
        return View(model);
    }

    public async Task<IActionResult> Details(int id)
    {
        var item = await _db.FoodItems.Include(f => f.Category).FirstOrDefaultAsync(f => f.Id == id && f.IsAvailable);
        return item == null ? NotFound() : View(item);
    }

    [HttpGet]
    public async Task<IActionResult> Search(int? categoryId, string? search)
    {
        var model = await BuildMenuAsync(categoryId, search);
        return PartialView("_FoodCards", model.FoodItems);
    }

    private async Task<MenuViewModel> BuildMenuAsync(int? categoryId, string? search)
    {
        var query = _db.FoodItems.Include(f => f.Category).Where(f => f.IsAvailable);
        if (categoryId.HasValue) query = query.Where(f => f.CategoryId == categoryId.Value);
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(f => f.Name.Contains(search) || f.Description.Contains(search) || f.Category!.Name.Contains(search));
        }

        return new MenuViewModel
        {
            Categories = await _db.Categories.Where(c => c.IsActive).ToListAsync(),
            FoodItems = await query.OrderBy(f => f.Name).ToListAsync(),
            CategoryId = categoryId,
            Search = search
        };
    }
}
