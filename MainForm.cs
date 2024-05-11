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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if(currentFormChild != null) 
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
            MYDB mydb= new MYDB();
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
    }
}
