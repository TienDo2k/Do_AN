using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTCK_PhanTienDo.Models
{
    [Table("Rating")]
    public class RatingRecord
    {
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Star { get; set; }
    }
}
