using FoodDeliveryMvc.Data;
using FoodDeliveryMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryMvc.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = DbSeeder.AdminRole)]
public class CategoriesController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoriesController(ApplicationDbContext db) => _db = db;

    public async Task<IActionResult> Index() => View(await _db.Categories.OrderBy(c => c.Name).ToListAsync());

    public IActionResult Create() => View(new Category());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Category category)
    {
        if (!ModelState.IsValid) return View(category);
        _db.Categories.Add(category);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var category = await _db.Categories.FindAsync(id);
        return category == null ? NotFound() : View(category);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Category category)
    {
        if (id != category.Id) return NotFound();
        if (!ModelState.IsValid) return View(category);
        _db.Update(category);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _db.Categories.FindAsync(id);
        if (category != null)
        {
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
