using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoEshop.Models.Database
{
    public static class DbInitializer
    {
        public static void Initialize(EshopDBContext dBContext)
        {

            if (dBContext.Database.EnsureCreated())
            {
                IList<Carousel> carousels = CarouselHelper.GenerateCarousel();
                foreach (var item in carousels)
                {
                    dBContext.Carousels.Add(item);
                }
                dBContext.SaveChanges();

                IList<Product> products = ProductHelper.GenerateProducts();
                foreach (var item in products)
                {
                    dBContext.Products.Add(item);
                }
                dBContext.SaveChanges();
            }


           
        }
    }
}
