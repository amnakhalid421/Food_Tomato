using FoodDeliveryMvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryMvc.Data;

public static class DbSeeder
{
    public const string AdminRole = "Admin";
    public const string CustomerRole = "Customer";

    public static async Task SeedAsync(IServiceProvider services)
    {
        var db = services.GetRequiredService<ApplicationDbContext>();
        await db.Database.MigrateAsync();

        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        foreach (var role in new[] { AdminRole, CustomerRole })
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        await CreateUserAsync(userManager, "admin@foodmvc.com", "Admin@123", "System Admin", AdminRole);
        await CreateUserAsync(userManager, "customer@foodmvc.com", "Customer@123", "Demo Customer", CustomerRole);

        if (await db.Categories.AnyAsync())
        {
            return;
        }

        var categories = new[]
        {
            new Category { Name = "Salad", ImageUrl = "/images/menu_1.png" },
            new Category { Name = "Rolls", ImageUrl = "/images/menu_2.png" },
            new Category { Name = "Deserts", ImageUrl = "/images/menu_3.png" },
            new Category { Name = "Sandwich", ImageUrl = "/images/menu_4.png" },
            new Category { Name = "Cake", ImageUrl = "/images/menu_5.png" },
            new Category { Name = "Pure Veg", ImageUrl = "/images/menu_6.png" },
            new Category { Name = "Pasta", ImageUrl = "/images/menu_7.png" },
            new Category { Name = "Noodles", ImageUrl = "/images/menu_8.png" }
        };

        db.Categories.AddRange(categories);
        await db.SaveChangesAsync();

        var items = new List<(string Name, decimal Price, string Category, string Image)>
        {
            ("Greek salad", 12, "Salad", "food_1.png"), ("Veg salad", 18, "Salad", "food_2.png"), ("Clover Salad", 16, "Salad", "food_3.png"), ("Chicken Salad", 24, "Salad", "food_4.png"),
            ("Lasagna Rolls", 14, "Rolls", "food_5.png"), ("Peri Peri Rolls", 12, "Rolls", "food_6.png"), ("Chicken Rolls", 20, "Rolls", "food_7.png"), ("Veg Rolls", 15, "Rolls", "food_8.png"),
            ("Ripple Ice Cream", 14, "Deserts", "food_9.png"), ("Fruit Ice Cream", 22, "Deserts", "food_10.png"), ("Jar Ice Cream", 10, "Deserts", "food_11.png"), ("Vanilla Ice Cream", 12, "Deserts", "food_12.png"),
            ("Chicken Sandwich", 12, "Sandwich", "food_13.png"), ("Vegan Sandwich", 18, "Sandwich", "food_14.png"), ("Grilled Sandwich", 16, "Sandwich", "food_15.png"), ("Bread Sandwich", 24, "Sandwich", "food_16.png"),
            ("Cup Cake", 14, "Cake", "food_17.png"), ("Vegan Cake", 12, "Cake", "food_18.png"), ("Butterscotch Cake", 20, "Cake", "food_19.png"), ("Sliced Cake", 15, "Cake", "food_20.png"),
            ("Garlic Mushroom", 14, "Pure Veg", "food_21.png"), ("Fried Cauliflower", 22, "Pure Veg", "food_22.png"), ("Mix Veg Pulao", 10, "Pure Veg", "food_23.png"), ("Rice Zucchini", 12, "Pure Veg", "food_24.png"),
            ("Cheese Pasta", 12, "Pasta", "food_25.png"), ("Tomato Pasta", 18, "Pasta", "food_26.png"), ("Creamy Pasta", 16, "Pasta", "food_27.png"), ("Chicken Pasta", 24, "Pasta", "food_28.png"),
            ("Butter Noodles", 14, "Noodles", "food_29.png"), ("Veg Noodles", 12, "Noodles", "food_30.png"), ("Somen Noodles", 20, "Noodles", "food_31.png"), ("Cooked Noodles", 15, "Noodles", "food_32.png")
        };

        var categoryMap = await db.Categories.ToDictionaryAsync(c => c.Name, c => c.Id);
        db.FoodItems.AddRange(items.Select(item => new FoodItem
        {
            Name = item.Name,
            Price = item.Price,
            CategoryId = categoryMap[item.Category],
            ImageUrl = $"/images/{item.Image}",
            Description = "Freshly prepared with quality ingredients and delivered hot to your door."
        }));

        await db.SaveChangesAsync();
    }

    private static async Task CreateUserAsync(UserManager<ApplicationUser> userManager, string email, string password, string fullName, string role)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
        {
            user = new ApplicationUser { UserName = email, Email = email, FullName = fullName, EmailConfirmed = true, Address = "Demo delivery address" };
            await userManager.CreateAsync(user, password);
        }

        if (!await userManager.IsInRoleAsync(user, role))
        {
            await userManager.AddToRoleAsync(user, role);
        }
    }
}
