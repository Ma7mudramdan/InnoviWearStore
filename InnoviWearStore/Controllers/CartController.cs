using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InnoviWearStore.Data;
using InnoviWearStore.Models;

namespace InnoviWearStore.Controllers
{
   

    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public CartController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Dashboard", "Admin");
            }

            var userId = _userManager.GetUserId(User);
            var cartItems = await _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            var total = cartItems.Sum(c => c.Quantity * c.Product!.Price);
            ViewBag.Total = total;

            return View(cartItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            var userId = _userManager.GetUserId(User);
            var product = await _context.Products.FindAsync(productId);

            // Check if product exists
            if (product == null)
            {
                TempData["Error"] = "Product not found!";
                return RedirectToAction("Index", "Home");
            }

            // Validate stock
            if (quantity > product.StockQuantity)
            {
                TempData["Error"] = $"Sorry, only {product.StockQuantity} items available in stock!";
                return RedirectToAction("ProductDetails", "Home", new { id = productId });
            }

            var existingItem = await _context.CartItems
                .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);

            if (existingItem != null)
            {
                // Check if new quantity would exceed stock
                int newQuantity = existingItem.Quantity + quantity;
                if (newQuantity > product.StockQuantity)
                {
                    TempData["Error"] = $"Sorry, you can only add {product.StockQuantity - existingItem.Quantity} more of this item (max {product.StockQuantity})";
                    return RedirectToAction("Index", "Cart");
                }
                existingItem.Quantity = newQuantity;
            }
            else
            {
                var cartItem = new CartItem
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = quantity
                };
                _context.CartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            TempData["Success"] = "Item added to cart!";

            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int id, int quantity)
        {
            var cartItem = await _context.CartItems
                .Include(c => c.Product)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cartItem != null)
            {
                // Validate stock
                if (quantity > cartItem.Product.StockQuantity)
                {
                    TempData["Error"] = $"Sorry, only {cartItem.Product.StockQuantity} items available in stock!";
                    return RedirectToAction("Index");
                }

                if (quantity <= 0)
                {
                    _context.CartItems.Remove(cartItem);
                    TempData["Success"] = "Item removed from cart";
                }
                else
                {
                    cartItem.Quantity = quantity;
                    TempData["Success"] = "Cart updated!";
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Item removed from cart";
            }

            return RedirectToAction("Index");
        }

        // AJAX Methods for dynamic cart
        [HttpPost]
        public async Task<IActionResult> UpdateQuantityAjax(int id, int quantity)
        {
            try
            {
                var cartItem = await _context.CartItems
                    .Include(c => c.Product)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (cartItem != null)
                {
                    // Validate stock
                    if (quantity > cartItem.Product.StockQuantity)
                    {
                        return Json(new { success = false, message = $"Only {cartItem.Product.StockQuantity} items available!" });
                    }

                    if (quantity <= 0)
                    {
                        _context.CartItems.Remove(cartItem);
                    }
                    else
                    {
                        cartItem.Quantity = quantity;
                    }
                    await _context.SaveChangesAsync();
                    return Json(new { success = true });
                }
                return Json(new { success = false, message = "Item not found" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCartAjax(int id)
        {
            try
            {
                var cartItem = await _context.CartItems.FindAsync(id);
                if (cartItem != null)
                {
                    _context.CartItems.Remove(cartItem);
                    await _context.SaveChangesAsync();
                    return Json(new { success = true });
                }
                return Json(new { success = false, message = "Item not found" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<IActionResult> Checkout()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Dashboard", "Admin");
            }

            var userId = _userManager.GetUserId(User);
            var cartItems = await _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            if (!cartItems.Any())
            {
                return RedirectToAction("Index");
            }

            // Validate stock before checkout
            foreach (var item in cartItems)
            {
                if (item.Quantity > item.Product.StockQuantity)
                {
                    TempData["Error"] = $"Sorry, '{item.Product.Name}' only has {item.Product.StockQuantity} items in stock. Please update your cart.";
                    return RedirectToAction("Index");
                }
            }

            var user = await _userManager.GetUserAsync(User);
            var model = new CheckoutViewModel
            {
                Governorate = "",
                City = "",
                District = "",
                StreetAddress = user?.Address ?? "",
                PhoneNumber = user?.PhoneNumber ?? "",
                PaymentMethod = "",
                TotalAmount = cartItems.Sum(c => c.Quantity * c.Product!.Price)
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessCheckout(CheckoutViewModel model)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var cartItems = await _context.CartItems
                    .Include(c => c.Product)
                    .Where(c => c.UserId == userId)
                    .ToListAsync();

                if (cartItems.Any())
                {
                    // Final stock validation before creating order
                    foreach (var cartItem in cartItems)
                    {
                        if (cartItem.Quantity > cartItem.Product.StockQuantity)
                        {
                            TempData["Error"] = $"Sorry, '{cartItem.Product.Name}' is out of stock or insufficient quantity available.";
                            return RedirectToAction("Index");
                        }
                    }

                    // Format full address
                    var fullAddress = $"{model.StreetAddress}, {model.District}, {model.City}, {model.Governorate}";

                    // Create order
                    var order = new Order
                    {
                        UserId = userId,
                        OrderDate = DateTime.Now,
                        Status = "Pending",
                        TotalAmount = cartItems.Sum(c => c.Quantity * c.Product!.Price),
                        ShippingAddress = fullAddress,
                        PhoneNumber = model.PhoneNumber,
                        PaymentMethod = model.PaymentMethod
                    };

                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();

                    // Create order items and update stock
                    foreach (var cartItem in cartItems)
                    {
                        var orderItem = new OrderItem
                        {
                            OrderId = order.Id,
                            ProductId = cartItem.ProductId,
                            Quantity = cartItem.Quantity,
                            UnitPrice = cartItem.Product!.Price
                        };
                        _context.OrderItems.Add(orderItem);

                        // Update stock - THIS IS THE CRITICAL PART
                        cartItem.Product.StockQuantity -= cartItem.Quantity;
                        _context.Entry(cartItem.Product).State = EntityState.Modified;
                    }

                    // Clear cart
                    _context.CartItems.RemoveRange(cartItems);
                    await _context.SaveChangesAsync();

                    // Update user's phone number
                    var user = await _userManager.GetUserAsync(User);
                    if (user != null && string.IsNullOrEmpty(user.PhoneNumber))
                    {
                        user.PhoneNumber = model.PhoneNumber;
                        await _userManager.UpdateAsync(user);
                    }

                    TempData["Success"] = "Order placed successfully!";
                    return RedirectToAction("OrderConfirmation", new { id = order.Id });
                }
            }

            // If validation fails, recalculate total and return to checkout
            var userIdForModel = _userManager.GetUserId(User);
            var cartItemsForModel = await _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == userIdForModel)
                .ToListAsync();
            model.TotalAmount = cartItemsForModel.Sum(c => c.Quantity * c.Product!.Price);

            return View("Checkout", model);
        }

        public async Task<IActionResult> OrderConfirmation(int id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            var userId = _userManager.GetUserId(User);
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id && o.UserId == userId);

            if (order == null)
                return NotFound();

            return View(order);
        }

        // Add this method to your CartController
        [HttpPost]
        public async Task<IActionResult> ReorderOrder(int orderId)
        {
            try
            {
                var userId = _userManager.GetUserId(User);

                // Get the original order with items
                var order = await _context.Orders
                    .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                    .FirstOrDefaultAsync(o => o.Id == orderId && o.UserId == userId);

                if (order == null)
                {
                    return Json(new { success = false, message = "Order not found." });
                }

                int itemsAdded = 0;
                int itemsFailed = 0;
                var failedItems = new List<string>();

                foreach (var orderItem in order.OrderItems)
                {
                    // Check if product still exists and has stock
                    var product = await _context.Products.FindAsync(orderItem.ProductId);

                    if (product == null)
                    {
                        failedItems.Add($"Product ID {orderItem.ProductId} no longer exists");
                        itemsFailed++;
                        continue;
                    }

                    if (product.StockQuantity <= 0)
                    {
                        failedItems.Add($"{product.Name} is out of stock");
                        itemsFailed++;
                        continue;
                    }

                    // Check if quantity exceeds available stock
                    int quantityToAdd = orderItem.Quantity;
                    if (quantityToAdd > product.StockQuantity)
                    {
                        quantityToAdd = product.StockQuantity;
                        failedItems.Add($"{product.Name} only has {product.StockQuantity} in stock (requested {orderItem.Quantity})");
                    }

                    // Check if item already exists in cart
                    var existingCartItem = await _context.CartItems
                        .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == orderItem.ProductId);

                    if (existingCartItem != null)
                    {
                        // Update existing cart item
                        int newQuantity = existingCartItem.Quantity + quantityToAdd;
                        if (newQuantity > product.StockQuantity)
                        {
                            newQuantity = product.StockQuantity;
                        }
                        existingCartItem.Quantity = newQuantity;
                    }
                    else
                    {
                        // Add new cart item
                        var cartItem = new CartItem
                        {
                            UserId = userId,
                            ProductId = orderItem.ProductId,
                            Quantity = quantityToAdd
                        };
                        _context.CartItems.Add(cartItem);
                    }

                    itemsAdded++;
                }

                await _context.SaveChangesAsync();

                // Prepare success message
                string message = $"Added {itemsAdded} item(s) to your cart.";
                if (itemsFailed > 0)
                {
                    message += $" However, {itemsFailed} item(s) couldn't be added due to stock issues.";
                }

                return Json(new { success = true, message = message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while reordering. Please try again." });
            }
        }
    }
}