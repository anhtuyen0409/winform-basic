using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTinhTienBanSach.Entity
{
    public class DanhMuc
    {
        private Dictionary<string, SanPham> listSanPham = new Dictionary<string, SanPham>();
        public string MaDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }
        public void ThemSanPham(SanPham sp)
        {
            //kiểm tra sản phẩm đã tồn tại chưa, nếu chưa thì mới thêm sản phẩm
            if(this.listSanPham.ContainsKey(sp.MaSanPham) == false)
            {
                this.listSanPham.Add(sp.MaSanPham, sp);
                sp.Nhom = this; //thể hiện sản phẩm thuộc loại danh mục này
            }
            else
            {
                return;
            }
        }

        public Dictionary<string,SanPham> SanPhams
        {
            get { return this.listSanPham; }
            set { this.listSanPham = value; }
        }

        public override string ToString()
        {
            return this.TenDanhMuc;
        }
    }
}
