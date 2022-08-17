using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ccog3nt_product_Management_4._0.Models;

namespace Ccog3nt_product_Management_4._0.Models
{
    public class ClusteredProducts
    {
       
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public float Score { get; set; }


    }
}
