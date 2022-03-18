using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoEshop.Models.Database
{
    public static class CarouselHelper
    {
        public static IList<Carousel> GenerateCarousel()
        {
            IList<Carousel> carousels = new List<Carousel>()
            {
                new Carousel() {
                    DataTarget = "#myCarousel",
                    ImageSrc = "/images/carousel/kaw1.jpg",
                    ImageAlt = "Kawasaki_carousel1",
                    CarouselContent = " " },

                 new Carousel() {
                    DataTarget = "#myCarousel",
                    ImageSrc = "/images/carousel/kaw2.jpg",
                    ImageAlt = "Kawasaki_carousel2",
                    CarouselContent = " " },

                  new Carousel() {
                    DataTarget = "#myCarousel",
                    ImageSrc = "/images/carousel/kaw3.jpg",
                    ImageAlt = "Kawasaki_carousel3",
                    CarouselContent = " " },

                  new Carousel() {
                    DataTarget = "#myCarousel",
                    ImageSrc ="/images/carousel/kaw4.jpg",
                    ImageAlt = "Kawasaki_carousel4",
                     CarouselContent = " " }
            };
            return carousels;
        }
    }
}

