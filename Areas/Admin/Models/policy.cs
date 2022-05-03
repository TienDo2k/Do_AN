using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTCK_PhanTienDo.Areas.Admin.Models
{
    public class policy
    {
        public static int ROLE_ADMIN = 1;
        public static bool role(int r)
        {
            if(r == 1)
            {
                return true;
            }
            return false;
        }
    }
}
