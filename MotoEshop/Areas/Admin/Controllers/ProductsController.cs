using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoEshop.Models;
using MotoEshop.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoEshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        IHostingEnvironment Env;
        readonly EshopDBContext EshopDBContext;


        public ProductsController(EshopDBContext eshopDBContext, IHostingEnvironment env)
        {
            this.EshopDBContext = eshopDBContext;
            this.Env = env;

        }
        public async Task<IActionResult> Select()
        {
            
            ProductViewModel product = new ProductViewModel();
            product.Products = await EshopDBContext.Products.ToListAsync();
            return View(product);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.ImageSrc = String.Empty;

                FileUpload fup = new FileUpload(Env.WebRootPath, "carousel", "image");
                product.ImageSrc = await fup.FileUploadAsync(product.Image);

                EshopDBContext.Products.Add(product);

                await EshopDBContext.SaveChangesAsync();
                return RedirectToAction(nameof(Select));
            }
            else
            {
                return View(product);
            }

        }

        public IActionResult Edit(int id)
        {
            Product productItem = EshopDBContext.Products.Where(proI => proI.ID == id).FirstOrDefault();



            if (productItem != null)
            {
                return View(productItem);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {      
            Product productItem = EshopDBContext.Products.Where(proI => proI.ID == product.ID).FirstOrDefault();
 
            if (productItem != null && ModelState.IsValid)
            {
                productItem.ProductName = product.ProductName;
                productItem.ImageAlt = product.ImageAlt;
                productItem.Price = product.Price;
                productItem.Description = product.Description;
               

                FileUpload fup = new FileUpload(Env.WebRootPath, "carousel", "image");
                if (String.IsNullOrWhiteSpace(product.ImageSrc = await fup.FileUploadAsync(product.Image)) == false)
                {
                    productItem.ImageSrc = product.ImageSrc;
                }

                await EshopDBContext.SaveChangesAsync();

                return RedirectToAction(nameof(Select));
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            Product productItem = EshopDBContext.Products.Where(proI => proI.ID == id).FirstOrDefault();

            if (productItem != null)
            {
                EshopDBContext.Products.Remove(productItem);
                await EshopDBContext.SaveChangesAsync();

                return RedirectToAction(nameof(Select));
            }
            else
            {
                return NotFound();
            }
        }
    }

}

