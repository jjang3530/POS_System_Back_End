using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dima3API.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        [Required]
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }

        [Required]
        [ForeignKey("MenuId")]
        public int MenuId { get; set; }
        
        [Required]
        public int Quantity { get; set; }

        public Menus menus { get; set; }

        public Orders orders { get; set; }
    }
}
