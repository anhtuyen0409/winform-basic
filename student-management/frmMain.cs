using ProjectStudentManagement.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectStudentManagement
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        Dictionary<string, Faculty> database = new Dictionary<string, Faculty>();
        private void frmMain_Load(object sender, EventArgs e)
        {
            LamGiaDuLieu();
            HienThiTreeView();
            HienThiKhoaComboBox();
        }
        private void HienThiKhoaComboBox()
        {
            cboKhoaChuQuan.Items.Clear();
            foreach(KeyValuePair<string,Faculty> itemKhoa in database)
            {
                Faculty kh = itemKhoa.Value;
                cboKhoaChuQuan.Items.Add(kh);
               
            }
        }
        private void HienThiTreeView()
        {
            treeView1.Nodes.Clear();
            foreach(KeyValuePair<string,Faculty> itemKhoa in database)
            {
                Faculty kh = itemKhoa.Value;
                TreeNode nodeKhoa = new TreeNode(kh.TenKhoa);
                nodeKhoa.Tag = kh; //để ltv xử lý
                treeView1.Nodes.Add(nodeKhoa);

                foreach(KeyValuePair<string,ClassRoom> itemLop in kh.Lops)
                {
                    ClassRoom lop = itemLop.Value;
                    TreeNode nodeLop = new TreeNode(lop.TenLop);
                    nodeLop.Tag = lop;
                    nodeKhoa.Nodes.Add(nodeLop);
                }
            }
            treeView1.ExpandAll(); //show treeview
        }
        private void LamGiaDuLieu()
        {
            Faculty cntt = new Faculty() { MaKhoa = "cntt", TenKhoa = "Công Nghệ Thông Tin" };
            Faculty kinhte = new Faculty() { MaKhoa = "kt", TenKhoa = "Kinh Tế" };
            Faculty xaydung = new Faculty() { MaKhoa = "xd", TenKhoa = "Xây Dựng" };
            Faculty quantri = new Faculty() { MaKhoa = "qtkd", TenKhoa = "Quản Trị Kinh Doanh" };
            Faculty cokhi = new Faculty() { MaKhoa = "ck", TenKhoa = "Cơ Khí Máy" };

            database.Add(cntt.MaKhoa, cntt);
            database.Add(kinhte.MaKhoa, kinhte);
            database.Add(xaydung.MaKhoa, xaydung);
            database.Add(quantri.MaKhoa, quantri);
            database.Add(cokhi.MaKhoa, cokhi);

            ClassRoom lopcntt1 = new ClassRoom() { MaLop = "cntt1", TenLop = "Lớp Công Nghệ Thông Tin 1" };
            cntt.Lops.Add(lopcntt1.MaLop, lopcntt1);
            lopcntt1.KhoaChuQuan = cntt;
            ClassRoom lopcntt2 = new ClassRoom() { MaLop = "cntt2", TenLop = "Lớp Công Nghệ Thông Tin 2" };
            cntt.Lops.Add(lopcntt2.MaLop, lopcntt2);
            lopcntt2.KhoaChuQuan = cntt;

            ClassRoom lopkinhte1 = new ClassRoom() { MaLop = "kt1", TenLop = "Lớp Kinh Tế 1" };
            kinhte.Lops.Add(lopkinhte1.MaLop, lopkinhte1);
            lopkinhte1.KhoaChuQuan = kinhte;
            ClassRoom lopkinhte2 = new ClassRoom() { MaLop = "kt2", TenLop = "Lớp Kinh Tế 2" };
            kinhte.Lops.Add(lopkinhte2.MaLop, lopkinhte2);
            lopkinhte2.KhoaChuQuan = kinhte;
            ClassRoom lopkinhte3 = new ClassRoom() { MaLop = "kt3", TenLop = "Lớp Kinh Tế 3" };
            kinhte.Lops.Add(lopkinhte3.MaLop, lopkinhte3);
            lopkinhte3.KhoaChuQuan = kinhte;


            Student sv1 = new Student()
            {
                MaSo = "SV01", HoTen = "Nguyễn Anh Tuyên", 
                GioiTinh = true, NamSinh = new DateTime(2001, 09, 04)
             };
            lopcntt1.Students.Add(sv1.MaSo, sv1);
            sv1.LopChuQuan = lopcntt1;

            Student sv2 = new Student()
            {
                MaSo = "SV02",
                HoTen = "Nguyễn Bình An",
                GioiTinh = false,
                NamSinh = new DateTime(1999, 9, 1)
            };
            lopcntt1.Students.Add(sv2.MaSo, sv2);
            sv2.LopChuQuan = lopcntt1;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node != null) //có chọn nút j đó trên giao diện
            {
                if(e.Node.Level == 1) //đúng là người dùng chọn nút lớp học => hiển thị danh sách sv
                {
                    ClassRoom lop = e.Node.Tag as ClassRoom;
                    HienThiDanhSachSinhVienTheoLop(lop);
                }
                else
                {
                    lvDanhSachSinhVien.Items.Clear(); //xóa đi vì ko xem danh sách sv
                }
            }
        }

        private void HienThiDanhSachSinhVienTheoLop(ClassRoom lop)
        {
            lvDanhSachSinhVien.Items.Clear();
            foreach(KeyValuePair<string,Student> itemSV in lop.Students)
            {
                Student sv = itemSV.Value;
                ListViewItem lvi = new ListViewItem(sv.MaSo);
                lvi.SubItems.Add(sv.HoTen);
                lvi.SubItems.Add(sv.GioiTinh==true ? "Nam":"Nữ");
                if(sv.NamSinh != null)
                {
                    lvi.SubItems.Add(sv.NamSinh.ToString("dd/MM/yyyy"));
                }
                else
                {
                    lvi.SubItems.Add(sv.NamSinh.ToString("..."));
                }
                lvDanhSachSinhVien.Items.Add(lvi);
            }
           
        }

        //chọn 1 khoa bất kỳ trong combobox thì hiển thị lớp tướng ứng
        private void cboKhoaChuQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboKhoaChuQuan.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                Faculty kh = cboKhoaChuQuan.SelectedItem as Faculty;
                HienThiLopComboBox(kh);
            }
        }

        private void HienThiLopComboBox(Faculty kh)
        {
            cboLopHoc.Items.Clear();
            foreach (KeyValuePair<string, ClassRoom> itemLop in kh.Lops)
            {
                ClassRoom lop = itemLop.Value;
                cboLopHoc.Items.Add(lop);

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(cboKhoaChuQuan.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn khoa!");
                return;
            }
            if(cboLopHoc.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn lớp!");
                return;
            }
            Student sv = new Student();
            sv.MaSo = txtMaSinhVien.Text;
            sv.HoTen = txtTenSinhVien.Text;
            sv.GioiTinh = radNam.Checked;
            ClassRoom lop = cboLopHoc.SelectedItem as ClassRoom;
            sv.LopChuQuan = lop;
            lop.Students.Add(sv.MaSo, sv);
            MessageBox.Show("Thêm dữ liệu thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
    }
}
