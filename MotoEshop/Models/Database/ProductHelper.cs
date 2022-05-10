using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoEshop.Models.Database
{
    public class ProductHelper
    {
            public static IList<Product> GenerateProducts()
            {
                IList<Product> products = new List<Product>
            {
                new Product()
                {

                    ProductName = "Kawasaki Z 750",
                    ImageSrc = "/images/carousel/z750.jpg",
                    ImageAlt = "Z750",
                    Price = 110000,
                    Description = "Motorka Kawasaki Z750 z roku výroby 2010. Proslula zejména díky svému výkonu a nadčasovému desingu, díky kterému převálcovala svou konkurenci ve stejné cenové třídě.",
                    Stock = false,
                },

                new Product()
                {

                    ProductName = "Kawasaki Z 800",
                    ImageSrc = "/images/carousel/z800.jpg",
                    ImageAlt = "Z800",
                    Price = 150000,
                    Description = "Kawasaki Z 800, novější model vyráběný od roku 2014, který nahradil tehdejší Z750. Oproti předchůdci má o 10kW větší výkon a o 15kg větší suchou hmotnost.",
                    Stock = true,
                },

                new Product()
                {

                    ProductName = "Kawasaki Z 900",
                    ImageSrc = "/images/carousel/z900.jpg",
                    ImageAlt = "Z900",
                    Price = 230000,
                    Description = "Poslední model ze třídy naháčů značky Kawasaki vyráběný od roku 2018. Nejlepší jízdní vlastnosti, jak pří pomalé, tak při rychlé jízdě.",
                    Stock = true,
                },

            };
                return products;
            }
        }
    }

