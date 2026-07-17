using FoodDeliveryMvc.Data;
using FoodDeliveryMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryMvc.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = DbSeeder.AdminRole)]
public class UsersController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UsersController(UserManager<ApplicationUser> userManager) => _userManager = userManager;

    public IActionResult Index() => View(_userManager.Users.OrderBy(u => u.Email).ToList());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleRole(string userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return NotFound();

        if (await _userManager.IsInRoleAsync(user, role)) await _userManager.RemoveFromRoleAsync(user, role);
        else await _userManager.AddToRoleAsync(user, role);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null) await _userManager.DeleteAsync(user);
        return RedirectToAction(nameof(Index));
    }
}
