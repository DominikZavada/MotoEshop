using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MotoEshop.Models;
using MotoEshop.Models.Database;
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


        public ProductsController(EshopDBContext eshopDBContext, IHostingEnvironment env)
        {
            this.EshopDBContext = eshopDBContext;
            this.Env = env;

        }

        public IActionResult Detail(int id)
        {
            Product product = EshopDBContext.Products.Where(pro => pro.ID == id).FirstOrDefault();
            return View(product);
        }


        
        public IActionResult Error()
        {
            
            return View();
        }
    }
}
