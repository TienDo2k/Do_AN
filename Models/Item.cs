using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTCK_PhanTienDo.Models
{
    public class Item
    {
        //thuong tin san pham
        public ProductsRecord ProductItem { get; set; }
        //so luong
        public int Quantity { get; set; }
        // gia -> k lấy trực tiếp từ sp , mà tạo giá ở đây để láy giá chính xác
      
    }
}
