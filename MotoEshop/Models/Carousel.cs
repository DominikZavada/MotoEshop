using Microsoft.AspNetCore.Http;
using MotoEshop.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MotoEshop.Models
{
    [Table("Carousels")]
    public class Carousel : Entity
    {
        [Required]
        public string DataTarget { get; set; }
        [NotMapped]
        [FileContentType("image")]
        public IFormFile Image { get; set; }
        [Required]
        [StringLength(255)]
        public string ImageSrc { get; set; }
        [Required]
        [StringLength(25)]
        public string ImageAlt { get; set; }
        [Required]
        public string CarouselContent { get; set; }
    }
}
