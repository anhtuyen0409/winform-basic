using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppXuLyChuoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSoKyTu_Click(object sender, EventArgs e)
        {
            //txtKetQua.Text = txtDuLieuGoc.Text.Length + "";
            txtKetQua.Text = txtDuLieuGoc.Text.Length.ToString();
        }

        private void btnInChuHoa_Click(object sender, EventArgs e)
        {
            txtKetQua.Text = txtDuLieuGoc.Text.ToUpper();
        }

        private void btnInChuThuong_Click(object sender, EventArgs e)
        {
            txtKetQua.Text = txtDuLieuGoc.Text.ToLower();
        }

        private void btnDemKyTuHoa_Click(object sender, EventArgs e)
        {
            string s = txtDuLieuGoc.Text;
            int dem = 0;
            foreach(char c in s)
            {
                //kiểm tra c có phải ký tự in hoa không?
                if (char.IsUpper(c))
                {
                    dem++;
                }
            }
            txtKetQua.Text = "Có " + dem + " ký tự in hoa";
        }

        private void btnDemKyTuThuong_Click(object sender, EventArgs e)
        {
            string s = txtDuLieuGoc.Text;
            int dem = 0;
            foreach(char c in s)
            {
                if (char.IsLower(c))
                {
                    dem++;
                }
            }
            txtKetQua.Text = "Có " + dem + " ký tự in thường";
        }

        private void btnDemKyTuSo_Click(object sender, EventArgs e)
        {
            string s = txtDuLieuGoc.Text;
            int dem = 0;
            foreach(char c in s)
            {
                if (char.IsDigit(c))
                {
                    dem++;
                }
            }
            txtKetQua.Text = "Có " + dem + " ký tự số";
        }

        private void btnDaoChuoi_Click(object sender, EventArgs e)
        {
            string s = txtDuLieuGoc.Text;

            //danh sách các ký tự đã được đảo ngược
            List<char> s2 = s.Reverse().ToList();
            txtKetQua.Text = "";
            foreach(char c in s2)
            {
                txtKetQua.Text += c;
            }
        }

        private void btnToiUuChuoi_Click(object sender, EventArgs e)
        {
            //xóa khoảng trắng dư thừa bên trái & phải
            string s = txtDuLieuGoc.Text.Trim();

            //tách từ theo khoảng trắng
            string[] arr = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //nối các từ lại thành chuỗi tối ưu
            txtKetQua.Text = "";
            foreach(string word in arr)
            {
                txtKetQua.Text += word + " ";
            }
            txtKetQua.Text = txtKetQua.Text.Trim();
        }

        private void btnViTriDauTien_Click(object sender, EventArgs e)
        {
            int vt = txtDuLieuGoc.Text.IndexOf(txtViTriDauTien.Text);
            if(vt != -1)
            {
                txtKetQua.Text = "Tìm thấy " + txtViTriDauTien.Text + " lần đầu tiên tại vị trí " + vt;
            }
            else
            {
                txtKetQua.Text = "Không tìm thấy " + txtViTriDauTien.Text;
            }
        }

        private void btnViTriCuoiCung_Click(object sender, EventArgs e)
        {
            int vt = txtDuLieuGoc.Text.LastIndexOf(txtViTriCuoiCung.Text);
            if(vt != -1)
            {
                txtKetQua.Text = "Không tìm thấy " + txtViTriCuoiCung.Text;
            }
            else
            {
                txtKetQua.Text = "Tìm thấy " + txtViTriCuoiCung.Text + " cuối cùng tại vị trí " + vt;
            }
        }

        private void btnDemSoLanXuatHien_Click(object sender, EventArgs e)
        {
            int dem = 0;
            string s = txtDuLieuGoc.Text;

            //trả về lần xuất hiện đầu tiên
            int vt = s.IndexOf(txtDemSoLanXuatHien.Text);
            if(vt == -1)
            {
                txtKetQua.Text = "Không có " + txtDemSoLanXuatHien.Text;
            }
            else
            {
                while (vt != -1)
                {
                    dem++;
                    s = s.Substring(vt + txtDemSoLanXuatHien.Text.Length); //cập nhật lại chuỗi sau khi đếm xuất hiện lần 1
                    vt = s.IndexOf(txtDemSoLanXuatHien.Text);
                }
                txtKetQua.Text = "Tìm thấy " + txtDemSoLanXuatHien.Text + " xuất hiện " + dem + " lần";
            }
        }

        private void btnTachTu_Click(object sender, EventArgs e)
        {
            //nhập khoảng trắng vào ô tách từ thì hệ thống sẽ tách từ theo khoảng trắng
            if(txtTachTu.Text == " ")
            {
                //tách từ theo khoảng trắng
                string[] arr = txtDuLieuGoc.Text.Split(' ');
                txtKetQua.Text = "";
                foreach(string s in arr)
                {
                    txtKetQua.Text += s + "\r\n";
                }
            }
        }
    }
}
