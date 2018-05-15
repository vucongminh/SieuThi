using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using BanHangSieuTHi.Class;

namespace BanHangSieuTHi
{
    public partial class frmHoaDon : Form
    {
        private string TongTien;
        

        //Khai báo delegate
        public delegate void SendMessage(string Message);
        public SendMessage Sender;
        public frmHoaDon()
        {
            InitializeComponent();                   
        }

        public frmHoaDon(string tongtien) :this()
        {
            TongTien = tongtien;
            txtTongTien.Text = tongtien;
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J9T3NL5;Initial Catalog=QLBanHangSieuThi;Integrated Security=True");

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            loadListView();
            loadDBComBoxNhanVien();
            sqlQuery truyVanDL = new sqlQuery();
            DataTable da = truyVanDL.LayDuLieu("select N.SoHDN, N.MaNV, N.MaNCC, N.NgayNhap, N.ThanhTienNhap from HOADONNHAP N");
            dtgvDSHDN.DataSource = da;

            DataTable dtn = truyVanDL.LayDuLieu("select * from chitietnhap");
            dtgvCTHDN.DataSource = dtn;
        }

        public void loadListView()
        {
            lsvDSHDX.Items.Clear();
            sqlQuery truyVanDL = new sqlQuery();
            DataTable dt = truyVanDL.LayDuLieu("select * from HOADONXUAT ");                      

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem((i+1).ToString());
                
                item.SubItems.Add(dt.Rows[i][0].ToString());
                item.SubItems.Add(dt.Rows[i][1].ToString());
                item.SubItems.Add(dt.Rows[i][2].ToString());
                item.SubItems.Add(dt.Rows[i][3].ToString());
                item.SubItems.Add(dt.Rows[i][4].ToString());
                lsvDSHDX.Items.Add(item);
            }
        }
        //Load data lên txt
        private void lsvDSHDX_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lsvDSHDX.SelectedItems)
            {             
                txtMaHDX.Text = item.SubItems[1].Text.Trim();
                dTPNgayXuat.Text = item.SubItems[2].Text.Trim();
                cmbNhanVien.Text = item.SubItems[4].Text.Trim();
                txtKhachHang.Text = item.SubItems[5].Text.Trim();
            }
        }

        public void loadDBComBoxNhanVien()
        {
            sqlQuery truyvanDL = new sqlQuery();
            DataTable NV = truyvanDL.LayDuLieu("select MaNV from NHANVIEN");
            cmbNhanVien.DataSource = NV;
            cmbNhanVien.DisplayMember = "MaNV";
        }


        public void XoaHoaDon(string SoHDX)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string sql = "HOADONXUAT_XoaHoaDon";
            SqlCommand comd = new SqlCommand(sql, con);
            comd.CommandType = CommandType.StoredProcedure;
            comd.Parameters.Add(new SqlParameter("SoHDX", SqlDbType.NChar)).Value = SoHDX;
            comd.ExecuteNonQuery(); //thực thi

        }

        //THÊM SỬA XÓA CHITIETXUAT
        public void ThemChiTietHoaDon(string SoHDX, string MaLoai, string MaHang, int SoLuong, int DonGia)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string sql = "CHITIETXUAT_ThemChiTietHoaDon";
            SqlCommand comd = new SqlCommand(sql, con);
            comd.CommandType = CommandType.StoredProcedure;
            comd.Parameters.Add(new SqlParameter("SoHDX", SqlDbType.NChar)).Value = SoHDX;
            comd.Parameters.Add(new SqlParameter("MaLoai", SqlDbType.NChar)).Value = MaLoai;
            comd.Parameters.Add(new SqlParameter("MaHang", SqlDbType.NChar)).Value = MaHang;
            comd.Parameters.Add(new SqlParameter("SoLuong", SqlDbType.Int)).Value = SoLuong;
            comd.Parameters.Add(new SqlParameter("DonGia", SqlDbType.BigInt)).Value = DonGia;
            comd.ExecuteNonQuery(); //thực thi
        }

        public void SuaChiTietHoaDon( string SoHDX, string MaLoai, string MaHang, int SoLuong, int DonGia)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string sql = "CHITIETXUAT_SuaChiTietHoaDon";
            SqlCommand comd = new SqlCommand(sql, con);
            comd.CommandType = CommandType.StoredProcedure;
            //comd.Parameters.Add(new SqlParameter("ID", SqlDbType.Int)).Value =ID ;
            //comd.Parameters.Add(new SqlParameter("SoHDX", SqlDbType.NChar)).Value = SoHDX;
            //comd.Parameters.Add(new SqlParameter("MaLoai", SqlDbType.NChar)).Value = MaLoai;
            //comd.Parameters.Add(new SqlParameter("MaHang", SqlDbType.NChar)).Value = MaHang;
            comd.Parameters.Add(new SqlParameter("SoLuong", SqlDbType.Int)).Value = SoLuong;
            //comd.Parameters.Add(new SqlParameter("DonGia", SqlDbType.BigInt)).Value = DonGia;
            comd.ExecuteNonQuery(); //thực thi
        }

        public void XoaChiTietHoaDon(string ID)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string sql = "CHITIETXUAT_XoaChiTietHoaDon";
            SqlCommand comd = new SqlCommand(sql, con);
            comd.CommandType = CommandType.StoredProcedure;
            comd.Parameters.Add(new SqlParameter("ID", SqlDbType.Int)).Value = ID; 
            comd.ExecuteNonQuery(); //thực thi
        } 

        //private void dtgvDSHDX_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        //    {
        //        txtMaHDX.Text = dtgvDSHDX.CurrentRow.Cells["SoHDX"].Value.ToString().Trim();
        //        dTPNgayXuat.Text = dtgvDSHDX.CurrentRow.Cells["NgayXuat"].Value.ToString().Trim();
        //        txtNhanVien.Text = dtgvDSHDX.CurrentRow.Cells["MaNV"].Value.ToString().Trim();
        //        txtKhachHang.Text = dtgvDSHDX.CurrentRow.Cells["MaKH"].Value.ToString().Trim();
        //    }
        //}


        private void btnThemX_Click(object sender, EventArgs e)
        {
            txtTongTien.Text = "0";
            if (txtMaHDX.Text == "") { errorProvider1.SetError(txtMaHDX, "Bạn chưa nhập mã"); }
            if (cmbNhanVien.Text == "") { errorProvider1.SetError(cmbNhanVien, "Bạn chưa nhập Nhân viên"); }

            if (txtMaHDX.Text != "" && cmbNhanVien.Text != "")
            {
                
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("HOADONXUAT_ThemHoaDon", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("SoHDX", SqlDbType.NChar)).Value = txtMaHDX.Text;
                cmd.Parameters.Add(new SqlParameter("NgayXuat", SqlDbType.Date)).Value = dTPNgayXuat.Text;
                cmd.Parameters.Add(new SqlParameter("ThanhTienXuat", SqlDbType.BigInt)).Value = Convert.ToInt32(txtTongTien.Text);
                cmd.Parameters.Add(new SqlParameter("MaNV", SqlDbType.NChar)).Value = cmbNhanVien.Text;
                cmd.Parameters.Add(new SqlParameter("MaKH", SqlDbType.NChar)).Value = txtKhachHang.Text;
                cmd.ExecuteNonQuery(); //thực thi

                frmHoaDon_Load(sender, e);

                //frmChiTietHoaDonXuat frm = new frmChiTietHoaDonXuat();
                //frm.ShowDialog();
                MessageBox.Show("Thêm thành công!");
            }
        }

        private void btnXoaX_Click(object sender, EventArgs e)
        {
            if (txtMaHDX.Text == "") { errorProvider1.SetError(txtMaHDX, "Bạn chưa nhập mã"); }

            if (txtMaHDX.Text != "")
            {
                if (MessageBox.Show("Bạn muốn Xóa hóa đơn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //XoaChiTietHoaDon(txtMaHDX.Text);
                    XoaHoaDon(txtMaHDX.Text);
                    frmHoaDon_Load(sender, e);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmChiTietHoaDonXuat frm = new frmChiTietHoaDonXuat(txtMaHDX.Text);
            frm.ShowDialog();    
        }

        //THÊM SỬA XÓA HOADONNHAP
        public void themHoaDonN(string SoHDN, DateTime NgayNhap, int ThanhTienNhap, string MaNV, string MaNCC)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string sql = "HOADONNHAP_ThemHoaDonN";
                SqlCommand comd = new SqlCommand(sql, con);
                comd.CommandType = CommandType.StoredProcedure;
                comd.Parameters.Add(new SqlParameter("SoHDN", SqlDbType.NChar)).Value = SoHDN;
                comd.Parameters.Add(new SqlParameter("NgayNhap", SqlDbType.Date)).Value = NgayNhap;
                comd.Parameters.Add(new SqlParameter("ThanhTienNhap", SqlDbType.BigInt)).Value = ThanhTienNhap;
                comd.Parameters.Add(new SqlParameter("MaNV", SqlDbType.NChar)).Value = MaNV;
                comd.Parameters.Add(new SqlParameter("MaNCC", SqlDbType.NChar)).Value = MaNCC;
                comd.ExecuteNonQuery(); //thực thi
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SuaHoaDonN(string SoHDN, DateTime NgayNhap, int ThanhTienNhap, string MaNV, string MaNCC)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string sql = "HOADONNHAP_SuaHoaDonN";
            SqlCommand comd = new SqlCommand(sql, con);
            comd.CommandType = CommandType.StoredProcedure;
            comd.Parameters.Add(new SqlParameter("SoHDN", SqlDbType.NChar)).Value = SoHDN;
            comd.Parameters.Add(new SqlParameter("NgayNhap", SqlDbType.Date)).Value = NgayNhap;
            comd.Parameters.Add(new SqlParameter("ThanhTienNhap", SqlDbType.BigInt)).Value = ThanhTienNhap;
            comd.Parameters.Add(new SqlParameter("MaNV", SqlDbType.NChar)).Value = MaNV;
            comd.Parameters.Add(new SqlParameter("MaNCC", SqlDbType.NChar)).Value = MaNCC;
            comd.ExecuteNonQuery(); //thực thi

        }

        public void XoaHoaDonN(string SoHDN)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string sql = "HOADONNHAP_XoaHoaDonN";
            SqlCommand comd = new SqlCommand(sql, con);
            comd.CommandType = CommandType.StoredProcedure;
            comd.Parameters.Add(new SqlParameter("SoHDN", SqlDbType.NChar)).Value = SoHDN;
            comd.ExecuteNonQuery(); //thực thi

        }

        //THÊM SỬA XÓA CHITIETNHAP
        public void ThemChiTietHoaDonN(string SoHDN, string MaLoai, string MaHang, int SoLuongNhap, int DonGiaN, DateTime NgaySX, DateTime HSD)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string sql = "CHITIETNHAP_ThemChiTietHoaDonN";
            SqlCommand comd = new SqlCommand(sql, con);
            comd.CommandType = CommandType.StoredProcedure;
            comd.Parameters.Add(new SqlParameter("SoHDN", SqlDbType.NChar)).Value = SoHDN;
            comd.Parameters.Add(new SqlParameter("MaLoai", SqlDbType.NChar)).Value = MaLoai;
            comd.Parameters.Add(new SqlParameter("MaHang", SqlDbType.NChar)).Value = MaHang;
            comd.Parameters.Add(new SqlParameter("SoLuongNhap", SqlDbType.Int)).Value = SoLuongNhap;
            comd.Parameters.Add(new SqlParameter("DonGiaN", SqlDbType.BigInt)).Value = DonGiaN;
            comd.Parameters.Add(new SqlParameter("NgaySX", SqlDbType.Date)).Value = NgaySX;
            comd.Parameters.Add(new SqlParameter("HSD", SqlDbType.Date)).Value = HSD;
            comd.ExecuteNonQuery(); //thực thi
        }

        public void SuaChiTietHoaDonN(string SoHDN, string MaLoai, string MaHang, int SoLuongNhap, int DonGiaN, DateTime NgaySX, DateTime HSD)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string sql = "CHITIETNHAP_SuaChiTietHoaDonN";
            SqlCommand comd = new SqlCommand(sql, con);
            comd.CommandType = CommandType.StoredProcedure;
            comd.Parameters.Add(new SqlParameter("SoHDN", SqlDbType.NChar)).Value = SoHDN;
            comd.Parameters.Add(new SqlParameter("MaLoai", SqlDbType.NChar)).Value = MaLoai;
            comd.Parameters.Add(new SqlParameter("MaHang", SqlDbType.NChar)).Value = MaHang;
            comd.Parameters.Add(new SqlParameter("SoLuongNhap", SqlDbType.Int)).Value = SoLuongNhap;
            comd.Parameters.Add(new SqlParameter("DonGiaN", SqlDbType.BigInt)).Value = DonGiaN;
            comd.Parameters.Add(new SqlParameter("NgaySX", SqlDbType.Date)).Value = NgaySX;
            comd.Parameters.Add(new SqlParameter("HSD", SqlDbType.Date)).Value = HSD;
            comd.ExecuteNonQuery(); //thực thi
        }

        public void XoaChiTietHoaDonN(string ID)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string sql = "CHITIETNHAP_XoaChiTietHoaDonN";
            SqlCommand comd = new SqlCommand(sql, con);
            comd.CommandType = CommandType.StoredProcedure;
            comd.Parameters.Add(new SqlParameter("ID", SqlDbType.Int)).Value = ID;
            comd.ExecuteNonQuery(); //thực thi
        }

        private void dtgvDSHDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtMaHDN.Text = dtgvDSHDN.CurrentRow.Cells["SoHDN"].Value.ToString().Trim();
                dTPNgayNhap.Text = dtgvDSHDN.CurrentRow.Cells["NgayNhap"].Value.ToString().Trim();
                txtNhanVienN.Text = dtgvDSHDN.CurrentRow.Cells["MaNV"].Value.ToString().Trim();
                txtNhaCungCap.Text = dtgvDSHDN.CurrentRow.Cells["MaNCC"].Value.ToString().Trim();
            }
        }

        private void dtgvCTHDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtMaHangN.Text = dtgvCTHDN.CurrentRow.Cells["MaHang"].Value.ToString().Trim();
                txtMaLoaiN.Text = dtgvCTHDN.CurrentRow.Cells["MaLoai"].Value.ToString().Trim();
                txtDonGiaN.Text = dtgvCTHDN.CurrentRow.Cells["DonGiaN"].Value.ToString().Trim();
                txtSoLuongN.Text = dtgvCTHDN.CurrentRow.Cells["SoLuongNhap"].Value.ToString().Trim();
                dTPNSX.Text = dtgvCTHDN.CurrentRow.Cells["NgaySX"].Value.ToString().Trim();
                dTPHSD.Text = dtgvCTHDN.CurrentRow.Cells["HSD"].Value.ToString().Trim();
            }
        }

        private void btnThemN_Click(object sender, EventArgs e)
        {
            if (txtMaHDN.Text == "") { errorProvider1.SetError(txtMaHDN, "Bạn chưa nhập mã"); }
            if (txtNhanVienN.Text == "") { errorProvider1.SetError(txtNhanVienN, "Bạn chưa nhập Nhân viên"); }
            if (txtSoLuongN.Text == "") { errorProvider1.SetError(txtSoLuongN, "Bạn chưa nhập Số Luọng"); }
            if (txtDonGiaN.Text == "") { errorProvider1.SetError(txtDonGiaN, "Bạn chưa nhập Đơn Giá"); }

            if (txtMaHDN.Text != "" && txtNhanVienN.Text != "")
            {
                int thanhTien;
                thanhTien = Convert.ToInt32(txtSoLuongN.Text) * Convert.ToInt32(txtDonGiaN.Text);
                themHoaDonN(txtMaHDN.Text, dTPNgayNhap.Value, thanhTien, txtNhanVienN.Text, txtNhaCungCap.Text);
                ThemChiTietHoaDonN(txtMaHDN.Text, txtMaHangN.Text, txtMaLoaiN.Text, Convert.ToInt32(txtSoLuongN.Text), Convert.ToInt32(txtDonGiaN.Text),  dTPNSX.Value,  dTPHSD.Value);
                frmHoaDon_Load(sender, e);

            }
        }

        private void btnXoaN_Click(object sender, EventArgs e)
        {
            if (txtMaHDN.Text == "") { errorProvider1.SetError(txtMaHDN, "Bạn chưa nhập mã"); }

            if (txtMaHDN.Text != "")
            {
                //XoaChiTietHoaDonN(txtMaHDN.Text);
                XoaHoaDonN(txtMaHDN.Text);
                frmHoaDon_Load(sender, e);
            }
        }

        private void btnSuaN_Click(object sender, EventArgs e)
        {
            if (txtMaHDN.Text == "") { errorProvider1.SetError(txtMaHDN, "Bạn chưa nhập mã"); }
            if (txtNhanVienN.Text == "") { errorProvider1.SetError(txtNhanVienN, "Bạn chưa nhập Nhân viên"); }
            if (txtSoLuongN.Text == "") { errorProvider1.SetError(txtSoLuongN, "Bạn chưa nhập Số Luọng"); }
            if (txtDonGiaN.Text == "") { errorProvider1.SetError(txtDonGiaN, "Bạn chưa nhập Đơn Giá"); }

            if (txtMaHDN.Text != "" && txtNhanVienN.Text != "")
            {
                int thanhTien;
                thanhTien = Convert.ToInt32(txtSoLuongN.Text) * Convert.ToInt32(txtDonGiaN.Text);
                SuaHoaDonN(txtMaHDN.Text, dTPNgayNhap.Value, thanhTien, txtNhanVienN.Text, txtNhaCungCap.Text);
                SuaChiTietHoaDonN(txtMaHDN.Text, txtMaLoaiN.Text, txtMaHangN.Text, Convert.ToInt32(txtSoLuongN.Text), Convert.ToInt32(txtDonGiaN.Text), dTPNSX.Value, dTPHSD.Value);
                frmHoaDon_Load(sender, e);
            }
        }

        private void btnInHoaDonN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được cập nhật");
        }

        private void btnThemCTN_Click(object sender, EventArgs e)
        {
            ThemChiTietHoaDonN(txtMaHDN.Text, txtMaHangN.Text, txtMaLoaiN.Text, Convert.ToInt32(txtSoLuongN.Text), Convert.ToInt32(txtDonGiaN.Text), dTPNSX.Value, dTPHSD.Value);
            frmHoaDon_Load(sender, e);
        }

        private void btnXoaCTN_Click(object sender, EventArgs e)
        {
            XoaChiTietHoaDonN(dtgvCTHDN.CurrentRow.Cells["ID"].Value.ToString().Trim());
            frmHoaDon_Load(sender, e);
        }

        private void txtMaHDN_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMaHDN, "");

            try
            {
                sqlQuery truyVanDL = new sqlQuery();
                DataTable dt = truyVanDL.LayDuLieu("select * from CHITIETNHAP where SoHDn= '" + txtMaHDN.Text.Trim() + "'");
                dtgvCTHDN.DataSource = dt;
            }
            catch (Exception)
            {

            }
        }
    }
}
