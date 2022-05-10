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
    [Table("Products")]
    public class Product : Entity
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        [StringLength(225)]
        public string ImageSrc { get; set; }
        [Required]
        [StringLength(50)]
        public string ImageAlt { get; set; }
        [Required]
        public double Price { get; set; }
        [NotMapped]
        [FileContentType("image")]
        public IFormFile Image { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool Stock { get; set; }

    }
}
