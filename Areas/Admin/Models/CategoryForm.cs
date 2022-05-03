using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BTCK_PhanTienDo.Models;

namespace BTCK_PhanTienDo.Areas.Admin.Models
{
    public class CategoryForm:CategoriesRecord
    {
        public int Id { get; set; }
        
        public string Name { get; set; }


    }
}
