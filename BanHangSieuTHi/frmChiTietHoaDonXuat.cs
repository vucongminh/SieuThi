using BanHangSieuTHi.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanHangSieuTHi
{
    public partial class frmChiTietHoaDonXuat : Form
    {
        
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J9T3NL5;Initial Catalog=QLBanHangSieuThi;Integrated Security=True");
        sqlQuery truyVanDL = new sqlQuery();
        private string MaHD;

        public frmChiTietHoaDonXuat()
        {
            InitializeComponent();
        }

        public frmChiTietHoaDonXuat(string MaHDX) : this()
        {
            MaHD = MaHDX;
            txtHDX.Text = MaHD;
        }



        private void frmChiTietHoaDonXuat_Load(object sender, EventArgs e)
        {
            loadDBComBoxHangHoa();
            LoadDatagridView();
        }
        public void loadDBComBoxHangHoa()
        {           
            DataTable SP = truyVanDL.LayDuLieu("select * from HANGHOA");
            cmbHangHoa.DataSource = SP;
            cmbHangHoa.DisplayMember = "TenHang";
            AddBinding();
        }
        void AddBinding()
        {
            //vd: lấy dữ liệu của cmbSdtKH, Lấy trường MaKH đổ vào thuộc tính text của control txtMaKH.
            txtMaHang.DataBindings.Add(new Binding("Text", cmbHangHoa.DataSource, "MaHang"));
            txtMaLoai.DataBindings.Add(new Binding("Text", cmbHangHoa.DataSource, "MaLoai"));
            txtDonGia.DataBindings.Add(new Binding("Text", cmbHangHoa.DataSource, "GiaDeNghi"));
        }
        //load lại datagridview
        public void LoadDatagridView()
        {           
            DataTable dt = truyVanDL.LayDuLieu("select * from CHITIETXUAT where SoHDX= '" + txtHDX.Text.Trim() + "' ");
            dgvHangHoa.DataSource = dt;
        }


        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {        
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtHDX.Text = dgvHangHoa.CurrentRow.Cells["SoHDX"].Value.ToString().Trim();
                txtMaLoai.Text = dgvHangHoa.CurrentRow.Cells["MaLoai"].Value.ToString().Trim();
                txtMaHang.Text = dgvHangHoa.CurrentRow.Cells["MaHang"].Value.ToString().Trim();
                txtSoLuong.Text = dgvHangHoa.CurrentRow.Cells["SoLuong"].Value.ToString().Trim();
                txtDonGia.Text = dgvHangHoa.CurrentRow.Cells["DonGia"].Value.ToString().Trim();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int dem = Convert.ToInt32(truyVanDL.LayDuLieu("Select count(*) from chitietxuat where mahang = '"+txtMaHang.Text.Trim() +"' and SoHDX = '"+ txtHDX.Text.Trim() + "'").Rows[0][0].ToString().Trim());

            float tien = Convert.ToInt32(truyVanDL.LayDuLieu("select GiaDeNghi from HANGHOA where MaHang = '" + txtMaHang.Text.Trim() + "'").Rows[0][0].ToString().Trim()) * Convert.ToInt32(txtSoLuong.Text.Trim());
            if (dem >0 )
            {
                MessageBox.Show("Hàng này đã có");
            }
            else
            {

                if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("CHITIETXUAT_ThemChiTietHoaDon", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("SoHDX", SqlDbType.NChar)).Value = txtHDX.Text;
                    cmd.Parameters.Add(new SqlParameter("MaLoai", SqlDbType.NChar)).Value = txtMaLoai.Text;
                    cmd.Parameters.Add(new SqlParameter("MaHang", SqlDbType.NChar)).Value = txtMaHang.Text;
                    cmd.Parameters.Add(new SqlParameter("SoLuong", SqlDbType.Int)).Value = Convert.ToInt32(txtSoLuong.Text);
                    cmd.Parameters.Add(new SqlParameter("DonGia", SqlDbType.BigInt)).Value = tien;
                    cmd.ExecuteNonQuery(); //thực thi            

                    //load lại datagridview 
                    LoadDatagridView();
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {

            float tien = Convert.ToInt32(truyVanDL.LayDuLieu("select GiaDeNghi from HANGHOA where MaHang = '"+ txtMaHang.Text.Trim()+"'").Rows[0][0].ToString().Trim() ) * Convert.ToInt32(txtSoLuong.Text.Trim());
            float tongtien = Convert.ToInt32(truyVanDL.LayDuLieu("select sum(DonGia) from CHITIETXUAT where SoHDX = '" + txtHDX.Text.Trim() + "'").Rows[0][0].ToString().Trim());
            int id = Convert.ToInt32(truyVanDL.LayDuLieu("select ID from CHITIETXUAT where MaHang = '"+ txtMaHang.Text.Trim()+"' and SoHDX = '"+ txtHDX.Text.Trim() + "'").Rows[0][0].ToString().Trim());
            if (con.State == ConnectionState.Closed)
                con.Open();           
            SqlCommand cmd = new SqlCommand("CHITIETXUAT_SuaChiTietHoaDon", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("ID", SqlDbType.Int)).Value = id;
            cmd.Parameters.Add(new SqlParameter("SoLuong", SqlDbType.Int)).Value = txtSoLuong.Text;
            cmd.Parameters.Add(new SqlParameter("DonGia", SqlDbType.BigInt)).Value = tien;
            cmd.ExecuteNonQuery(); //thực thi
           
            LoadDatagridView();
            txtTongTien.Text = tongtien.ToString().Trim();         
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                if (con.State == ConnectionState.Closed)
                    con.Open();                
                SqlCommand cmd = new SqlCommand("CHITIETXUAT_XoaChiTietHoaDon", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("ID", SqlDbType.Int)).Value = dgvHangHoa.CurrentRow.Cells["ID"].Value.ToString().Trim();
                cmd.ExecuteNonQuery(); //thực thi       

                LoadDatagridView();
            }            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           frmHoaDon frmHD = new frmHoaDon(txtTongTien.Text); //Tạo Form2         
            //frmHD.ShowDialog();
        }
    }
}
