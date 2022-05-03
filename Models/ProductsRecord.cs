using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTCK_PhanTienDo.Models
{
    [Table("Products")]
    public class ProductsRecord
    {
        [Key]
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int Hot { get; set; }
        public string Photo { get; set; }
        public double Price { get; set; }
        //giam gia
        public double Discount { get; set; }

        public int Amount { get; set; }
    }
}
