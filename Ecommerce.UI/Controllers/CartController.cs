using Ecommerce.Business.Interfaces;
using Ecommerce.Core.DTos.CartDTos;
using Ecommerce.Entities.Concrete;
using Ecommerce.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly UserManager<User> _userManager;

        public CartController(ICartService cartService, UserManager<User> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var cart = await _cartService.GetByUserOptional(int.Parse(_userManager.GetUserId(User)));
            var cartInstance = cart.Data;
            return View(new CartModel 
            {
                 CartId=cartInstance.Id,
                 CartItems=cartInstance.CartItems.Select(c=>new CartItemModel()
                 {
                     CartItemId=c.Id,
                     ProductId=c.ProductId,
                     Name=c.Product.Name,
                     Price=c.Product.Price.ToString(),
                     ImageUrl=c.Product.ImageUrl

                 }).ToList()
            }) ;
        }
    }
}
