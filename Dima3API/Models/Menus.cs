using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dima3API.Models
{
    public class Menus
    {
        [Key]
        public int MenuId { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string MenuName { get; set; }
        [Column(TypeName = "Decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string ThumbPic { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string LargePic { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string Active { get; set; }
        //public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
