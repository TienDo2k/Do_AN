using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BTCK_PhanTienDo.Models
{
    [Table("Role")]
    public class RoleRecord
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MenuCategory { get; set; }
        public int MenuProduct { get; set; }
        public int MenuOrder { get; set; }
        public int MenuReport { get; set; }
        public int MenuUser { get; set; }
    }
}

