using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ccog3nt_product_Management_4._0.Models
{
    public class Product
    {
        [Key]
        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int? ID { get; set; }

        [Column("ProductID")]
        public int? ProductId { get; set; }

        [Column("OrderSKU")]
        
        public int Sku { get; set; }
        

        public int? OrderProductId { get; set; }
        //[StringLength(255)]

        public string ProductName { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ImportDate { get; set; }

        public int? UnitsPerCase { get; set; }
    }
}

