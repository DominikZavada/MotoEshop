using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MotoEshop.Models;
using MotoEshop.Models.Database;
using MotoEshop.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MotoEshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
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
        public async Task<IActionResult> Edit(Product product, User user)
        {
            Product productItem = EshopDBContext.Products.Where(proI => proI.ID == product.ID).FirstOrDefault();
            var fromAddress = new MailAddress("eshoputb@gmail.com", "Eshop Kawasaki");
            const string fromPassword = "DominikZavada1+";
            var body = "";

            if (productItem != null && ModelState.IsValid)
            {
                productItem.ProductName = product.ProductName;

                productItem.ImageAlt = product.ImageAlt;

                if (productItem.Price != product.Price)
                {
                    var dogItems = EshopDBContext.Dogs.Include(pro => pro.Product).Include(us => us.User).Where(id => id.ProductID == product.ID);
                    var dogItemslist = dogItems.ToList();

                    for (int i = 0; i < dogItemslist.Count(); i++)
                    {

                        var toAddress = new MailAddress(dogItemslist[i].User.Email, "To Users");

                        const string subject = "Zmena ceny produktu!";
                        body = "Vaše cena u produktu " + product.ProductName + " byla změněna!";

                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,

                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                            EnableSsl = true
                        };
                        using (var message = new MailMessage(fromAddress, toAddress)
                        {
                            Subject = subject,
                            Body = body
                        })
                        {
                            smtp.Send(message);
                        }
                    }
                }
                productItem.Price = product.Price;
                productItem.Description = product.Description;
                if (productItem.Stock != product.Stock)
                {
                    var dogItems = EshopDBContext.Dogs.Include(pro => pro.Product).Include(us => us.User).Where(id => id.ProductID == product.ID);
                    var dogItemslist = dogItems.ToList();

                    for (int i = 0; i < dogItemslist.Count(); i++)
                    {

                        var toAddress = new MailAddress(dogItemslist[i].User.Email, "To Users");

                        const string subject = "Změna skladnosti produktu!";
                        if (product.Stock == true)
                        {
                            body = "Váš produkt " + product.ProductName + " byl naskladěn!";
                        }
                        else
                        {
                            body = "Váš produkt " + product.ProductName + " už není na skladě!";
                        }


                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,

                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                            EnableSsl = true
                        };
                        using (var message = new MailMessage(fromAddress, toAddress)
                        {
                            Subject = subject,
                            Body = body
                        })
                        {
                            smtp.Send(message);
                        }
                    }
                }

                productItem.Stock = product.Stock;

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

