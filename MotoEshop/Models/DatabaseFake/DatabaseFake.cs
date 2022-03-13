using MotoEshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoEshop.Models.DatabaseFake
{
    public static class DatabaseFake
    {
        public static IList<Carousel> Carousels { get; set; }

        static DatabaseFake()
        {
            Carousels = CarouselHelper.GenerateCarousel();
        }
    }
}
