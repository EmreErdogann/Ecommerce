using AutoMapper;
using Ecommerce.Business.Interfaces;
using Ecommerce.Core.DTos.UserDTos;
using Ecommerce.Core.Utilities;
using Ecommerce.Entities.Concrete;
using Ecommerce.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Core.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecommerce.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ICartService _cartService;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, ICartService cartService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GirisYap(AppUserSignInModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    var identityResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                    if (identityResult.Succeeded)
                    {
                        var rol = await _userManager.GetRolesAsync(user);

                        if (rol.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });

                        }
                    }
                }
                ModelState.AddModelError("", "Kullanıcı adın veya şifren hatalı dostum");
            }
            return View("Index", model);
        }
        public IActionResult KayıtOl()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KayıtOl(AppUserViewModel model)
        {
            if (ModelState.IsValid)
            {

                User user = new User()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.Name,
                    LastName = model.Surname,


                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _cartService.CartAsync(user.Id.ToString());
                    var addRoleResult = await _userManager.AddToRoleAsync(user, "Member");
                    if (addRoleResult.Succeeded)
                    {
                        return RedirectToAction("GirisYap");
                    }
                    foreach (var item in addRoleResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);

        }
        public async Task<IActionResult> CıkısYap()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
