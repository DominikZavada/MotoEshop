using MotoEshop.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MotoEshop.Models
{
    [Table("Dog")]
    public class Dog : Entity
    {
        [ForeignKey(nameof(Product))]
        public int ProductID { get; set; }
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }

        public Product Product { get; set; }

        public User User { get; set; }
    }
}
