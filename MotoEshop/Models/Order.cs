﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MotoEshop.Models
{
    [Table(nameof(Order))]
    public class Order : Entity
    {
        [StringLength(25)]
        [Required]
        public string OrderNumber { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        

        //[ForeignKey(nameof(OrderStatus))]
        //public int OrderStatusId { get; set; }
        //public OrderStatus OrderStatus { get; set; }

        public IList<OrderItem> OrderItems { get; set; }
    }
}
