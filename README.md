# Tomato Express - ASP.NET Core MVC Food Delivery Web App

A full-stack food delivery web application built using ASP.NET Core MVC, Entity Framework Core, and SQL Server.

Tomato Express allows customers to explore food items, manage their shopping carts, place orders, and track their order history. It also provides an admin dashboard for managing food items, categories, and orders.

This project was developed as part of my journey into full-stack web development, focusing on real-world concepts like authentication, authorization, database relationships, and dynamic user interactions.

## Developers

Nida Noor18
Amna Khalid421


## Features 

##Customer Features

User registration and login
Secure authentication using ASP.NET Core Identity
Browse food items and categories
View food details
Add items to shopping cart
Update cart using AJAX
Place orders
View order history

## Admin Features

Role-based authorization
Admin dashboard
Manage food items
Manage categories
Manage customer orders
Control application data

## Screenshots

## Home page



## Food Items



## Shopping Cart



## Order histroy




## Admin Dashboard




## Technologies Used

## Backend
- ASP.NET Core MVC 
- C#
- Entity Framework Core
- ASP.NET Core Identity

## Frontend
- HTML, CSS, JavaScript, jQuery
- Bootstrap 
- Bootstrap Icons
- AJAX

## Database
- Entity Framework Core Code First Approach
- SQL Server / SQL Server Express

  

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

## Project Architecture

The application follows the MVC (Model-View-Controller) architecture.

``` text
Tomato Express

│
├── Controllers
│   └── Handles requests and application logic
│
├── Models
│   └── Database entities and business models
│
├── Views
│   └── User interface pages
│
├── Data
│   └── Database context and configurations
│
├── wwwroot
│   └── CSS, JavaScript, images, and static files
│
└── Migrations
    └── Entity Framework database migrations
```

## Database Design

The application uses SQL Server with Entity Framework Core.

Main entities include:

Users
Roles
Food Items
Categories
Cart Items
Orders
Order Details
Entity relationships are managed using Entity Framework Core.


## Setup

1. Install VS 
2. Install .NET SDK.
3. Install SQL Server Express or another SQL Server edition.

## Steps

1. Clone the repo
```powershell
git clone 


```


2. 


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
