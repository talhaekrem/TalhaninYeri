using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.Web.Entities;
using TalhaninYeri.Northwind.Web.Models;

namespace TalhaninYeri.Northwind.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<CustomIdentityUser> _userManager;
        private RoleManager<CustomIdentityRole> _roleManager;
        private SignInManager<CustomIdentityUser> _signInManager;

        public AccountController(
            UserManager<CustomIdentityUser> userManager,
            RoleManager<CustomIdentityRole> roleManager,
            SignInManager<CustomIdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        #region register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                CustomIdentityUser user = new CustomIdentityUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };
                IdentityResult result =
                    _userManager.CreateAsync(user, model.Password).Result;

                if (result.Succeeded)
                {
                    if(!_roleManager.RoleExistsAsync("Admin").Result)
                    {
                        CustomIdentityRole role = new CustomIdentityRole
                        {
                            Name = "Admin",
                        };
                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "Rolü ekleyemiyoruz!");
                            return View(model);
                        }

                        _userManager.AddToRoleAsync(user, "Admin").Wait();
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        if(!_roleManager.RoleExistsAsync("User").Result)
                        {
                            CustomIdentityRole role = new CustomIdentityRole
                            {
                                Name = "User",
                            };
                            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                            if (!roleResult.Succeeded)
                            {
                                ModelState.AddModelError("", "Rolü ekleyemiyoruz!");
                                return View(model);
                            }

                            _userManager.AddToRoleAsync(user, "User").Wait();
                            return RedirectToAction("Login", "Account");
                        }
                        else
                        {
                            _userManager.AddToRoleAsync(user, "User").Wait();
                            return RedirectToAction("Login", "Account");
                        }
                       
                    }

                }
                TempData["errorRegister"] = result.Errors.Select(e => e.Description).FirstOrDefault();
            }
            return View(model);
        }
        #endregion

        #region login

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(model.UserName,
                    model.Password, model.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Admin");
                }
                ModelState.AddModelError("", "Geçersiz giriş!");
                TempData["errorlogin"] = "Kullanıcı Adı veya Şifre Hatalı.";
            }
            return View(model);
        }
        #endregion

        #region logoff
        public ActionResult LogOff()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }
        #endregion

        #region AccessDenied
        public ActionResult AccessDenied()
        {
            return View();
        }
        #endregion
    }
}
