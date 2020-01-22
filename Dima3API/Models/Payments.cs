using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dima3API.Models
{
    public class Payments
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        [Required]
        [Column(TypeName = "SmallDateTime")]
        public DateTime PaymentDate { get; set; }
        [Required]
        [Column(TypeName = "Decimal(18,2)")]
        public decimal Amount { get; set; }
        public Orders orders { get; set; }
        
    }
}
