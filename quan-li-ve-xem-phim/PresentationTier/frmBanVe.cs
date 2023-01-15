using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppBanVeXemPhim.BusinessTier;
using AppBanVeXemPhim.DataContext;

namespace AppBanVeXemPhim
{
    public partial class Form1 : Form
    {
        int maHoaDon;
        DataTable dblChiTietHoaDon;
        GheBT gheBT;
        HoaDonBT hoaDonBT;
        ChiTietHoaDonBT chiTietHoaDonBT;
        public Form1()
        {
            
            InitializeComponent();
            gheBT = new GheBT();
            hoaDonBT = new HoaDonBT();
            chiTietHoaDonBT = new ChiTietHoaDonBT();
            maHoaDon = 0;
            dblChiTietHoaDon = new DataTable();
            dblChiTietHoaDon.Columns.Add("Mã Hóa Đơn", typeof(string));
            dblChiTietHoaDon.Columns.Add("Số Ghế", typeof(int));
            dblChiTietHoaDon.Columns.Add("Giá Tiền", typeof(double));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //khởi tạo 15 ghế
            KhoiTaoSoGhe(3, 5);
            TaiDanhSachHoaDon();
            
        }

       
        //khoảng cách X là khảng cách giữa các button trên 1 dòng
        //khoảng cách Y là khoảng cách giữa các button trên 1 cột
        private void KhoiTaoSoGhe(int dong, int cot)
        {
            List<int> danhSachGheDaMuaTheoNgay = chiTietHoaDonBT.LayDanhSachGheDaMuaTheoNgay(DateTime.Today);
            Button btnGhe;
            int x, y = 13, khoangCachX = 120, khoangCachY = 70, w = 80, h = 60, dem = 1;
            for(int i=0; i<dong; i++)
            {
                x = 22;
                for(int j=0; j<cot; j++)
                {
                    btnGhe = new Button();
                    btnGhe.Location = new Point(x, y);
                    btnGhe.Size = new Size(w, h);
                    btnGhe.Text = dem++.ToString();
                    if (danhSachGheDaMuaTheoNgay.Contains(dem))
                    {
                        btnGhe.BackColor = Color.Yellow;
                    }
                    else
                    {
                        btnGhe.BackColor = Color.White;
                    }
                    btnGhe.BackColor = Color.White;
                    btnGhe.Click += BtnGhe_Click;
                    pnlHangGhe.Controls.Add(btnGhe);
                    x += khoangCachX;
                }
                y += khoangCachY;
            }
        }

        private void BtnGhe_Click(object sender, EventArgs e)
        {
            Button btnGhe = (Button)sender;
            if(btnGhe.BackColor == Color.Yellow)
            {
                MessageBox.Show("Ghế " + btnGhe.Text + " đã có người đặt!");
                return;
            }
            btnGhe.BackColor = (btnGhe.BackColor == Color.White) ? Color.Blue : Color.White;
        }

        private void btnMuaVe_Click(object sender, EventArgs e)
        {
            //tìm tất cả các ghế màu xanh
            double tongTien = 0;
            //Dictionary<int, double> danhSachGheVaGiaTien = new Dictionary<int, double>();
            List<int> danhSachGheDatMua = new List<int>();
            GHE gheDatMua;
            int soGhe;
            double giaTien;
            foreach(Button ghe in pnlHangGhe.Controls)
            {
                if(ghe.BackColor == Color.Blue)
                {
                    soGhe = int.Parse(ghe.Text);
                    gheDatMua = gheBT.LayGheTheoSoGhe(soGhe);
                    // giaTien = TinhTien(soGhe);
                    //giaTien = gheBT.LayGiaGheTheoSoGhe(soGhe);
                    giaTien = gheDatMua.HANGGHE.GiaTien;
                    tongTien += giaTien;
                    ghe.BackColor = Color.Yellow;
                    //danhSachGheVaGiaTien.Add(soGhe, giaTien);
                    danhSachGheDatMua.Add(gheDatMua.MaGhe);
                }
                txtTongTien.Text = tongTien.ToString();
                
            }
            //ThemHoaDon(tongTien);
            //ThemChiTietHoaDon(danhSachGheVaGiaTien);
            //lưu hóa đơn và chi tiết hóa đơn => database
            string error;
            HOADON hoaDon = new HOADON();
            hoaDon.NgayMua = DateTime.Now;
            hoaDon.TongTien = tongTien;
            if(hoaDonBT.LuuHoaDon(hoaDon, out error))
            {
                //save secessful
                CHITIETHOADON chiTietHoaDon;
                //n chi tiết hóa đơn
                foreach(int maGhe in danhSachGheDatMua)
                {
                    chiTietHoaDon = new CHITIETHOADON();
                    chiTietHoaDon.MaHoaDon = hoaDon.MaHoaDon;
                    chiTietHoaDon.MaGhe = maGhe;
                    if(chiTietHoaDonBT.LuuChiTietHoaDon(chiTietHoaDon, out error))
                    {
                        //save secessful
                        TaiDanhSachHoaDon();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi " + error);
                        return;
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Lỗi " + error);
                return;
            }
        }

        private void TaiDanhSachHoaDon()
        {
            //hiển thị danh sách hóa đơn trên datagridview
            //dgvHoaDon.DataSource = danh sách hóa đơn (MaHD, NgayMua, TongTien) thông qua DTO (data tranfer object)
            dgvHoaDon.DataSource = hoaDonBT.LayDanhSachHoaDon();
        }

        private void ThemChiTietHoaDon(Dictionary<int, double> danhSachGheVaGiaTien)
        {
            //DataTable
            DataRow row;
            foreach(KeyValuePair<int,double> item in danhSachGheVaGiaTien)
            {

                //khởi tạo 1 row mới
                row = dblChiTietHoaDon.NewRow();
                row[0] = "HD" + maHoaDon;
                row[1] = item.Key; //số ghế
                row[2] = item.Value; //giá tiền
                dblChiTietHoaDon.Rows.Add(row);
            }
        }

        private void ThemHoaDon(double tongTien)
        {
            maHoaDon++;
            //thêm dòng 
            int newRowIndex = dgvHoaDon.Rows.Add();
            dgvHoaDon.Rows[newRowIndex].Cells[0].Value = "HD" + maHoaDon;
            dgvHoaDon.Rows[newRowIndex].Cells[1].Value = DateTime.Now.ToShortDateString();
            dgvHoaDon.Rows[newRowIndex].Cells[2].Value = tongTien;
        }

       /* private float TinhTien(int soGhe)
        {
            if(soGhe <= 5)
            {
                return 5000;
            }
            else if(soGhe <= 10)
            {
                return 6500;
            }
            return 8000;
        }*/

        private void btnHuy_Click(object sender, EventArgs e)
        {
            foreach(Button item in pnlHangGhe.Controls)
            {
                if(item.BackColor == Color.Blue)
                {
                    item.BackColor = Color.White;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có chắc chắn thoát không?", "Thông báo",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(ret == DialogResult.Yes)
            {
                this.Close();
            }

        }

        //xử lý sự kiện khi click 1 hàng trên hóa đơn sẽ hiển thị chi tiết hóa đơn ở datagridview chi tiết hóa đơn
        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //e là sự kiện trên datagridview
            int rowIndex = e.RowIndex;
            int maHoaDonDangChon = int.Parse(dgvHoaDon.Rows[rowIndex].Cells[0].Value.ToString());

            //lấy chi tiết hóa đơn từ database
            dgvChiTietHoaDon.DataSource = chiTietHoaDonBT.LayDanhSachTheoMaHoaDon(maHoaDonDangChon);
            //lọc ra danh sách chi tiết từ ChiTietHoaDon theo mã hóa đơn được chọn
            /*DataTable tblChiTiet = dblChiTietHoaDon.AsEnumerable()
          .Where(row => row.Field<String>("Mã Hóa Đơn") == maHoaDonDangChon)
          .CopyToDataTable();
            dgvChiTietHoaDon.DataSource = tblChiTiet;*/
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
