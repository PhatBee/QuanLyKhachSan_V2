using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class UserControlRoom : UserControl
    {
        public UserControlRoom()
        {
            InitializeComponent();
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
                lblTinhTrang.ForeColor= Color.Green;
            }
        }

        private void UserControlRoom_Click(object sender, EventArgs e)
        {
            string maphong = lblSoPhong.Text;
            ThongTinPhong frm = new ThongTinPhong(maphong);
            frm.ShowDialog();
        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            string maphong = lblSoPhong.Text.ToString();
            DatPhongForm frm = new DatPhongForm(maphong);
            frm.ShowDialog();
        }

        private void btnTra_Click(object sender, EventArgs e)
        {

        }
    }
}
