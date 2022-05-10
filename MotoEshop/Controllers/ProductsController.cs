using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MotoEshop.Models;
using MotoEshop.Models.ApplicationServices;
using MotoEshop.Models.Database;
using MotoEshop.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoEshop.Controllers
{
    public class ProductsController : Controller
    {
        IHostingEnvironment Env;
        EshopDBContext EshopDBContext;
        readonly ILogger<ProductsController> logger;
        ISecurityApplicationService iSecure;

        public ProductsController(EshopDBContext eshopDBContext, IHostingEnvironment env, ILogger<ProductsController> logger, ISecurityApplicationService iSecure)
        {
            this.EshopDBContext = eshopDBContext;
            this.Env = env;
            this.logger = logger;
            this.iSecure = iSecure;
        }

        public IActionResult Detail(int id)
        {
            logger.LogInformation("Index method from ProductsController has been called.");
            Product product = EshopDBContext.Products.Where(pro => pro.ID == id).FirstOrDefault();
            return View(product);
        }


        public async Task<IActionResult> Dog(int id)
        {
            logger.LogInformation("Dog method from ProductsController has been called.");
            User currentUser = await iSecure.GetCurrentUser(User);
            Product product = EshopDBContext.Products.Where(pro => pro.ID == id).FirstOrDefault();
            if (currentUser == null)
            {
                return RedirectToAction(nameof(Error));
            }
            if (product != null || currentUser != null)
            {
                Dog dog = new Dog() { ProductID = id, UserID = currentUser.Id };
                EshopDBContext.Dogs.Add(dog);
                await EshopDBContext.SaveChangesAsync();
            }
            return View();
        }
        public IActionResult Error()
        {
            logger.LogInformation("Error method from ProductsController has been called.");
            return View();
        }
    }
}
