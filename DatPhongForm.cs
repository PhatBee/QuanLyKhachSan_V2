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

namespace QuanLyKhachSan
{
    public partial class DatPhongForm : Form
    {
        public DatPhongForm(string sophong)
        {
            InitializeComponent();
            tbxSoPhong.Text = sophong;
        }
        MYDB mydb = new MYDB();

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                HOADON hd = new HOADON();
                if (verif())
                {
                    string mahd = taoMaHD();
                    string maphong = tbxSoPhong.Text;
                    string kh = tbxKhach.Text;
                    string cccd = tbxCCCD.Text;
                    string sdt = tbxSDT.Text;
                    string ghichu = tbxGhiChu.Text;
                    DateTime dat = datiDat.Value;
                    DateTime tra = datiTra.Value;

                    if (hd.themHoaDon(mahd, maphong, kh, cccd, sdt, ghichu, dat, tra))
                    {
                        SqlCommand command = new SqlCommand("UPDATE Phong SET TinhTrang = 1 WHERE MaPhong = '" + maphong + "'", mydb.getConnection);
                        mydb.openConection();
                        if (command.ExecuteNonQuery() == 1)
                            MessageBox.Show("Đặt phòng thành công", "Đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mydb.closeConection();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi đặt phòng, vui lòng kiểm tra lại", "Đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string taoMaHD() 
        {
            MYDB mydb = new MYDB();
            SqlCommand cmd = new SqlCommand("SELECT MaHD FROM HoaDon", mydb.getConnection);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);

            int n = dt.Rows.Count;
            
            if (dt.Rows.Count > 0)
            {
                string mahd = dt.Rows[n - 1][0].ToString();

                string so = mahd.TrimStart(new char[] { 'H', 'D' });

                int soInt = int.Parse(so);
                soInt++;

                string kq = soInt.ToString("D3");

                return "HD" + kq;
            }    
            else
            {
                return "HD001";
            }    

            
        }

        private bool verif()
        {
            DateTime dat = datiDat.Value;
            DateTime tra = datiTra.Value;
            bool flag = false;
            if (dat < DateTime.Now)
            {
                MessageBox.Show("Thời gian đặt phòng không hợp lệ", "Đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }    
            else if (dat > tra)
            {
                MessageBox.Show("Thời gian đặt phòng không hợp lệ", "Đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
            else if (dat == tra)
            {
                MessageBox.Show("Thời gian đăng ký phòng phải ít nhất 1 ngày", "Đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tbxKhach.Text == "")
            {
                 MessageBox.Show("Vui lòng nhập tên khách hàng", "Đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            else if (tbxCCCD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số căn cước công dân", "Đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tbxSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!Regex.IsMatch(tbxKhach.Text, @"[\p{L}]+$"))
            {
                MessageBox.Show("Tên khách hàng không hợp lệ, tên chỉ bao gồm kí tự và khoảng trắng", "Đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!Regex.IsMatch(tbxCCCD.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Số căn cước không hợp lệ", "Đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!Regex.IsMatch(tbxSDT.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                flag = true;
            }    
            return flag;
        }

        private void DatPhongForm_Load(object sender, EventArgs e)
        {
            MYDB db = new MYDB();
            SqlCommand cmd = new SqlCommand("SELECT MaPhong, TenLoaiPhong, TinhTrang FROM Phong " +
                "INNER JOIN LoaiPhong ON Phong.MaLoaiPhong = LoaiPhong.MaLoaiPhong " +
                "WHERE MaPhong = @mp", db.getConnection);
            cmd.Parameters.Add("@mp", SqlDbType.VarChar).Value = tbxSoPhong.Text;
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                tbxLoaiPhong.Text = dt.Rows[0][1].ToString();
                if (dt.Rows[0][2].ToString() == "1")
                {
                    tbxTrangThai.Text = "Đang sử dụng";
                    tbxTrangThai.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    tbxTrangThai.Text = "Trống";
                    tbxTrangThai.ForeColor = System.Drawing.Color.Green;

                }
            }    

        }
    }
}
