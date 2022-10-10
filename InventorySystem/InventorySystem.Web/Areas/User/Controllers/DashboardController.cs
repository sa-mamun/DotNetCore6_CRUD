using InventorySystem.Core.Entities;
using InventorySystem.Core.Services;
using InventorySystem.Web.Controllers;
using InventorySystem.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace InventorySystem.Web.Areas.User.Controllers
{
    [Area("User")]
    public class DashboardController : BaseController
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IMenuService _menuService;

        public DashboardController(ILogger<DashboardController> logger,
            ICategoryService categoryService,
            IProductService productService, IAuthorizationService authorizationService,
            IMenuService menuService)
            :base(authorizationService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _productService = productService;
            _menuService = menuService;
        }

        public IActionResult Test()
        {
            var categories = _categoryService.LoadAll();
            //_categoryService.Create(new Category { Name = "Household" });
            //_categoryService.Update(new Category { Name = "Updated Electronics" });
            return View();
        }

        public IActionResult Index()
        {

            IList<RoleClaimsViewModel> roleClaimsViewModels = new List<RoleClaimsViewModel>();
            IList<Menu> authorizedMenuList = new List<Menu>();
            var menus = _menuService.LoadAllMenus();
            foreach (var menu in menus)
            {
                bool isGranted = false;
                string permissionType = string.IsNullOrWhiteSpace(menu.AreaName) ? "Permission" : menu.AreaName;
                string permission = string.Empty;

                if (string.IsNullOrWhiteSpace(menu.ControllerName) == false)
                    permission += $"{menu.ControllerName}.";
                if (string.IsNullOrWhiteSpace(menu.ActionName) == false)
                    permission += $"{menu.ActionName}";

                if (User.Claims.Any(x => x.Type == permissionType && x.Value == permission))
                    authorizedMenuList.Add(menu);
            }

            return View(authorizedMenuList);
        }

        public IActionResult CreateProduct()
        {
            _productService.Create(new Product { Name = "Iphone 14", CategoryId = 2 });
            //_productService.Update(new Product { Name = "Update Iphone 14" });
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