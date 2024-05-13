using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        MYDB mydb = new MYDB();

        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnMain.Controls.Add(childForm);
            pnMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MYDB mydb = new MYDB();
            string userid = Globals.GlobalUserID;
            SqlCommand command = new SqlCommand("SELECT MaNV, TenNV, TenCV FROM NhanVien " +
                "INNER JOIN ChucVu ON NhanVien.MaCV = ChucVu.MaCV " +
                "WHERE MaNV = @userid", mydb.getConnection);
            command.Parameters.Add("userid", SqlDbType.VarChar).Value = userid;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lblChucVu.Text = dt.Rows[0][2].ToString();
                lblHoten.Text = dt.Rows[0][1].ToString();
            }
            hienThiThoiGianLamViec();
            //tinhLuongNhanVien();

        }

        public void hienThiThoiGianLamViec()
        {
            //DateTime tmp = DateTime.Now;
            DateTime tmp = new DateTime(2024, 05, 15);

            DateTime.TryParse(tmp.ToString(), out DateTime ngay);
            SqlCommand command = new SqlCommand("Select ChiTiet From PhanCong INNER JOIN Ca on PhanCong.MaCa = Ca.MaCa Where MaNV = @manv And Ngay = @date ", mydb.getConnection);
           

            command.Parameters.Add("@date", SqlDbType.Date).Value = ngay;
            command.Parameters.Add("manv", SqlDbType.VarChar).Value = Globals.GlobalUserID;
            //MessageBox.Show(Globals.GlobalUserID);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            string tg = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tg += dt.Rows[i][0].ToString();
                    if(i<dt.Rows.Count-1)
                    {
                        tg += " và ";
                    }    
                }
            }
            if (dt.Rows.Count <= 0)
            {
                label3.Text = "Ca làm việc: Hôm nay bạn không có ca làm việc!";
                picCheckIn.Hide();
                picCheckOut.Hide();
                lblCheckIn.Hide();
                lblCheckOut.Hide();
                
            }
            else
            {
                label3.Text = "Ca làm việc: " + tg;
            }    
            
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnDSPhong_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnDSPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DSPhongForm());
        }

        private void picHome_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
        }


        private void pnDSChiTiet_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChiTietKhachHangForm());
        }

        private void pnPhanCong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhanCongForm());
        }

        private void pnQLNV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyNhanVienForm());
        }

        private void lblDSPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DSPhongForm());
        }

        private void picDSPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DSPhongForm());
        }

        private void lblDSChiTiet_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChiTietKhachHangForm());
        }

        private void picDSChiTiet_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChiTietKhachHangForm());
        }

        private void picPhanCong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhanCongForm());
        }

        private void pnQLNV_Paint(object sender, PaintEventArgs e)
        {
            OpenChildForm(new QuanLyNhanVienForm());
        }

        private void picQLNV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyNhanVienForm());
        }

        private void pnLichTruc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LichTrucForm());
        }

        private void lblLichTruc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LichTrucForm());
        }

        private void picLichTruc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LichTrucForm());
        }

        private void pnDiemDanh_Click(object sender, EventArgs e)
        {
            DiemDanhForm diemDanhForm = new DiemDanhForm();
            diemDanhForm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            /*try
            {


                DateTime tmp = new DateTime(2024, 05, 11);
                DateTime.TryParse(tmp.ToString(), out DateTime ngay);

                SqlCommand cmd = new SqlCommand("SELECT * FROM PhanCong Where MaNV = @manv AND Ngay = @ngay", mydb.getConnection);
                cmd.Parameters.Add("@manv", SqlDbType.VarChar).Value = Globals.GlobalUserID;
                cmd.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);

                if (dt.Rows.Count > 0 ) 
                {
                    SqlCommand command = new SqlCommand("UPDATE PhanCong Set TgVaoLam = @tgbd Where MaNV = @manv AND Ngay = @ngay", mydb.getConnection);
                    command.Parameters.Add("@tgbd", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@manv", SqlDbType.VarChar).Value = Globals.GlobalUserID;
                    command.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
                    mydb.openConection();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Check in thành công!", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }


                mydb.closeConection();
                
                
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
            //LoginFaceID faceID = new LoginFaceID();
            OpenChildForm(new LoginFaceID());

        }

        private void picCheckOut_Click(object sender, EventArgs e)
        {
            try
            {


                DateTime tmp = new DateTime(2024, 05, 11);
                DateTime.TryParse(tmp.ToString(), out DateTime ngay);

                SqlCommand cmd = new SqlCommand("SELECT * FROM PhanCong Where MaNV = @manv AND Ngay = @ngay", mydb.getConnection);
                cmd.Parameters.Add("@manv", SqlDbType.VarChar).Value = Globals.GlobalUserID;
                cmd.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    SqlCommand command = new SqlCommand("UPDATE PhanCong Set TgRaKetThuc = @tgkt Where MaNV = @manv AND Ngay = @ngay", mydb.getConnection);
                    command.Parameters.Add("@tgkt", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@manv", SqlDbType.VarChar).Value = Globals.GlobalUserID;
                    command.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
                    mydb.openConection();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Check out thành công!","Hệ Thống",MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


                mydb.closeConection();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            tinhLuongNhanVien();
        }

        public void tinhLuongNhanVien()
        {
            DateTime tmp = new DateTime(2024, 05, 16);
            DateTime.TryParse(tmp.ToString(), out DateTime ngay);
            SqlCommand cmd = new SqlCommand("SELECT TgVaoLam, TgRaKetThuc FROM PhanCong Where MaNV = @manv AND Ngay = @ngay", mydb.getConnection);
            cmd.Parameters.Add("@manv", SqlDbType.VarChar).Value = Globals.GlobalUserID;
            cmd.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            
            if(dt.Rows.Count > 0 )
            {
                int hoursDifference;
                if (dt.Rows[0]["TgVaoLam"].ToString() == "" || dt.Rows[0]["TgRaKetThuc"].ToString() == "")
                {
                    hoursDifference = 0;
                }                        
                else
                {
                    DateTime TgBatDau = Convert.ToDateTime(dt.Rows[0]["TgVaoLam"].ToString());
                    DateTime TgKetThuc = Convert.ToDateTime(dt.Rows[0]["TgRaKetThuc"].ToString());
                    TimeSpan timeDifference = TgKetThuc.Subtract(TgBatDau);
                    hoursDifference = Convert.ToInt32(Math.Round(timeDifference.TotalHours, 2));
                }    
                

                SqlCommand command = new SqlCommand("UPDATE PhanCong Set TongSoGioLam = @tsgl Where MaNV = @manv AND Ngay = @ngay", mydb.getConnection);
                command.Parameters.Add("@tsgl", SqlDbType.Int).Value = hoursDifference;
                command.Parameters.Add("@manv", SqlDbType.VarChar).Value = Globals.GlobalUserID;
                command.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
                mydb.openConection();
                command.ExecuteNonQuery();

                mydb.closeConection();
            } 
            
           
            //MessageBox.Show(hoursDifference.ToString());


        }
    }
}
