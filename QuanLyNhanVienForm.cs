using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace QuanLyKhachSan
{
    public partial class QuanLyNhanVienForm : Form
    {
        EMPLOYEE employee = new EMPLOYEE();
        MYDB mydb = new MYDB();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        SqlCommand command = new SqlCommand();
        public QuanLyNhanVienForm()
        {
            InitializeComponent();
        }

        private void QuanLyNhanVienForm_Load(object sender, EventArgs e)
        {
            MYDB mydb = new MYDB();

            SqlCommand command = new SqlCommand("SELECT MaNV 'Mã NV', TenNV 'Tên', NgaySinh 'Ngày Sinh', Phai 'Phái', CCCD, SoDT 'Số ĐT', DiaChi 'DiaChi', HinhAnh 'Hình Ảnh', TenCV 'Chức Vụ' FROM NhanVien " +
                "INNER JOIN ChucVu ON NhanVien.MaCV = ChucVu.MaCV");
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;


            DataGridViewImageColumn picCol = new DataGridViewImageColumn(); 
            dataGridView1.RowTemplate.Height = 80; 

            dataGridView1.DataSource = employee.getStudents(command);
            // MessageBox.Show(dataGridView1.Rows.Count.ToString());
            
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            
                

            DataGridViewCellStyle dateStyle = new DataGridViewCellStyle();
            dateStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns[2].DefaultCellStyle = dateStyle;

            SqlCommand cmd = new SqlCommand("SELECT * FROM ChucVu", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            cbxChucVu.DataSource = table;
            cbxChucVu.ValueMember = "MaCV";
            cbxChucVu.DisplayMember = "TenCV";

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            tbxMaNV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbxHoTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[2].Value;

  
            if ((dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim() == "Nam"))
            {
                radiobtnNam.Checked = true;
            }
            if ((dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim() == "Nữ"))
            {
                radiobtnNu.Checked = true;
            }
            if ((dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim() == "Khác"))
            {
                radiobtnNu.Checked = true;
            }

            tbxCCCD.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tbxSdt.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            tbxDiaChi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            string tenCV = dataGridView1.CurrentRow.Cells[8].Value.ToString();

            cbxChucVu.Text = tenCV.ToString();


            // Code xử lý hình ảnh up lên
            byte[] pic;
            pic = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
            MemoryStream picture = new MemoryStream(pic);
            PictureBoxEmployeeImage.Image = Image.FromStream(picture);

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnChinhSua.Enabled = false;
            btnXacNhan.Visible = true;
            btnHuy.Visible = true;
            btnThem.Enabled = false;
            lbUser.Visible = true;
            lbPass.Visible = true;
            tbxUser.Visible = true;
            tbxMatKhau.Visible = true;
            reset();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            

            try
            {
                if (verif())
                {
                    string manv = tbxMaNV.Text;
                    string hoten = tbxHoTen.Text;
                    string chucvu = cbxChucVu.SelectedValue.ToString();
                    DateTime ngaysinh = dateTimePicker1.Value;
                    string cccd = tbxCCCD.Text;
                    string sdt = tbxSdt.Text;
                    string diachi = tbxDiaChi.Text;
                    string gioitinh = "Nam";

                    if (radiobtnNu.Checked)
                    {
                        gioitinh = "Nữ";
                    }

                    if (radiobtnKhac.Checked)
                    {
                        gioitinh = "Khác";
                    }

                    MemoryStream hinhanh = new MemoryStream();

                    PictureBoxEmployeeImage.Image.Save(hinhanh, PictureBoxEmployeeImage.Image.RawFormat);
                    if (employee.updateEmployee(manv, hoten, ngaysinh, chucvu, gioitinh, cccd, sdt, diachi, hinhanh))
                    {
                        MessageBox.Show("Thông tin nhân viên được cập nhật", "Chỉnh sửa nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi", "Chỉnh sửa nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chỉnh sửa nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif|*.jpg;*.png;*.gif)";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                PictureBoxEmployeeImage.Image = Image.FromFile(opf.FileName);
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (verif())
                {
                    string manv = tbxMaNV.Text;
                    string hoten = tbxHoTen.Text;
                    string chucvu = cbxChucVu.SelectedValue.ToString();
                    DateTime ngaysinh = dateTimePicker1.Value;
                    string cccd = tbxCCCD.Text;
                    string sdt = tbxSdt.Text;
                    string diachi = tbxDiaChi.Text;
                    string gioitinh = "Nam";

                    string user = tbxUser.Text;
                    string pass = tbxMatKhau.Text;

                    if (radiobtnNu.Checked)
                    {
                        gioitinh = "Nữ";
                    }

                    if (radiobtnKhac.Checked)
                    {
                        gioitinh = "Khác";
                    }

                    MemoryStream hinhanh = new MemoryStream();

                    PictureBoxEmployeeImage.Image.Save(hinhanh, PictureBoxEmployeeImage.Image.RawFormat);
                    if (veraccount() && !maexist(manv) && !userexist(user))
                    {
                        FaceID faceID = new FaceID(manv);
                        faceID.ShowDialog();
                        if (employee.insertEmployee(manv, hoten, ngaysinh, chucvu, gioitinh, cccd, sdt, diachi, hinhanh) && employee.insertAccount(manv, user, pass))
                        {
                            MessageBox.Show("Đã thêm nhân viên thành công", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reset();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }    
                }
                    
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool veraccount()
        {
            bool flag = false;
            if (tbxUser.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập mới", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }   
            else if (tbxMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                flag = true;
            }
            return flag;

        }

        private bool userexist(string user)
        {
            MYDB mydb = new MYDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM DangNhap WHERE Username = @user", mydb.getConnection);
            cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại", "Thêm Nhân Viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool maexist(string manv)
        {
            MYDB mydb = new MYDB();
            SqlCommand cmd = new SqlCommand("SELECT * FROM NhanVien WHERE MaNV = @manv", mydb.getConnection);
            cmd.Parameters.Add("@manv", SqlDbType.VarChar).Value = manv;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0 )
            {
                MessageBox.Show("Mã nhân viên đã tồn tại", "Thêm Nhân Viên", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool verif()
        {
            int born_year = dateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;

            bool flag = false;
            if (tbxMaNV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            else if (tbxHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Họ và Tên", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbxChucVu.Text == "")
            {
                MessageBox.Show("Vui lòng chọn Chức Vụ", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!radiobtnNam.Checked && !radiobtnNu.Checked && !radiobtnKhac.Checked)
            {
                MessageBox.Show("Vui lòng chọn Giới Tính", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tbxCCCD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số Căn Cước Công Dân", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tbxSdt.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tbxDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Địa Chỉ", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            else if (PictureBoxEmployeeImage.Image == null)
            {
                MessageBox.Show("Vui lòng thêm Hình Ảnh", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!Regex.IsMatch(tbxHoTen.Text, @"[\p{L}]+$"))
            {
                MessageBox.Show("Họ Tên chỉ bao gồm kí tự và khoảng trắng", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
            else if ((this_year - born_year) < 18 || (this_year - born_year) > 100)
            {
                MessageBox.Show("Độ tuổi nhân viên đăng ký là từ 18 - 100 tuổi", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!Regex.IsMatch(tbxCCCD.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Căn Cước Công Dân chỉ bao gồm số", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!Regex.IsMatch(tbxSdt.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Số Điện Thoại chỉ bao gồm số", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                flag = true;
            }
            return flag;

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnXacNhan.Visible = false;
            btnChinhSua.Enabled = true;
            btnHuy.Visible = false;
            btnThem.Enabled = true;
            lbUser.Visible = false;
            lbPass.Visible = false;
            tbxUser.Visible = false;
            tbxMatKhau.Visible = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT MaNV 'Mã NV', TenNV 'Tên', NgaySinh 'Ngày Sinh', Phai 'Phái', CCCD, SoDT 'Số ĐT', DiaChi 'DiaChi', HinhAnh 'Hình Ảnh', TenCV 'Chức Vụ' FROM NhanVien " +
                "INNER JOIN ChucVu ON NhanVien.MaCV = ChucVu.MaCV");
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;

            dataGridView1.DataSource = employee.getStudents(command);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;

            DataGridViewCellStyle dateStyle = new DataGridViewCellStyle();
            dateStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns[2].DefaultCellStyle = dateStyle;

            MessageBox.Show("Làm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        private void reset()
        {
            tbxMaNV.Text = "";
            tbxHoTen.Text = "";
            cbxChucVu.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            tbxCCCD.Text = "";
            tbxSdt.Text = "";
            tbxDiaChi.Text = "";
            radiobtnKhac.Checked = false;
            radiobtnNam.Checked = false;
            radiobtnNu.Checked = false;
            tbxUser.Text = "";
            tbxMatKhau.Text = "";
            PictureBoxEmployeeImage.Image = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = tbxMaNV.Text;
                // display a confirmation message before delete
                if (MessageBox.Show("Are you Sure you want to delete This Employee", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (employee.deleteEmployee(ID))
                    {
                        MessageBox.Show("Employee Deleted", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Clear fields after delete
                        tbxMaNV.Text = "";
                        tbxHoTen.Text = "";
                        tbxCCCD.Text = "";
                        cbxChucVu.Text = "";
                        tbxDiaChi.Text = "";
                        tbxSdt.Text = "";
                        dateTimePicker1.Value = DateTime.Now;
                        radiobtnKhac.Checked = false;
                        radiobtnNam.Checked = false ;
                        radiobtnNu.Checked = false;
                        PictureBoxEmployeeImage.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("Student Not Deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Enter A Valid ID", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }
    }
}
