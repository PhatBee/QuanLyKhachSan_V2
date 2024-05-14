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
    public partial class UserControlRoom : UserControl
    {
        string soPhong, loaiPhong;
        bool tinhTrang;
        MYDB mydb = new MYDB();
        public UserControlRoom(string sophong, string loaiphong, bool tinhtrang)
        {
            InitializeComponent();
            this.soPhong = sophong;
            this.loaiPhong = loaiphong;
            this.tinhTrang = tinhtrang;
        }

        private void UserControlRoom_Load(object sender, EventArgs e)
        {

        }

        public void fillData(string sophong, string loaiphong, bool tinhtrang)
        {
            lblSoPhong.Text = sophong;
            lblLoaiPhong.Text = loaiphong;
            if (tinhtrang == true)
            {
                this.BackColor = Color.FromArgb(246, 213, 217);
                lblTinhTrang.Text = "Đang sử dụng";
                lblTinhTrang.ForeColor = Color.Red;
            }
            else
            {
                lblTinhTrang.Text = "Còn trống";
                lblTinhTrang.ForeColor = Color.Green;
            }
        }

        private void UserControlRoom_Click(object sender, EventArgs e)
        {
            if (tinhTrang == true)
            {
                string maphong = lblSoPhong.Text;
                ThongTinPhong frm = new ThongTinPhong(maphong);
                frm.ShowDialog();
            }

        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            if (this.tinhTrang == false)
            {
                string maphong = lblSoPhong.Text.ToString();
                DatPhongForm frm = new DatPhongForm(maphong);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Phòng đã có người thuê!", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            try
            {
                if (tinhTrang == true)
                {
                    DialogResult result = MessageBox.Show("Xác nhận trả phòng", "Hệ thống", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        ThanhToanForm thanhToanForm = new ThanhToanForm(soPhong);
                        thanhToanForm.ShowDialog();
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Hệ thống",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


    }
}
