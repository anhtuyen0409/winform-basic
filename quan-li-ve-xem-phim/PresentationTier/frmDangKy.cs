using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppBanVeXemPhim.DataContext;

namespace AppBanVeXemPhim.PresentationTier
{
    public partial class frmDangKy : Form
    {

        AppBanVeModel context;
        public frmDangKy()
        {
            context = new AppBanVeModel();
            InitializeComponent();
        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            radNam.Checked = true;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (!KiemTraNhapRong())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!","Thông báo",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (context.NGUOI_DUNG.Where(r => r.TaiKhoan == txtTaiKhoan.Text).Count() > 0)
                {
                    MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo", MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (!isEmail(txtEmail.Text))
                    {
                        MessageBox.Show("Email không hợp lệ!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    /*if (!Regex.Match(txtSDT.Text, @"^(\[0-9])$").Success)
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }*/
                    if (!CheckTaiKhoan(txtTaiKhoan.Text))
                    {
                        MessageBox.Show("Vui lòng nhập tài khoản dài 3-50 ký tự!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!KiemTraDinhDangMatKhau(txtMatKhau.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu tối thiểu 7 ký tự, có ký tự chữ và số!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if(txtMatKhau.Text != txtXacNhanMatKhau.Text)
                    {
                        MessageBox.Show("Mật khẩu và xác nhận mật khẩu phải giống nhau!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        NGUOI_DUNG nd = new NGUOI_DUNG()
                        {
                            TaiKhoan = txtTaiKhoan.Text,
                            MatKhau = txtMatKhau.Text
                        };
                        context.NGUOI_DUNG.Add(nd);
                        context.SaveChanges();
                        MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                   
                }
            }
        }

        private bool KiemTraNhapRong()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                return false;
            }
           /* if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                return false;
            }
            /*if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                return false;
            }*/
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtXacNhanMatKhau.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                return false;
            }
            return true;
        }

        public static bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        public bool CheckTaiKhoan(string taiKhoan)
        {
            if(taiKhoan.Length <3 || taiKhoan.Length > 50)
            {
                return false;
            }
            return true;
        }

        public bool KiemTraDinhDangMatKhau(string matKhau)
        {

            if (matKhau.Length < 7)
            {
                return false;
            }
            else
            {
                bool kiemTraChu = false;
                bool kiemTraSo = false;
                for (int i = 0; i < matKhau.Length; i++)
                {
                    if (kiemTraChu == true && kiemTraSo == true)
                    {
                        break;
                    }
                    if (matKhau[i] >= 'A' && matKhau[i] <= 'Z' || matKhau[i] >= 'a' && matKhau[i] <= 'z')
                    {
                        kiemTraChu = true;
                    }
                    if (matKhau[i] >= '0' && matKhau[i] <= '9')
                    {
                        kiemTraSo = true;
                    }
                }
                if (kiemTraSo == false || kiemTraChu == false)
                {
                    return false;
                }
            }

            return true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
