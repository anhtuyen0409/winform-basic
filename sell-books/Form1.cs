using ProjectBanSach.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectBanSach
{
    public partial class Form1 : Form
    {
        DanhSachKhachHang database = new DanhSachKhachHang();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.TenKhachHang = txtTenKhachHang.Text;
            kh.SoLuongMua = int.Parse(txtSoLuongSach.Text);
            kh.LaSinhVien = chkLaSinhVien.Checked;
            database.Mua(kh);
            lblThanhTien.Text = kh.TinhTien+"";
        }

        private void btnTiep_Click(object sender, EventArgs e)
        {
            txtTenKhachHang.Text = "";
            txtSoLuongSach.Text = "";
            chkLaSinhVien.Checked = false;
            lblThanhTien.Text = "";
            txtTenKhachHang.Focus();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            txtTongSoKhachHang.Text = database.TongSoKhachHang+"";
            txtTongSoKhachHangLaSV.Text = database.TongSoKhachHangLaSinhVien + "";
            txtTongDoanhThu.Text = database.TongDoanhThu + "";
        }

        //lập trình sự kiện
        private void txtTongSoKhachHang_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //khi người dùng double click vào ô tổng số khách hàng thì sẽ hiện danh sách khách hàng đã mua sách
            Form frmKhachHang = new Form();
            frmKhachHang.Width = frmKhachHang.Height = 300;

            //khởi tạo 1 listbox
            ListBox lstKhachHang = new ListBox();

            //thêm listbox vào form
            frmKhachHang.Controls.Add(lstKhachHang);
            lstKhachHang.Dock = DockStyle.Fill;
            foreach(KhachHang kh in database.KhachHangs)
            {
                lstKhachHang.Items.Add(kh.TenKhachHang);
            }
            frmKhachHang.StartPosition = FormStartPosition.CenterScreen;

            //hiển thị
            frmKhachHang.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có chắc chắn thoát không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ret == DialogResult.Yes)
            {
                Close();
            }
        }

        private void txtTongSoKhachHangLaSV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //khi người dùng double click vào ô tổng số khách hàng thì sẽ hiện danh sách khách hàng đã mua sách
            Form frmKhachHangLaSinhVien = new Form();
            frmKhachHangLaSinhVien.Width = frmKhachHangLaSinhVien.Height = 300;

            //khởi tạo 1 listbox
            ListBox lstKhachHangLaSV = new ListBox();

            //thêm listbox vào form
            frmKhachHangLaSinhVien.Controls.Add(lstKhachHangLaSV);
            lstKhachHangLaSV.Dock = DockStyle.Fill;
            foreach (KhachHang kh in database.KhachHangs)
            {
                if(kh.LaSinhVien == true)
                {
                    lstKhachHangLaSV.Items.Add(kh.TenKhachHang);
                }
                
            }
            frmKhachHangLaSinhVien.StartPosition = FormStartPosition.CenterScreen;

            //hiển thị
            frmKhachHangLaSinhVien.Show();
        }
    }
}
