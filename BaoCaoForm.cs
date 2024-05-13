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
    public partial class BaoCaoForm : Form
    {
        MYDB mydb = new MYDB();
        BAOCAO bc = new BAOCAO();
        public BaoCaoForm()
        {
            InitializeComponent();
        }

        private void BaoCaoForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            DateTime ngay = dateTimePicker1.Value.Date;

            tinhToanLamViec();

            SqlCommand cmd = new SqlCommand("SELECT PhanCong.MaNV, MaCV, Ngay, Sum(TongSoGioLam) as 'TongGioLam', Sum(Tre) as 'Tre' " +
                "FROM PhanCong " +
                "INNER JOIN NhanVien ON PhanCong.MaNV = NhanVien.MaNV " +
                "WHERE Ngay = @ngay " +
                "GROUP BY PhanCong.MaNV, MaCV, Ngay", mydb.getConnection);
            cmd.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    string manv = row[0].ToString();
                    int tonggiolam = Convert.ToInt32(row[3].ToString());
                    int tonggiotre = Convert.ToInt32(row[4].ToString());
                    string chucvu = row[1].ToString();
                    int luong;

                    if (chucvu == "CV002")
                    {
                        luong = tonggiolam * 60000 - tonggiotre * 120000;
                    }    
                    else if (chucvu == "CV003")
                    {
                        luong = tonggiolam * 40000 - tonggiotre * 80000;
                    }
                    else
                    {
                        luong = 0;
                    }

                    if (bc.themBaoCao(manv, ngay, tonggiolam, tonggiotre, luong, 0))
                    {

                    }

                }
            } 
                
        }

        private void tinhToanLamViec()
        {
            DateTime ngay = dateTimePicker1.Value.Date;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngay = dateTimePicker1.Value.Date;

            SqlCommand cmd = new SqlCommand("SELECT * FROM BaoCao WHERE ngay = @ngay", mydb.getConnection);
            cmd.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            if (dt.Rows.Count > 0 )
            {
                btnTaoBaoCao.Enabled = false;
                dataGridView1.DataSource = dt;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;

            }
            else if (dateTimePicker1.Value.Date  == DateTime.Now.Date)
            {
                btnTaoBaoCao.Enabled = false ;
            }
            else
            {
                btnTaoBaoCao.Enabled = true ;
            }

            SqlCommand cmd2 = new SqlCommand("SELECT * FROM BaoCao WHERE ngay = @ngay and XacNhan = @xn", mydb.getConnection);
            cmd2.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
            cmd2.Parameters.Add("@xn", SqlDbType.Bit).Value = 1;
            SqlDataAdapter adpt2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adpt2.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {
                btnXacNhan.Enabled = false;

            }
            else if (dateTimePicker1.Value.Date == DateTime.Now.Date)
            {
                btnXacNhan.Enabled = false;
            }
            else
            {
                btnXacNhan.Enabled = true;
            }


        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DateTime ngay = dateTimePicker1.Value.Date;

            SqlCommand cmd = new SqlCommand("SELECT MaNV, Luong FROM BaoCao WHERE ngay = @ngay and XacNhan = @xn", mydb.getConnection);
            cmd.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
            cmd.Parameters.Add("@xn", SqlDbType.Bit).Value = 0;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            if (dt.Rows.Count > 0 )
            {
                foreach(DataRow dr in dt.Rows) 
                {
                    string manv = dr[0].ToString();
                    int luong = int.Parse(dr[1].ToString());

                    capNhatLuongNhanVien(manv, luong);
                    capNhatXacNhan(manv, ngay);
                }
            }    
        }

        private void capNhatXacNhan(string manv, DateTime ngay)
        {
            SqlCommand cmd = new SqlCommand("UPDATE BaoCao Set XacNhan = @xn WHERE MaNV = @manv and Ngay = @ngay", mydb.getConnection);
            cmd.Parameters.Add("@xn", SqlDbType.Bit).Value = 1;
            cmd.Parameters.Add("@manv", SqlDbType.VarChar).Value = manv;
            cmd.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;

            mydb.openConection();

            if (cmd.ExecuteNonQuery() == 1)
            {
                mydb.closeConection();
            }
            else
            {
                mydb.closeConection();
                MessageBox.Show("Lỗi rồi con dog");
            }
            
        }

        private void capNhatLuongNhanVien(string manv, int luong)
        {
            SqlCommand cmd = new SqlCommand("SELECT Luong FROM NhanVien WHERE MaNV = @manv", mydb.getConnection);
            cmd.Parameters.Add("@manv", SqlDbType.VarChar).Value = manv;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            if (dt.Rows.Count > 0 )
            {
                int luongmoi = Convert.ToInt32(dt.Rows[0][0].ToString()) + luong;

                SqlCommand cmd2 = new SqlCommand("UPDATE NhanVien Set Luong = @luong WHERE MaNV = @manv", mydb.getConnection);
                cmd2.Parameters.Add("@manv", SqlDbType.VarChar).Value = manv;
                cmd2.Parameters.Add("@luong", SqlDbType.Int).Value = luongmoi;

                mydb.openConection();

                if (cmd2.ExecuteNonQuery() == 1) 
                {
                    mydb.closeConection();
                }
                else
                {
                    mydb.closeConection();
                    MessageBox.Show("Lỗi rồi con dog");
                }    

            }

        }
    }
}
