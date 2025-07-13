using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeStores.Data.Models;

namespace BikeStores.Frontend.Controllers
{
    public class ProductsController : Controller
    {
        private readonly BikeStoresContext _context;

        public ProductsController(BikeStoresContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var prodotti = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .OrderBy(p => p.ProductName)
                .ToListAsync();

            return View(prodotti);
        }

        public async Task<IActionResult> Details(int id)
        {
            var prodotto = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Stocks)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (prodotto == null)
                return NotFound();

            return View(prodotto);
        }
    }
}
