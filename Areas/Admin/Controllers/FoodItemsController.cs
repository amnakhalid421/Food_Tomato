using FoodDeliveryMvc.Data;
using FoodDeliveryMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryMvc.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = DbSeeder.AdminRole)]
public class FoodItemsController : Controller
{
    private readonly ApplicationDbContext _db;

    public FoodItemsController(ApplicationDbContext db) => _db = db;

    public async Task<IActionResult> Index() => View(await _db.FoodItems.Include(f => f.Category).OrderBy(f => f.Name).ToListAsync());

    public async Task<IActionResult> Create()
    {
        await LoadCategoriesAsync();
        return View(new FoodItem());
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(FoodItem foodItem)
    {
        if (!ModelState.IsValid)
        {
            await LoadCategoriesAsync();
            return View(foodItem);
        }

        _db.FoodItems.Add(foodItem);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var item = await _db.FoodItems.FindAsync(id);
        if (item == null) return NotFound();
        await LoadCategoriesAsync();
        return View(item);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, FoodItem foodItem)
    {
        if (id != foodItem.Id) return NotFound();
        if (!ModelState.IsValid)
        {
            await LoadCategoriesAsync();
            return View(foodItem);
        }

        _db.Update(foodItem);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _db.FoodItems.FindAsync(id);
        if (item != null)
        {
            _db.FoodItems.Remove(item);
            await _db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    private async Task LoadCategoriesAsync()
    {
        ViewBag.Categories = new SelectList(await _db.Categories.OrderBy(c => c.Name).ToListAsync(), "Id", "Name");
    }
}
