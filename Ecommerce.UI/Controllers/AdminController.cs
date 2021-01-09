using Ecommerce.Business.Interfaces;
using Ecommerce.Core.DTos.CategoryDTos;
using Ecommerce.Core.DTos.ProductDTos;
using Ecommerce.Core.Utilities;
using Ecommerce.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Core.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommerce.UI.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {

            var product = await _productService.GetAllByNonDeleted();
            return View(product.Data);

        }
        public async Task<JsonResult> GetAllProduct()
        {
            var result = await _productService.GetAllByNonDeleted();
            var product = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(product);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var result = await _categoryService.GetAll();
            ViewBag.Categories = result.Data.Categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDto productAddDto)
        {
            if (ModelState.IsValid)
            {

                var product = await _productService.Add(productAddDto);
                if (product.ResultStatus == ResultStatus.Success)
                {
                    var categoryAddAjaxModel = JsonSerializer.Serialize(new ProductAddAjaxModel
                    {
                        ProductDto = product.Data,
                        UrunAddPartial = await this.RenderViewToStringAsync("_UrunAddPartial", productAddDto)

                    });
                    return Json(categoryAddAjaxModel);
                }
            }
            var productAddAjaxErorModel = JsonSerializer.Serialize(new ProductAddAjaxModel
            {

                UrunAddPartial = await this.RenderViewToStringAsync("_UrunAddPartial", productAddDto)

            });
            return Json(productAddAjaxErorModel);

        }

        [HttpPost]
        public async Task<JsonResult> Delete(int productId)
        {
            var result = await _productService.Delete(productId);
            var deletedProduct = JsonSerializer.Serialize(result.Data);
            return Json(deletedProduct);
        }
    }
}

