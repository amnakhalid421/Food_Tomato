# Tomato Express - ASP.NET Core MVC Food Delivery System

Tomato Express is a clean ASP.NET Core MVC food delivery application for academic/project submission. It uses SQL Server, Entity Framework Core, ASP.NET Core Identity, Bootstrap 5, JavaScript, jQuery, and AJAX.

## Technologies Used

- ASP.NET Core MVC 8
- C#
- Entity Framework Core
- SQL Server / SQL Server Express
- ASP.NET Core Identity
- Razor Views
- Bootstrap 5
- Bootstrap Icons
- HTML, CSS, JavaScript, jQuery
- AJAX

## Folder Structure

```text
FoodDeliveryMvc/
  Areas/Admin/Controllers      Admin dashboard, food, category, order, user management
  Areas/Admin/Views            Admin Razor pages
  Controllers                  Customer/public MVC controllers
  Data                         DbContext, seed data, EF migrations
  Models                       Application entities and Identity user
  ViewModels                   Page/form view models
  Views                        Customer/public Razor pages
  wwwroot/css                  Custom site styling
  wwwroot/js                   jQuery AJAX behavior
  wwwroot/lib                  Local Bootstrap, Bootstrap Icons, and jQuery files
  wwwroot/images               Required food/category/UI images
```

## SQL Server Connection

The connection string is in `appsettings.json`:

```json
"DefaultConnection": "Server=.\\SQLEXPRESS;Database=FoodDeliveryMvcDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Encrypt=False"
```

Change `Server=.\\SQLEXPRESS` if your SQL Server instance has a different name.

## Setup

1. Install .NET 8 SDK.
2. Install SQL Server Express or another SQL Server edition.
3. Open a terminal in the project folder.
4. Restore packages:

```powershell
dotnet restore
```

5. Apply migrations:

```powershell
dotnet ef database update
```

6. Run the project:

```powershell
dotnet run --urls http://localhost:5088
```

7. Open:

```text
http://localhost:5088
```

The application seeds roles, default users, categories, and food items on startup.

## Default Accounts

Admin:

```text
Email: admin@foodmvc.com
Password: Admin@123
```

Customer:

```text
Email: customer@foodmvc.com
Password: Customer@123
```

## Implemented Requirements Checklist

- ASP.NET Core MVC web application
- SQL Server database
- Entity Framework Core DbContext and migrations
- HTML, CSS, Bootstrap 5
- JavaScript and jQuery
- AJAX add-to-cart, cart update, cart remove, menu search/filter, order status update
- Authentication with register, login, logout, password validation
- Role-based authorization for Admin and Customer
- Customer homepage, menu, details, cart, checkout, order history, order status
- Admin dashboard, food CRUD, category CRUD, user management, order management
- Responsive UI for desktop, tablet, and mobile
- Local frontend libraries in `wwwroot/lib`

## Cleanup Notes

The final project folder keeps only relevant ASP.NET Core MVC files. Build outputs, ZIP files, old frontend/backend stack files, cache files, and temporary files are excluded from the cleaned project.

## Remaining Limitations

- Food item image upload is handled by entering an image URL/path; a full file upload workflow can be added later.
- Payment is modeled for cash-on-delivery/demo use and does not integrate with a real payment gateway.
