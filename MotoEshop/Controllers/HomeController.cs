using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MotoEshop.Models;
using MotoEshop.Models.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoEshop.Controllers
{
    public class HomeController : Controller
    {
        readonly EshopDBContext EshopDBContext;

        public HomeController(EshopDBContext eshopDBContext)
        {
            this.EshopDBContext = eshopDBContext;

        }

        public async Task<IActionResult> Index()
        {
            dynamic model = new ExpandoObject();

            var carvm = new CarouselViewModel();
            carvm.Carousels = await EshopDBContext.Carousels.ToListAsync();
            model.Carousels = carvm.Carousels;
            var provm = new ProductViewModel();
            provm.Products = await EshopDBContext.Products.ToListAsync();
            model.Products = provm.Products;
            


            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Products()
        {
            ViewData["Message"] = "Your product content page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var featureException = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ErrorCodeStatus(int? statusCode = null)
        {
            var statCode = statusCode.HasValue ? statusCode.Value : 0;

            string originalURL = String.Empty;
            var features = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            if (features != null)
            {
                originalURL = features.OriginalPathBase + features.OriginalPath + features.OriginalQueryString;
            }


            if (statCode == 404)
            {
                View404ViewModel vm404 = new View404ViewModel()
                {
                    StatusCode = statCode
                };

                return View("View" + statusCode.ToString(), vm404);
            }
            else if (statusCode.HasValue && statusCode.Value == 505)
            {
                View505ViewModel vm505 = new View505ViewModel()
                {
                    StatusCode = statusCode.HasValue ? statusCode.Value : 0
                };

                return View("View" + statusCode.ToString(), vm505);
            }

            ErrorCodeStatusViewModel vm = new ErrorCodeStatusViewModel()
            {
                StatusCode = statCode,
                OriginalURL = originalURL
            };

            return View(vm);
        }

    }
}
