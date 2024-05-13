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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rdoQuanLy.Checked = true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (verif())
            {
                string user = tbxUser.Text;
                string pass = tbxPass.Text;
                MYDB db = new MYDB();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT * FROM DangNhap " +
                    "INNER JOIN NhanVien ON DangNhap.MaNV = NhanVien.MaNV " +
                    "WHERE Username = @User and Password = @Pass", db.getConnection);
                cmd.Parameters.Add("@User", SqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("@Pass", SqlDbType.VarChar).Value = pass;
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    string userid = table.Rows[0][0].ToString();
                    Globals.SetGlobalUserID(userid);
                    if (rdoQuanLy.Checked && table.Rows[0]["MaCV"].ToString() == "CV001")
                    {
                        this.Hide();
                        MainForm frm = new MainForm();
                        frm.ShowDialog();
                    }
                    else if (rdoTiepTan.Checked && table.Rows[0]["MaCV"].ToString() == "CV002")
                    {
                        this.Hide();
                        MainForm frm = new MainForm();
                        frm.ShowDialog();
                    }
                    else if (rdoLaoCong.Checked && table.Rows[0]["MaCV"].ToString() == "CV003")
                    {
                        this.Hide();
                        MainForm frm = new MainForm();
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Tài Khoản hoặc Mật Khẩu chưa chính xác", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    this.Show();

                }
                
            }    

            
        }

        private bool verif()
        {
            bool flag = false;
            if (tbxUser.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên người dùng", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }  
            else if (tbxPass.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!rdoQuanLy.Checked && !rdoLaoCong.Checked && !rdoTiepTan.Checked)
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản đăng nhập", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else
            {
                flag = true;
            }
            return flag;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tbxPass.UseSystemPasswordChar = true;
            }
            else
                tbxPass.UseSystemPasswordChar = false;
        }

       
    }
}
