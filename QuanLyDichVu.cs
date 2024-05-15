using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class QuanLyDichVu : Form
    {
        public QuanLyDichVu()
        {
            InitializeComponent();
        }
        MYDB mydb =  new MYDB();
        private void QuanLyDichVu_Load(object sender, EventArgs e)
        {
            string query = "SELECT MaDV 'Mã dịch vụ', TenDV 'Tên dịch vụ', DonGia 'Đơn giá', SoLuong 'Số lượng' FROM DichVu";
            dgvDichVu.DataSource = createTable(query);
            dgvDichVu.AllowUserToAddRows = false;
        }

        public DataTable createTable(string query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, mydb.getConnection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        private void dgvDichVu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxMaDV.Text = dgvDichVu.CurrentRow.Cells[0].Value.ToString();
            tbxTenDV.Text = dgvDichVu.CurrentRow.Cells[1].Value.ToString();
            tbxDonGia.Text = dgvDichVu.CurrentRow.Cells[2].Value.ToString();
            tbxSoLuong.Text = dgvDichVu.CurrentRow.Cells[3].Value.ToString();
        }
        private bool verif()
        {
            

            bool flag = false;
            if (tbxMaDV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã dịch vụ", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tbxTenDV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tbxSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tbxDonGia.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đơn giá", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!Regex.IsMatch(tbxTenDV.Text, @"[\p{L}]+$"))
            {
                MessageBox.Show("Tên dịch vụ chỉ bao gồm kí tự và khoảng trắng", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!Regex.IsMatch(tbxDonGia.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Đơn giá không được bao gồm chữ", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!Regex.IsMatch(tbxSoLuong.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Số lượng không được bao gồm chữ", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                flag = true;
            }
            return flag;

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if(verif())
                {
                    SqlCommand command = new SqlCommand("INSERT INTO DichVu (MaDV, TenDV, DonGia, SoLuong) Values (@madv, @ten, @gia, @sl)", mydb.getConnection);
                    command.Parameters.Add("@madv", SqlDbType.VarChar).Value = tbxMaDV.Text;
                    command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = tbxTenDV.Text;
                    command.Parameters.Add("@gia", SqlDbType.Int).Value = Convert.ToInt32(tbxDonGia.Text);
                    command.Parameters.Add("@sl", SqlDbType.Int).Value = Convert.ToInt32(tbxSoLuong.Text);
                    mydb.openConection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Thêm dịch vụ thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mydb.closeConection();
                    }
                    else
                    {
                        MessageBox.Show("Thêm dịch vụ không thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        mydb.closeConection();
                    }
                }    
               
            }
            catch(Exception ex) 
            {
                MessageBox.Show("ERROR","Hệ thống",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maDV = dgvDichVu.CurrentRow.Cells[0].Value.ToString();
                SqlCommand command = new SqlCommand("Delete FROM DichVu Where MaDV = '" + maDV + "'", mydb.getConnection);
                mydb.openConection();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Xóa dịch vụ thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mydb.closeConection();
                }
                else
                {
                    MessageBox.Show("Xóa dịch vụ không thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mydb.closeConection();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("ERROR","Hệ thống",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("UPDATE DichVu Set TenDV = @ten, DonGia = @gia, SoLuong = @sl Where MaDV = @madv", mydb.getConnection);
                command.Parameters.Add("@madv", SqlDbType.VarChar).Value = tbxMaDV.Text;
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = tbxTenDV.Text;
                command.Parameters.Add("@gia", SqlDbType.Int).Value = Convert.ToInt32(tbxDonGia.Text);
                command.Parameters.Add("@sl", SqlDbType.Int).Value = Convert.ToInt32(tbxSoLuong.Text);
                mydb.openConection();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sửa dịch vụ thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mydb.closeConection();
                }
                else
                {
                    MessageBox.Show("Sửa dịch vụ không thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mydb.closeConection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            QuanLyDichVu_Load(sender, e);
        }
    }
}
