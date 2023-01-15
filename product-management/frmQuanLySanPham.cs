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
    public partial class frmQuanLySanPham : Form
    {
        public static List<DanhMuc> danhSachDanhMuc = new List<DanhMuc>();
        List<SanPham> danhSachSP = new List<SanPham>();
        public frmQuanLySanPham()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmQuanLyDanhMuc frmdanhMuc = new frmQuanLyDanhMuc();

            //lúc này chưa có thay đổi từ danh sách danh mục
            frmQuanLyDanhMuc.CoThayDoi = false;
            if(frmdanhMuc.ShowDialog() == DialogResult.OK)
            {
                HienThiDanhMucTrenComboBox();
            }
        }

        private void HienThiDanhMucTrenComboBox()
        {
            //xóa cũ
            cboDanhMuc.Items.Clear();
            foreach(DanhMuc danhMuc in danhSachDanhMuc)
            {
                cboDanhMuc.Items.Add(danhMuc);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(cboDanhMuc.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn danh mục!");
                return;
            }
            //lấy đối tượng danh mục 
            DanhMuc danhMuc = cboDanhMuc.SelectedItem as DanhMuc;

            //tiến hành nhập thông tin các sản phẩm
            SanPham sp = new SanPham();
            sp.MaSanPham = txtMaSanPham.Text;
            sp.TenSanPham = txtTenSanPham.Text;
            sp.DonGia = double.Parse(txtDonGia.Text);
            sp.XuatXu = txtXuatXu.Text;
            sp.HanSuDung = dtpHanSuDung.Value;

            //mỗi danh mục sẽ có nhiều sản phẩm và 1 sản phẩm thuộc 1 loại danh mục
            danhMuc.ThemSanPham(sp);

            //thêm vào danh sách sản phẩm
            danhSachSP.Add(sp);
            HienThiSanPhamTrenGiaoDien();
            XoaTrangSanPham();
        }

        public void HienThiSanPhamTrenGiaoDien()
        {
            lstSanPham.Items.Clear();
            foreach(SanPham sp in danhSachSP)
            {
                lstSanPham.Items.Add(sp);
            }
        }

        public void XoaTrangSanPham()
        {
            txtMaSanPham.Text = "";
            txtTenSanPham.Text = "";
            txtDonGia.Text = "";
            txtXuatXu.Text = "";
            txtMaSanPham.Focus();
        }

        private void lstSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstSanPham.SelectedIndex == -1)
            {
                return;
            }
            SanPham sp = lstSanPham.SelectedItem as SanPham;
            cboDanhMuc.Text = sp.Nhom.TenDanhMuc;
            txtMaSanPham.Text = sp.MaSanPham;
            txtTenSanPham.Text = sp.TenSanPham;
            txtDonGia.Text = sp.DonGia + "";
            txtXuatXu.Text = sp.XuatXu;
            dtpHanSuDung.Value = sp.HanSuDung;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(lstSanPham.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm!");
                return;
            }
            SanPham sp = lstSanPham.SelectedItem as SanPham;
            DialogResult ret = MessageBox.Show("Bạn có chắc chắn xóa " + sp.TenSanPham + " Không?", "Thông báo", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ret == DialogResult.Yes)
            {
                danhSachSP.Remove(sp);
                HienThiSanPhamTrenGiaoDien();
                XoaTrangSanPham();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có chắc chắn thoát chương trình không?",
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ret == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
