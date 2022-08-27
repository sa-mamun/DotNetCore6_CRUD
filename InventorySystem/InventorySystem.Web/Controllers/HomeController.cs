using InventorySystem.Core.Entities;
using InventorySystem.Core.Services;
using InventorySystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InventorySystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, 
            ICategoryService categoryService,
            IProductService productService)
        {
            _logger = logger;
            _categoryService =  categoryService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            _categoryService.Create(new Category { Name = "Board" });
            return View();
        }

        public IActionResult CreateProduct()
        {
            _productService.Create(new Product { Name = "Iphone 14", CategoryId = 1 });
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}