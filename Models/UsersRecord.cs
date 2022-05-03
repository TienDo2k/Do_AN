﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTCK_PhanTienDo.Models
{
    [Table("Users")]
    public class UsersRecord
    {
        [Key]
        public int ID { get; set; }

        public string? FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Avata { get; set; }
        public int? Status { get; set; }
        public string ResetPasswordCode { get; set; }

    }
}
