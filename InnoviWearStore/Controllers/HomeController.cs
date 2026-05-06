using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InnoviWearStore.Data;
using InnoviWearStore.Models;

namespace InnoviWearStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        // Add this action to your HomeController for server-side search
        public async Task<IActionResult> Search(string searchTerm, string category)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p => p.Name.Contains(searchTerm) ||
                                          p.Description.Contains(searchTerm));
            }

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category == category);
            }

            var products = await query.ToListAsync();
            ViewBag.SearchTerm = searchTerm;
            ViewBag.Category = category;

            return View(products);
        }

        public async Task<IActionResult> Category(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                var allCategories = await _context.Products
                    .Select(p => p.Category)
                    .Distinct()
                    .ToListAsync();
                return View("AllCategories", allCategories);
            }

            var products = await _context.Products
                .Where(p => p.Category == category)
                .ToListAsync();

            ViewBag.CategoryName = category;
            return View(products);
        }

      
        // Add this action to your existing HomeController
        public async Task<IActionResult> ProductDetails(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound();

            // Get related products (same category)
            var relatedProducts = await _context.Products
                .Where(p => p.Category == product.Category && p.Id != id)
                .Take(4)
                .ToListAsync();

            ViewBag.RelatedProducts = relatedProducts;
            return View(product);
        }

        // Get all products as JSON for search
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.Products
                .Select(p => new {
                    id = p.Id,
                    name = p.Name,
                    category = p.Category,
                    price = p.Price,
                    description = p.Description,
                    imageUrl = p.ImageUrl
                })
                .ToListAsync();

            return Json(products);
        }

        // Search results page
        public async Task<IActionResult> SearchResults(string q)
        {
            if (string.IsNullOrEmpty(q))
            {
                return RedirectToAction("Index");
            }

            var products = await _context.Products
                .Where(p => p.Name.Contains(q) ||
                            p.Category.Contains(q) ||
                            p.Description.Contains(q))
                .ToListAsync();

            ViewBag.SearchTerm = q;
            return View(products);
        }

    }
}