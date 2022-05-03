using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTCK_PhanTienDo.Models
{
    [Table("Categories")]
    public class CategoriesRecord
    {
        [Key]

        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
    }
}

