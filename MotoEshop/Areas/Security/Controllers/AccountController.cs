using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MotoEshop.Controllers;
using MotoEshop.Models;
using MotoEshop.Models.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoEshop.Areas.Security.Controllers
{
    [Area("Security")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        ISecurityApplicationService iSecure;
        readonly ILogger<AccountController> logger;

        public AccountController(ISecurityApplicationService iSecure, ILogger<AccountController> logger)
        {

            this.iSecure = iSecure;
            this.logger = logger;
        }
        public IActionResult Login()
        {
            logger.LogInformation("Login method from AccountController has been called.");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            logger.LogInformation("Login method from AccountController has been called.");
            vm.LoginFailed = false;

            if (ModelState.IsValid)
            {
                bool isLogged = await iSecure.Login(vm);
                if (isLogged)
                {
                    return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", String.Empty), new { area = "" });
                }
                else
                {
                    vm.LoginFailed = true;

                }
            }
            return View(vm);
        }

        public IActionResult Logout()
        {
            logger.LogInformation("Logout method from AccountController has been called.");
            iSecure.Logout();
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Register()
        {
            logger.LogInformation("Register method from AccountController has been called.");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            logger.LogInformation("Register method from AccountController has been called.");
            vm.ErrorsDuringRegister = null;
            if (ModelState.IsValid)
            {
                vm.ErrorsDuringRegister = await iSecure.Register(vm, Models.Identity.Roles.Customer);

                if (vm.ErrorsDuringRegister == null)
                {
                    var lvM = new LoginViewModel()
                    {
                        Username = vm.Username,
                        Password = vm.Password,
                        RememberMe = true,
                        LoginFailed = false
                    };

                    return await Login(lvM);
                }

            }
            return View(vm);
        }
    }
}
