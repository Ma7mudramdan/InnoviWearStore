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

## 🛠️ Getting Started

1. Clone the repo: `git clone https://github.com/Ma7mudramdan/InnoviWearStore.git`
2. Navigate to the project folder: `cd InnoviWearStore`
3. Restore packages: `dotnet restore`
4. Update connection string in `appsettings.json`
5. Run the application: `dotnet run`
6. Open the URL shown in the console (typically `https://localhost:5001`).

---

## Project structure

- `Program.cs` — startup, middleware and DI  
- `Controllers` — API-like endpoints and helpers (search feed, cart actions)  
- `Views` / `Pages` — Razor pages and shared layout (`Views/Shared/_Layout.cshtml`)  
- `wwwroot/css` — global `site.css` plus page-specific styles  
- `wwwroot/js` — client-side scripts (e.g., `site.js`)  
- `Data` — DbContext, migrations, `DbSeeder`  
- `Models` — domain models (Product, CartItem, Order, User, ...)  
- `ViewModels` — DTOs and page view models

---

## Development notes

- Global styling lives in `wwwroot/css/site.css`. Page files (e.g., `home.css`) refine UI.  
- Navbar search loads a product feed from `/Home/GetAllProducts` and performs client-side filtering for instant results; use `/Home/SearchResults` for full server-side queries.  
- Authentication handled by `Controllers/AccountController.cs` with views in `Views/Account`.  
- Admin UI is under `Views/Admin` and controlled by `AdminController`.

---

## Useful commands

- Run: `dotnet run`  
- Add EF migration: `dotnet ef migrations add <Name>`  
- Apply EF migrations: `dotnet ef database update`  
- Tests: `dotnet test` (if tests exist)

---

## Deployment

Deploy like any ASP.NET Core app (Azure App Service, IIS, Docker). Use environment variables or platform settings for production secrets. For Docker, use a multi-stage Dockerfile targeting `mcr.microsoft.com/dotnet/aspnet:8.0`.

---

## Contributing

Follow `.editorconfig` and `CONTRIBUTING.md`. Keep PRs focused and include migrations and seed updates when changing models.

Suggested flow:

1. Fork → feature branch `feat/xyz` → commit → PR against `master`.

---

## Troubleshooting

- DB errors: check `DefaultConnection` and that migrations are applied.  
- Static assets: ensure `wwwroot` is published and paths use `~/`.  
- Auth issues: review Identity/cookie settings in `Program.cs`.

---

## Contact

Repository: https://github.com/Ma7mudramdan/InnoviWearStore

Questions / issues: mahmoudramadan3lisayed@gmail.com

---

This README is a starting point. Update with project-specific deployment steps, architecture notes and team workflows as needed.

