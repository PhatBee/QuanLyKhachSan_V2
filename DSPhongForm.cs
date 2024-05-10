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
    public partial class DSPhongForm : Form
    {
        public DSPhongForm()
        {
            InitializeComponent();
            // LoadPhong();
            LoadPhong2();
        }

        private void LoadPhong2()
        {
            MYDB mydb = new MYDB();
            SqlCommand cmd = new SqlCommand("SELECT MaPhong, TenLoaiPhong, TinhTrang FROM Phong " +
                "INNER JOIN LoaiPhong ON Phong.MaLoaiPhong = LoaiPhong.MaLoaiPhong", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                string sophong = dr[0].ToString();
                string loaiphong = dr[1].ToString();
                bool tinhtrang = true;
                if (dr[2].ToString() == "0")
                    tinhtrang = false;
                


                UserControlRoom usroom = new UserControlRoom();
                usroom.fillData(sophong, loaiphong, tinhtrang);

                flpPhong.Controls.Add(usroom);

            }
            /*List<Phong> dsPhong = PhongADO.Instance.LoadDSPhong();
            foreach (Phong item in dsPhong)
            {
                string sophong = item.Maphong;
                string loaiphong = item.Loai;

                bool tinhtrang = item.Trangthai;

                UserControlRoom usroom = new UserControlRoom();
                usroom.fillData(sophong, loaiphong, tinhtrang);

                flpPhong.Controls.Add(usroom);
            }*/
        }

        private void DSPhongForm_Load(object sender, EventArgs e)
        {

        }

        void LoadPhong()
        {
            List<Phong> dsPhong = PhongADO.Instance.LoadDSPhong();
            foreach (Phong item in dsPhong)
            {
                FlowLayoutPanel flp = new FlowLayoutPanel() { Width = 180, Height = 150 };
                flp.FlowDirection = FlowDirection.LeftToRight;
                Label label = new Label() { Width = 200, Height = 80 };
                string trangthai = "";
                if (item.Trangthai == true)
                {
                    trangthai = "Trống";
                }
                else
                {
                    trangthai = "Đang sử dụng";
                }    
                label.Text = "Phòng: " + item.Maphong + "\n" + "Loại: " + item.Loai + "\n" + "Trạng thái: " + trangthai;
                flp.Controls.Add(label);

                switch (item.Trangthai)
                {
                    case true:
                        flp.BackColor = Color.Aqua;
                        break;
                    case false:
                        flp.BackColor = Color.LightPink;
                        break;
                }    

                if (item.Trangthai == false)
                {
                    // Add buttons for booking and check-in
                    Button btnDatPhong = new Button() { Text = "Đặt", Width = 60, Height = 30 };
                    btnDatPhong.BackColor = Color.White;
                    Button btnNhanPhong = new Button() { Text = "Nhận", Width = 60, Height = 30 };
                    btnNhanPhong.BackColor = Color.White;


                    flp.Controls.Add(btnDatPhong);
                    flp.Controls.Add(btnNhanPhong);

                }
                else
                {
                    Button btnDatPhong = new Button() { Text = "Đặt", Width = 60, Height = 30 };
                    btnDatPhong.BackColor = Color.White;
                    Button btnTraPhong = new Button() { Text = "Trả", Width = 60, Height = 30 };
                    btnTraPhong.BackColor = Color.White;


                    flp.Controls.Add(btnDatPhong);
                    flp.Controls.Add(btnTraPhong);

                }


                flpPhong.Controls.Add(flp);
            }

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnQuanLyPhong_Click(object sender, EventArgs e)
        {
            QuanLyPhong frm = new QuanLyPhong();
            frm.ShowDialog();
        }
    }
}
