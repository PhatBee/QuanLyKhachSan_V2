using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyKhachSan
{
    public partial class ChiTietKhachHangForm : Form
    {
        public ChiTietKhachHangForm()
        {
            InitializeComponent();
        }

        private void ChiTietKhachHangForm_Load(object sender, EventArgs e)
        {
            MYDB mydb = new MYDB();
            SqlCommand cmd = new SqlCommand("SELECT MaHD, MaPhong, TenKH, CCCD, SDT, GhiChu, NgayDat, NgayTra FROM HoaDon",mydb.getConnection);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                row["NgayDat"] = ((DateTime)row["NgayDat"]).ToString("dd/MM/yyyy");
                row["NgayTra"] = ((DateTime)row["NgayTra"]).ToString("dd/MM/yyyy");
            }

            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            MYDB mydb = new MYDB();

            tbxSoHoaDon.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cbxPhong.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxTen.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbxCCCD.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbxSdt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tbxNoiDung.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            MYDB mydb = new MYDB();
            SqlCommand command = new SqlCommand("SELECT * FROM HoaDon WHERE MaHD LIKE'%" + tbxTimID.Text + "%'", mydb.getConnection);
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            if (table.Rows.Count == 0)
            {

                MessageBox.Show("Không có kết quả tương ứng", "Tìm kiếm ID hoá đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dataGridView1.DataSource = table;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            HOADON hd = new HOADON();
            if (verif())
            {
                string mahd = tbxSoHoaDon.Text;
                string maphong = cbxPhong.Text;
                string kh = tbxTen.Text;
                string cccd = tbxCCCD.Text;
                string sdt = tbxSdt.Text;
                string ghichu = tbxNoiDung.Text;
              

                if (hd.capNhatKhachHang(mahd, maphong, kh, cccd, sdt, ghichu))
                {
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công", "Thông tin khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin khách hàng thất bại, vui lòng kiểm tra thông tin", "Thông tin khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private bool verif()
        {
            bool flag = false;
            if (tbxTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng", "Đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tbxCCCD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số căn cước công dân", "Đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tbxSdt.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!Regex.IsMatch(tbxTen.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Tên khách hàng không hợp lệ, tên chỉ bao gồm kí tự và khoảng trắng", "Đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!Regex.IsMatch(tbxCCCD.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Số căn cước không hợp lệ", "Đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!Regex.IsMatch(tbxSdt.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    
}
