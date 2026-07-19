# Tomato Express - ASP.NET Core MVC Food Delivery Web App

A full-stack food delivery web application built using ASP.NET Core MVC, Entity Framework Core, and SQL Server.

Tomato Express allows customers to explore food items, manage their shopping carts, place orders, and track their order history. It also provides an admin dashboard for managing food items, categories, and orders.

This project was developed as part of my journey into full-stack web development, focusing on real-world concepts like authentication, authorization, database relationships, and dynamic user interactions.

# Developers

### Amna Khalid421
### Nida Noor18



# Features 

### Customer Features

- User registration and login
- Secure authentication using ASP.NET Core Identity
- Browse food items and categories
- View food details
- Add items to shopping cart
- Update cart using AJAX
- Place orders
- View order history

### Admin Features

- Role-based authorization
- Admin dashboard
- Manage food items
- Manage categories
- Manage customer orders
- Control application data

# Screenshots

### Home page

<img width="1600" height="688" alt="WhatsApp Image 2026-07-17 at 7 21 40 PM" src="https://github.com/user-attachments/assets/77668041-3333-4d3c-b772-a17cda920c21" />



### Food Items

<img width="1413" height="826" alt="WhatsApp Image 2026-07-17 at 7 21 41 PM (1)" src="https://github.com/user-attachments/assets/232304d0-8a45-4344-912b-7ce05bf3de35" />




### Shopping Cart

<img width="1600" height="721" alt="WhatsApp Image 2026-07-17 at 7 21 41 PM" src="https://github.com/user-attachments/assets/1c121613-d436-4cdc-8b63-c4c54f2a59f2" />



### Order histroy

<img width="1600" height="501" alt="WhatsApp Image 2026-07-17 at 7 21 41 PM (2)" src="https://github.com/user-attachments/assets/e998b6a4-ddb0-492d-ab9a-26e880df3b52" />



### Admin Dashboard

<img width="1600" height="571" alt="WhatsApp Image 2026-07-17 at 7 21 42 PM" src="https://github.com/user-attachments/assets/93586af2-2261-42b2-aa13-3c24833872a1" />



# Technologies Used

### Backend
- ASP.NET Core MVC 
- C#
- Entity Framework Core
- ASP.NET Core Identity

### Frontend
- HTML, CSS, JavaScript, jQuery
- Bootstrap 
- Bootstrap Icons
- AJAX

### Database
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
```
git clone https://github.com/amnakhalid421/Tomato-Express.git
```


2. Open the project

Open the  ``` .sln ``` file in VS


3. Configure Database Connection

Update the connection string in:

```
appsettings.json
```

4. Apply Database Migration

Run 

```
Update-Database
```

5. Run the application

Press:

```
Ctrl + F5
```

or run:

```
dotnet run
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

## Learning Outcomes

Through this project, I learned:

- Building complete ASP.NET Core MVC applications
- Implementing authentication and authorization
- Designing database relationships using Entity Framework Core
- Working with SQL Server databases
- Creating dynamic user experiences using AJAX
- Debugging issues across multiple application layers
- Understanding how frontend and backend components interact

## Future Improvements

Possible future enhancements:

- Online payment integration
- Real-time order tracking
- Email notifications
- Cloud deployment
- Mobile application support

## License

This project is developed for educational and learning purposes.
