using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class QuanLyPhong : Form
    {
        public QuanLyPhong()
        {
            InitializeComponent();
        }

        private void QuanLyPhong_Load(object sender, EventArgs e)
        {
            MYDB mydb = new MYDB();
            Phong phong = new Phong(); 
            SqlCommand command = new SqlCommand("SELECT MaPhong as 'Mã Phòng', TenLoaiPhong as 'Loại Phòng', TinhTrang as 'Tình trạng' FROM Phong " +
                "INNER JOIN LoaiPhong ON Phong.MaLoaiPhong = LoaiPhong.MaLoaiPhong", mydb.getConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dataGridView1.DataSource = dt;

            command = new SqlCommand("SELECT * FROM LoaiPhong", mydb.getConnection);
            adapter = new SqlDataAdapter(command);
            DataTable dt2 = new DataTable();

            adapter.Fill(dt2);

            cbxLoaiPhong.DataSource = dt2;
            cbxLoaiPhong.ValueMember = "MaLoaiPhong";
            cbxLoaiPhong.DisplayMember = "TenLoaiPhong";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Phong phong = new Phong();
            string maphong = tbxMaPhong.Text;
            string maloaiphong = cbxLoaiPhong.SelectedValue.ToString();

            if (verif())
            {
                if (phong.ThemPhong(maphong, maloaiphong))
                {
                    MessageBox.Show("Thêm phòng thành công", "Quản lý phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                }
            }    
        }

        private bool verif()
        {
            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Phong phong = new Phong();
            string maphong = tbxMaPhong.Text;

            if (verif())
            {
                if (phong.XoaPhong(maphong))
                {
                    MessageBox.Show("Xoá phòng thành công", "Quản lý phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Phong phong = new Phong();
            string maphong = tbxMaPhong.Text;
            string maloaiphong = cbxLoaiPhong.SelectedValue.ToString();

            if (verif())
            {
                if (phong.SuaPhong(maphong, maloaiphong))
                {
                    MessageBox.Show("Sửa thông tin phòng thành công", "Quản lý phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                }
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            tbxMaPhong.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cbxLoaiPhong.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

        }
    }
}
