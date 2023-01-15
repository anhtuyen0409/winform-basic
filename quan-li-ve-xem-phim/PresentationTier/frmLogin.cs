using AppBanVeXemPhim.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBanVeXemPhim.PresentationTier
{
    public partial class frmLogin : Form
    {
        AppBanVeModel context;
        public frmLogin()
        {
            context = new AppBanVeModel();
            InitializeComponent();
        }

        private void btnDangKyTaiKhoan_Click(object sender, EventArgs e)
        {
            frmDangKy frmDK = new frmDangKy();
            if(frmDK.ShowDialog() == DialogResult.OK)
            {

            } 
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (!KiemTraNhapRong())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if(context.NGUOI_DUNG.Where(r => r.TaiKhoan == txtTaiKhoan.Text && r.MatKhau == txtMatKhau.Text).Count() == 0)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu sai!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        private bool KiemTraNhapRong()
        {
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                return false;
            }
            return true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có chắc chắn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ret == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
