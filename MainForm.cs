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
            
            hienThiChucNang(lblChucVu.Text);

            hienThiCaHienTai();

            hienThiThoiGianLamViec();
            // tinhLuongNhanVien();

        }

        private void hienThiChucNang(string text)
        {
            if (text == "Tiếp Tân")
            {
                pnPhanCong.Visible = false;
                pnThongKe.Visible = false;
                pnBaoCao.Visible = false;
            }    
            else if (text == "Lao Công")
            {
                pnPhanCong.Visible = false;
                pnThongKe.Visible = false;
                pnBaoCao.Visible = false;
                pnQLNV.Visible = false;
                pnDSChiTiet.Visible = false;
                pnDSPhong.Visible = false ;
            }    
        }

        private void hienThiCaHienTai()
        {
            SqlCommand cmd = new SqlCommand("SELECT MaCa, TgVao, TgRa FROM Ca", mydb.getConnection);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            TimeSpan thoiGianHienTai = DateTime.Now.TimeOfDay; // Lấy thời gian hiện tại

            foreach (DataRow row in dt.Rows)
            {
                TimeSpan thoiGianVao = ((DateTime)row["TgVao"]).TimeOfDay; // Lấy thời gian vào từ cột "TgVao" và chỉ lấy phần thời gian
                TimeSpan thoiGianRa = ((DateTime)row["TgRa"]).TimeOfDay; // Lấy thời gian vào từ cột "TgRa" và chỉ lấy phần thời gian

                if (thoiGianHienTai >= thoiGianVao && (thoiGianHienTai <= thoiGianRa || thoiGianRa == TimeSpan.Zero)) // Giả sử mỗi ca kéo dài 4 giờ
                {
                    string maCa = row["MaCa"].ToString(); // Lấy mã ca từ cột "MaCa"

                    label3.Text = maCa;
                    break; // Dừng vòng lặp sau khi tìm thấy ca phù hợp
                }
            }    
        }

        public void hienThiThoiGianLamViec()
        {
            //DateTime tmp = DateTime.Now;
            DateTime ngay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            SqlCommand command = new SqlCommand("Select PhanCong.MaCa as 'Mã Ca', ChiTiet From PhanCong INNER JOIN Ca on PhanCong.MaCa = Ca.MaCa Where MaNV = @manv And Ngay = @date and PhanCong.MaCa = @maca", mydb.getConnection);
           

            command.Parameters.Add("@date", SqlDbType.Date).Value = ngay;
            command.Parameters.Add("@manv", SqlDbType.VarChar).Value = Globals.GlobalUserID;
            command.Parameters.Add("@maca", SqlDbType.VarChar).Value = label3.Text;
            //MessageBox.Show(Globals.GlobalUserID);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            string tg = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tg += dt.Rows[i][1].ToString();
                    if (i < dt.Rows.Count - 1)
                    {
                        tg += " và ";
                    }
                }
            }
            if (dt.Rows.Count <= 0)
            {
                label3.Text = "Ca làm việc: Hôm nay bạn không có ca làm việc!";
                /*picCheckIn.Hide();
                picCheckOut.Hide();
                lblCheckIn.Hide();
                lblCheckOut.Hide();*/

            }
            else
            {

                // label4.Text = "Ca làm việc: " + dt.Rows[0][0].ToString();
                label4.Text = tg;
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


                DateTime ngay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                SqlCommand cmd = new SqlCommand("SELECT * FROM PhanCong Where MaNV = @manv AND Ngay = @ngay AND MaCa = @maca", mydb.getConnection);
                cmd.Parameters.Add("@manv", SqlDbType.VarChar).Value = Globals.GlobalUserID;
                cmd.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
                cmd.Parameters.Add("@maca", SqlDbType.VarChar).Value = label3.Text;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);

                if (dt.Rows.Count > 0 ) 
                {
                    SqlCommand command = new SqlCommand("UPDATE PhanCong Set TgVaoLam = @tgbd Where MaNV = @manv AND Ngay = @ngay AND MaCa = @maca", mydb.getConnection);
                    command.Parameters.Add("@tgbd", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@manv", SqlDbType.VarChar).Value = Globals.GlobalUserID;
                    command.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
                    command.Parameters.Add("@maca", SqlDbType.VarChar).Value = label3.Text;

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


                DateTime ngay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);


                SqlCommand cmd = new SqlCommand("SELECT * FROM PhanCong Where MaNV = @manv AND Ngay = @ngay AND MaCa = @maca", mydb.getConnection);
                cmd.Parameters.Add("@manv", SqlDbType.VarChar).Value = Globals.GlobalUserID;
                cmd.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
                cmd.Parameters.Add("@maca", SqlDbType.VarChar).Value = label3.Text;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    SqlCommand command = new SqlCommand("UPDATE PhanCong Set TgRaKetThuc = @tgkt Where MaNV = @manv AND Ngay = @ngay AND MaCa = @maca", mydb.getConnection);
                    command.Parameters.Add("@tgkt", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@manv", SqlDbType.VarChar).Value = Globals.GlobalUserID;
                    command.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
                    command.Parameters.Add("@maca", SqlDbType.VarChar).Value = label3.Text;
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

            tinhGioLamViec();
        }

        public void tinhGioLamViec()
        {
            DateTime ngay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            SqlCommand cmd = new SqlCommand("SELECT TgVaoLam, TgRaKetThuc FROM PhanCong Where MaNV = @manv AND Ngay = @ngay AND MaCa = @maca", mydb.getConnection);
            cmd.Parameters.Add("@manv", SqlDbType.VarChar).Value = Globals.GlobalUserID;
            cmd.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
            cmd.Parameters.Add("@maca", SqlDbType.VarChar).Value = label3.Text;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            
            DateTime TgBatDau = Convert.ToDateTime(dt.Rows[0]["TgVaoLam"].ToString());
            DateTime TgKetThuc = Convert.ToDateTime(dt.Rows[0]["TgRaKetThuc"].ToString());

            int hoursDifference;
            
            TimeSpan timeDifference = TgKetThuc.Subtract(TgBatDau);
            hoursDifference = Convert.ToInt32(Math.Round(timeDifference.TotalHours,2));

            SqlCommand command = new SqlCommand("UPDATE PhanCong Set TongSoGioLam = @tsgl, Tre = @tre Where MaNV = @manv AND Ngay = @ngay AND MaCa = @maca", mydb.getConnection);
            command.Parameters.Add("@tsgl", SqlDbType.Int).Value =hoursDifference;
            command.Parameters.Add("@manv", SqlDbType.VarChar).Value = Globals.GlobalUserID;
            command.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
            command.Parameters.Add("@maca", SqlDbType.VarChar).Value = label3.Text;
            command.Parameters.Add("@tre", SqlDbType.Int).Value = 4 - hoursDifference;
            mydb.openConection();
            command.ExecuteNonQuery();



            mydb.closeConection();
            //MessageBox.Show(hoursDifference.ToString());


        }

        private void pnBaoCao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaoCaoForm());
        }

        private void lblBaoCao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaoCaoForm());

        }

        private void picBaoCao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaoCaoForm());

        }

        private void pnThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongKeChiTieuForm());
        }

        private void lblThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongKeChiTieuForm());
        }

        private void picThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongKeChiTieuForm());
        }
    }
}
