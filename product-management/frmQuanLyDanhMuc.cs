using AppTinhTienBanSach.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppTinhTienBanSach
{
    public partial class frmQuanLyDanhMuc : Form
    {
        public static bool CoThayDoi = false;
        public frmQuanLyDanhMuc()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DanhMuc danhMuc = new DanhMuc();
            danhMuc.MaDanhMuc = txtMaDanhMuc.Text;
            danhMuc.TenDanhMuc = txtTenDanhMuc.Text;
            frmQuanLySanPham.danhSachDanhMuc.Add(danhMuc);

            //gọi hàm HienThiDanhMucTrenListBox() để khi lưu sẽ hiển thị tên danh mục trên listbox
            HienThiDanhMucTrenListBox();

            //sau khi người dùng nhấn nút lưu, hệ thống sẽ tự động xóa thông tin danh mục trước đó
            //để nhập danh mục tiếp theo nhanh hơn
            txtMaDanhMuc.Text = ""; //xóa mã danh mục
            txtTenDanhMuc.Text = ""; //xóa tên danh mục
            txtMaDanhMuc.Focus(); //tự động di chuyển chuột đến ô mã danh mục sau khi nhấn nút lưu

            //khi nhấn nút lưu sẽ có sự thay đổi
            CoThayDoi = true;
        }

        public void HienThiDanhMucTrenListBox()
        {
            //xóa dữ liệu cũ
            lstDanhMuc.Items.Clear();
            foreach(DanhMuc danhMuc in frmQuanLySanPham.danhSachDanhMuc)
            {
                lstDanhMuc.Items.Add(danhMuc);
            }
        }

        private void lstDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //kiểm tra xem người dùng có chọn tên danh mục trên listbox không? 
            if(lstDanhMuc.SelectedIndex != -1)
            {
                //kiểm tra các danh mục hiển thị trong listbox
                DanhMuc danhMuc = lstDanhMuc.SelectedItem as DanhMuc;

                txtMaDanhMuc.Text = danhMuc.MaDanhMuc;
                txtTenDanhMuc.Text = danhMuc.TenDanhMuc;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //nếu có danh mục được chọn thì tiến hành xóa danh mục đó
            if(lstDanhMuc.SelectedIndex != -1)
            {
                DanhMuc danhMuc = lstDanhMuc.SelectedItem as DanhMuc;
                DialogResult ret = MessageBox.Show("Bạn có chắc xóa danh mục này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(ret == DialogResult.Yes)
                {
                    lstDanhMuc.Items.Remove(danhMuc);
                    CoThayDoi = true;
                }
                
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //có sự thay đổi
            if(CoThayDoi == true)
            {
                //mục đích để khi ta nhấn vào button ... bên frmQuanLySanPham mà bên frmQuanLyDanhMuc
                //có sự thay đổi (lưu,xóa) thì combobox bên frmQuanLySanPham sẽ được update
                DialogResult = DialogResult.OK;  
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void frmQuanLyDanhMuc_Load(object sender, EventArgs e)
        {
            HienThiDanhMucTrenListBox();
        }
    }
}
