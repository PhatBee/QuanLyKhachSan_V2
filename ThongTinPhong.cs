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

namespace QuanLyKhachSan
{
    public partial class ThongTinPhong : Form
    {
        public ThongTinPhong(string maphong)
        {
            InitializeComponent();
            tbxSoPhong.Text = maphong;
        }

        DataTable dt = new DataTable();

        private void ThongTinPhong_Load(object sender, EventArgs e)
        {
            MYDB mydb = new MYDB();
            SqlCommand cmd = new SqlCommand("SELECT MaHD, HoaDon.MaPhong, TenLoaiPhong, DonGia, TenKH, CCCD, SDT, NgayDat, NgayTra, TinhTrang FROM HOADON " +
                "INNER JOIN Phong ON HoaDon.MaPhong = Phong.MaPhong " +
                "INNER JOIN LoaiPhong ON Phong.MaLoaiPhong = LoaiPhong.MaLoaiPhong " +
                "WHERE TinhTrang = 1 and ChiPhi is NULL and HoaDon.MaPhong = @mp", mydb.getConnection);
            cmd.Parameters.Add("@mp", SqlDbType.VarChar).Value = tbxSoPhong.Text;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                tbxGiaPhong.Text = dt.Rows[0]["DonGia"].ToString();
                datiVao.Value = (DateTime)dt.Rows[0]["NgayDat"];
                datiRa.Value = (DateTime)dt.Rows[0]["NgayTra"];
                tbxLoaiPhong.Text = dt.Rows[0]["TenLoaiPhong"].ToString();
                tbxTenKH.Text = dt.Rows[0]["TenKH"].ToString();
                tbxCCCD.Text = dt.Rows[0]["CCCD"].ToString();
                tbxSDT.Text = dt.Rows[0]["SDT"].ToString();

            }
            else
            {
                MessageBox.Show("Phòng đang trống", "Thông tin phòng", MessageBoxButtons.OK, MessageBoxIcon.Information );
                this.Close();
            }

            SqlCommand cmd2 = new SqlCommand("SELECT * FROM DichVu", mydb.getConnection);
            SqlDataAdapter adpt2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adpt2.Fill(dt2);

            cbxDV.DataSource = dt2;
            cbxDV.DisplayMember = "TenDV";
            cbxDV.ValueMember = "MaDV";

            SqlCommand cmd3 = new SqlCommand("SELECT MaPhong, TenDV 'Tên Dịch Vụ', DonGia 'Đơn Giá', Count(TenDV) 'Số Lượng', Sum(DonGia) 'Tổng' " +
                "FROM DichVuPhong INNER JOIN DichVu ON DichVu.MaDV = DichVuPhong.MaDV " +
                "Where MaPhong = @maphong and MaHD = @mahd " +
                "GROUP BY TenDV, DonGia, MaPhong", mydb.getConnection);
            cmd3.Parameters.Add("@maphong", SqlDbType.VarChar).Value = tbxSoPhong.Text;
            cmd3.Parameters.Add("@mahd", SqlDbType.VarChar).Value = dt.Rows[0]["MaHD"].ToString();
            DataTable dt3 = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd3);
            adapter.Fill(dt3);
            dataGridView1.DataSource = dt3;
            dataGridView1.AllowUserToAddRows = false;

            int tongTienDichVu = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Kiểm tra nếu hàng không phải là hàng mới thêm và không phải là hàng header
                if (!row.IsNewRow)
                {
                    tongTienDichVu += Convert.ToInt32(row.Cells[4].Value.ToString());          // Chỉnh lại thứ tự của cột nếu đã ẩn đi MaPhong                                                          
                }
            }
            lblTienDV.Text = tongTienDichVu.ToString();
            TimeSpan kc = datiRa.Value - datiVao.Value;
            int songay = (int)kc.TotalDays;
            lblSoNgay.Text = songay.ToString();

            lblGiaPhong.Text = tbxGiaPhong.Text;

            lblTienPhong.Text = (songay * Convert.ToInt32(lblGiaPhong.Text)).ToString();

            lblThanhToan.Text = (Convert.ToInt32(lblTienPhong.Text) + Convert.ToInt32(lblTienDV.Text)).ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            MYDB mydb = new MYDB();

            string maHD = dt.Rows[0]["MaHD"].ToString();
            string maDV = cbxDV.SelectedValue.ToString();

            // Xử lý xem dịch vụ còn trong kho không
            SqlCommand commandCheckSoLuong = new SqlCommand("Select SoLuong FROM DichVu WHERE MaDV = '" + maDV + "' ", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(commandCheckSoLuong);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            int soLuong = Convert.ToInt32(dataTable.Rows[0][0]);
            if (soLuong <= 0)
            {
                MessageBox.Show("Dịch vụ đã hết, vui lòng chọn dịch vụ khác", "Kiểm tra dịch vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Code xử lý thêm dịch vụ
            SqlCommand command = new SqlCommand("INSERT INTO DichVuPhong (MaHD, MaPhong, MaDV) values (@mahd, @mapg, @madv)", mydb.getConnection);
            command.Parameters.Add("@mahd", SqlDbType.VarChar).Value = maHD;
            command.Parameters.Add("@mapg", SqlDbType.VarChar).Value = tbxSoPhong.Text;
            command.Parameters.Add("@madv", SqlDbType.VarChar).Value = maDV;
            mydb.openConection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Thêm dịch vụ thành công", "Thêm dịch vụ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                capNhatSoLuong(maDV, soLuong);       // Cập nhật lại số lượng dịch vụ có thể cung cấp cho khách hàng
                mydb.closeConection();
            }
            else
            {
                MessageBox.Show("Lỗi", "Thêm dịch vụ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mydb.closeConection();
            }

            ThongTinPhong_Load(sender, e);
        }

        public void capNhatSoLuong(string maDV, int soLuong)
        {
            MYDB mydb = new MYDB();
            soLuong -= 1;
            SqlCommand command = new SqlCommand("UPDATE DichVu SET SoLuong = '" + soLuong + "' Where maDV = '" + maDV + "'", mydb.getConnection);
            mydb.openConection();
            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConection();
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mydb.closeConection();
            }
        }
    }
}
