# 🛍️ Innovi Wear Store - E-Commerce Web Application

## 📋 Overview

Innovi Wear Store is a modern, fully-featured e-commerce web application built with ASP.NET Core MVC. It provides a complete online shopping experience with user authentication, product management, shopping cart, order processing, and more.

### ✨ Live Demo Features

- 🏠 **Public Homepage** - Browse products without login
- 🔐 **User Authentication** - Secure login/register system
- 🛒 **Shopping Cart** - Add, remove, and update quantities
- 📦 **Order Management** - Place orders and view history
- 👤 **User Profile** - Manage personal information
- 🔍 **Search Functionality** - Search by name or category
- 📱 **Responsive Design** - Works on all devices
- 💳 **Multiple Payment Methods** - Credit Card, Cash on Delivery, Mobile Wallet

## 🚀 Technologies Used

### Backend
- **ASP.NET Core MVC 8.0** - Web framework
- **Entity Framework Core** - ORM for database operations
- **SQL Server** - Database management
- **Identity Framework** - User authentication and authorization

### Frontend
- **HTML5 & CSS3** - Structure and styling
- **Bootstrap 5** - Responsive layout
- **jQuery & AJAX** - Dynamic interactions
- **Font Awesome 6** - Icons and graphics
- **Google Fonts** - Typography

### Development Tools
- **Visual Studio 2022** - IDE
- **Git & GitHub** - Version control
- **SQL Server Management Studio** - Database management

## 📁 Project Structure
InnoviWearStore/
├── Controllers/
│ ├── HomeController.cs # Home, Products, Categories
│ ├── AccountController.cs # Login, Register, Profile
│ ├── CartController.cs # Shopping cart operations
│ └── OrderController.cs # Order management
├── Models/
│ ├── User.cs # User model
│ ├── Product.cs # Product model
│ ├── CartItem.cs # Cart item model
│ ├── Order.cs # Order model
│ └── OrderItem.cs # Order item model
├── ViewModels/
│ ├── LoginViewModel.cs
│ ├── RegisterViewModel.cs
│ ├── ProfileViewModel.cs
│ ├── CheckoutViewModel.cs
│ └── CategoryViewModel.cs
├── Views/
│ ├── Home/ # Home pages
│ ├── Account/ # Auth pages
│ ├── Cart/ # Cart pages
│ └── Shared/ # Layout and partials
├── Data/
│ └── ApplicationDbContext.cs # Database context
├── wwwroot/
│ ├── css/ # Stylesheets
│ ├── js/ # JavaScript files
│ └── images/ # Image assets
├── Migrations/ # EF Core migrations
├── appsettings.json # Configuration
└── Program.cs # Application entry point
