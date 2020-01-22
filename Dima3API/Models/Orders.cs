using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dima3API.Models
{
    public class Orders
    {
        [Key] 
        public int OrderId { get; set; }
        [Required]
        [Column(TypeName = "SmallDateTime")]
        public DateTime OrderDate { get; set; }      
        [Required]
        [ForeignKey("TableId")]
        public int TableId { get; set; }
       
        [Column(TypeName = "varchar(10)")]
        public string OrderStatus { get; set; }
    }
}
