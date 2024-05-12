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

        }

        public void hienThiThoiGianLamViec()
        {
            string ngay = DateTime.Now.Date.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string fullDate = month + "/" + "15" + "/" + year;
            SqlCommand command = new SqlCommand("Select ChiTiet From PhanCong INNER JOIN Ca on PhanCong.MaCa = Ca.MaCa Where MaNV = @manv And Ngay = @date ", mydb.getConnection);
            DateTime.TryParse(fullDate.ToString(), out DateTime date);

            command.Parameters.Add("@date", SqlDbType.Date).Value = date;
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
                    tg += dt.Rows[i][0].ToString() + " ";
                }
            }
            if (dt.Rows.Count <= 0)
            {
                label3.Text = "Ca làm việc: Hôm nay bạn không có ca làm việc";
            }
            else
            {
                label3.Text = "Ca làm việc " + tg;
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
            try
            {


                DateTime tmp = new DateTime(2024, 05, 15);
                DateTime.TryParse(tmp.ToString(), out DateTime ngay);
                SqlCommand command = new SqlCommand("Update PhanCong Set TgVaoLam = @tgbd Where MaNV = @manv AND Ngay = @ngay", mydb.getConnection);
                command.Parameters.Add("@tgbd", SqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("@manv", SqlDbType.VarChar).Value = Globals.GlobalUserID;
                command.Parameters.Add("@ngay", SqlDbType.Date).Value = ngay;

                mydb.openConection();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("OK");
                    mydb.closeConection();
                }
                else
                {
                    MessageBox.Show("ERRR");
                    mydb.closeConection();
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
