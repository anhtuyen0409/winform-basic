using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTinhTienBanSach.Entity
{
    public class SanPham
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public double DonGia { get; set; }
        public string XuatXu { get; set; }
        public DateTime HanSuDung { get; set; }

        //để biết được sản phẩm này thuôc loại danh mục nào (vd: sp tivi, máy tính => thuộc danh mục hàng điện tử)
        public DanhMuc Nhom { get; set; }

        //vì nếu xuất tất cả thông tin của sp thì sẽ rất dài, nên ta chỉ hiển thị tên là
        //đại diện cho 1 sản phẩm
        public override string ToString()
        {
            return this.TenSanPham;
        }
    }
}
