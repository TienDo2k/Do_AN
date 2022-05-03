using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTCK_PhanTienDo.Models
{
    [Table("Slides")]
    public class SlidesRecord
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
    }
}
