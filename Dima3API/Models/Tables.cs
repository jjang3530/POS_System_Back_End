using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dima3API.Models
{
    public class Tables
    {
        [Key]
        public int TableId { get; set; }
        [Required]
        [Column(TypeName = "varchar(3)")]
        public string TableNumber { get; set; }
        [Required]
        [Column(TypeName = "varchar(1)")]
        public string Active { get; set; }
    }
}
