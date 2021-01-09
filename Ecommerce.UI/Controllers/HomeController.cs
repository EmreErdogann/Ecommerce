using Ecommerce.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;


        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var product = await _productService.GetAll();
            return View(product.Data);
        }
    }
}
