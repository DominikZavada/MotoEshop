using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoEshop.Models.DatabaseFake
{
    public static class CarouselHelper
    {
        public static IList<Carousel> GenerateCarousel()
        {
            IList<Carousel> carousels = new List<Carousel>()
            {
                new Carousel() {
                    ID = 0,
                    DataTarget = "#myCarousel",
                    ImageSrc = "/images/carousel/kaw1.jpg",
                    ImageAlt = "Kawasaki_carousel1",
                    CarouselContent = " " },

                 new Carousel() {
                    ID = 1,
                    DataTarget = "#myCarousel",
                    ImageSrc = "/images/carousel/kaw2.jpg",
                    ImageAlt = "Kawasaki_carousel2",
                    CarouselContent = " " },

                  new Carousel() {
                    ID = 2,
                    DataTarget = "#myCarousel",
                    ImageSrc = "/images/carousel/kaw3.jpg",
                    ImageAlt = "Kawasaki_carousel3",
                    CarouselContent = " " },

                  new Carousel() {
                    ID = 3,
                    DataTarget = "#myCarousel",
                    ImageSrc ="/images/carousel/kaw4.jpg",
                    ImageAlt = "Kawasaki_carousel4",
                     CarouselContent = " " }
            };
            return carousels;
        }
    }
}

