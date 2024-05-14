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
using System.Windows.Forms.DataVisualization.Charting;
using ZedGraph;

namespace QuanLyKhachSan
{
    public partial class ThongKeChiTieuForm : Form
    {
        MYDB mydb = new MYDB();
        string loai = "";
        public ThongKeChiTieuForm()
        {
            InitializeComponent();
        }

        private void ThongKeChiTieuForm_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/yyyy";
            dateTimePicker2.ShowUpDown = true;
        }

        private void rdoNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNgay.Checked)
            {
                dateTimePicker1.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
            }
        }

        private void rdoThang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoThang.Checked)
            {
                dateTimePicker2.Enabled = true;
            }
            else
            {
                dateTimePicker2.Enabled = false;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            
            DateTime date = new DateTime();
            if (rdoNgay.Checked == true)
            {
                date = dateTimePicker1.Value;
                loai = "ngay";
            }
            else if (rdoThang.Checked == true)
            {
                date = dateTimePicker2.Value;
                loai = "thang";
            }    
            else
            {
                MessageBox.Show("Vui lòng chọn loại thống kê", "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (loai == "ngay")
            {
                thongKeTheoNgay(date);
            }  
            else if(loai == "thang")
            {
                thongKeTheoThang(date);
            }    
        }

        private void thongKeTheoThang(DateTime date)
        {
            SqlCommand cmd = new SqlCommand("SELECT MaPhong as 'Mã phòng', Sum(ChiPhi) as 'Tổng' " +
                "FROM HoaDon " +
                "WHERE YEAR(NgayThanhToan) = @year AND MONTH(NgayThanhToan) = @month " +
                "GROUP BY MaPhong", mydb.getConnection);
            cmd.Parameters.Add("@year", SqlDbType.Int).Value = (int)date.Year;
            cmd.Parameters.Add("@month", SqlDbType.Int).Value = (int)date.Month;

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dataGridViewPhong.DataSource = dt;

                loadChartPhong();
            }    
            else
            {
                MessageBox.Show("Không có dữ liệu thống kê", "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }

        private void thongKeTheoNgay(DateTime date)
        {
            SqlCommand cmd = new SqlCommand("SELECT MaPhong as 'Mã phòng', ChiPhi as 'Tổng'" +
                "FROM HoaDon " +
                "WHERE CAST(NgayThanhToan AS DATE) = @date", mydb.getConnection);
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date.Date;

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dataGridViewPhong.DataSource = dt;

                loadChartPhong();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu thống kê", "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void loadChartPhong()
        {
            string title = "";            
            // Thiết lập chart control
            chartPhong.Series.Clear();
            chartPhong.ChartAreas.Clear();
            chartPhong.Titles.Clear();

            // Tạo Chart Area
            ChartArea chartArea = new ChartArea("ChartArea1");
            chartPhong.ChartAreas.Add(chartArea);

            // Tạo Series
            Series series = new Series("Doanh Thu Phòng");
            series.ChartType = SeriesChartType.Column;
            chartPhong.Series.Add(series);

            // Đọc dữ liệu từ DataGridView và thêm vào Chart
            foreach (DataGridViewRow row in dataGridViewPhong.Rows)
            {
                if (row.Cells["Mã phòng"].Value != null && row.Cells["Tổng"].Value != null)
                {
                    string tenPhong = row.Cells["Mã phòng"].Value.ToString();
                    decimal doanhThu;
                    if (decimal.TryParse(row.Cells["Tổng"].Value.ToString(), out doanhThu))
                    {
                        series.Points.AddXY(tenPhong, doanhThu);
                    }
                }
            }

            // Tùy chỉnh giao diện của Chart
            chartPhong.ChartAreas[0].AxisX.Title = "Số Phòng";
            chartPhong.ChartAreas[0].AxisY.Title = "Doanh Thu";
            if (loai == "ngay")
            {
                title = "Biểu đồ doanh thu phòng theo ngày (bao gồm dịch vụ)";
            }    
            else if (loai == "thang")
            {
                title = "Biểu đồ doanh thu phòng theo tháng (bao gồm dịch vụ)";
            }    
            Title chartTitle = new Title(title);
            chartTitle.Font = new Font("Times New Roman", 14, FontStyle.Bold); // Thay đổi kích thước và kiểu font
            chartPhong.Titles.Add(chartTitle);
        }

        private void btnXacNhanDoanhThu_Click(object sender, EventArgs e)
        {
           
            DateTime dt1 = datiTu.Value;
            DateTime dt2 = datiDen.Value;

            if (dt1.Date > dt2.Date)
            {
                MessageBox.Show("Thời gian bắt đầu phải nhỏ hơn thời gian đến", "Thống kê doanh thu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlCommand cmd = new SqlCommand("SELECT MaPhong as 'Mã phòng', Sum(ChiPhi) as 'Tổng' " +
                "FROM HoaDon " +
                "WHERE CAST(NgayThanhToan AS DATE) >= @datefrom AND CAST(NgayThanhToan AS DATE) <= @dateto " +
                "GROUP BY MaPhong", mydb.getConnection);
            cmd.Parameters.Add("@datefrom", SqlDbType.DateTime).Value = dt1.Date;
            cmd.Parameters.Add("@dateto", SqlDbType.DateTime).Value = dt2.Date;

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dataGridViewDoanhThu.DataSource = dt;

                loadChartDoanhThu();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu thống kê", "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void loadChartDoanhThu()
        {
            string title = "Thống kê doanh thu theo ngày";
            // Thiết lập chart control
            chartDoanhThu.Series.Clear();
            chartDoanhThu.ChartAreas.Clear();
            chartDoanhThu.Titles.Clear();

            // Tạo Chart Area
            ChartArea chartArea = new ChartArea("ChartArea1");
            chartDoanhThu.ChartAreas.Add(chartArea);

            // Tạo Series
            Series series = new Series("Doanh Thu");
            series.ChartType = SeriesChartType.Column;
            chartDoanhThu.Series.Add(series);

            // Đọc dữ liệu từ DataGridView và thêm vào Chart
            foreach (DataGridViewRow row in dataGridViewDoanhThu.Rows)
            {
                if (row.Cells["Mã phòng"].Value != null && row.Cells["Tổng"].Value != null)
                {
                    string tenPhong = row.Cells["Mã phòng"].Value.ToString();
                    decimal doanhThu;
                    if (decimal.TryParse(row.Cells["Tổng"].Value.ToString(), out doanhThu))
                    {
                        series.Points.AddXY(tenPhong, doanhThu);
                    }
                }
            }

            // Tùy chỉnh giao diện của Chart
            chartDoanhThu.ChartAreas[0].AxisX.Title = "Ngày";
            chartDoanhThu.ChartAreas[0].AxisY.Title = "Doanh Thu";
            
            Title chartTitle = new Title(title);
            chartTitle.Font = new Font("Times New Roman", 14, FontStyle.Bold); // Thay đổi kích thước và kiểu font
            chartDoanhThu.Titles.Add(chartTitle);
        }

        private void dataGridViewPhong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewPhong.Columns[e.ColumnIndex].Name == "Tổng" )
            {
                // Kiểm tra xem giá trị của ô hiện tại có phải là số nguyên không
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    // Định dạng lại giá trị thành "#,##0"
                    e.Value = value.ToString("#,##0");
                    e.FormattingApplied = true;
                }
            }
        }

        private void dataGridViewDoanhThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewDoanhThu.Columns[e.ColumnIndex].Name == "Tổng")
            {
                // Kiểm tra xem giá trị của ô hiện tại có phải là số nguyên không
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    // Định dạng lại giá trị thành "#,##0"
                    e.Value = value.ToString("#,##0");
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnXacNhanNhanVien_Click(object sender, EventArgs e)
        {
            DateTime dt1 = datiNgayNV.Value;
            SqlCommand cmd = new SqlCommand("SELECT MaNV as 'Mã Nhân Viên', TongGioLam as 'Tổng số giờ làm', TongGioTre as 'Tổng số giờ trễ', Luong as 'Lương' " +
                "FROM BaoCao " +
                "WHERE CAST(Ngay AS DATE) = @date", mydb.getConnection);
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = dt1.Date;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dataGridViewNhanVien.DataSource = dt;

                loadChartNhanVien();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu thống kê", "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void loadChartNhanVien()
        {
            string title = "";
            // Thiết lập chart control
            chartNhanVien.Series.Clear();
            chartNhanVien.ChartAreas.Clear();
            chartNhanVien.Titles.Clear();

            // Tạo Chart Area
            ChartArea chartArea = new ChartArea("ChartArea1");
            chartNhanVien.ChartAreas.Add(chartArea);

            // Tạo Series
            Series series = new Series("Doanh Thu Phòng");
            series.ChartType = SeriesChartType.Column;
            chartNhanVien.Series.Add(series);

            // Đọc dữ liệu từ DataGridView và thêm vào Chart
            foreach (DataGridViewRow row in dataGridViewNhanVien.Rows)
            {
                if (row.Cells["Mã nhân viên"].Value != null && row.Cells["Tổng số giờ làm"].Value != null)
                {
                    string tenPhong = row.Cells["Mã nhân viên"].Value.ToString();
                    decimal doanhThu;
                    if (decimal.TryParse(row.Cells["Tổng số giờ làm"].Value.ToString(), out doanhThu))
                    {
                        series.Points.AddXY(tenPhong, doanhThu);
                    }
                }
            }

            // Tùy chỉnh giao diện của Chart
            chartNhanVien.ChartAreas[0].AxisX.Title = "Mã Nhân Viên";
            chartNhanVien.ChartAreas[0].AxisY.Title = "Số giờ";
           
            Title chartTitle = new Title(title);
            chartTitle.Font = new Font("Times New Roman", 14, FontStyle.Bold); // Thay đổi kích thước và kiểu font
            chartNhanVien.Titles.Add(chartTitle);
        }
    }
}
