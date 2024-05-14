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
            SqlCommand cmd = new SqlCommand("SELECT MaPhong, Sum(ChiPhi) as ChiPhi " +
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
                dataGridView1.DataSource = dt;

                loadChart();
            }    
            else
            {
                MessageBox.Show("Không có dữ liệu thống kê", "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }

        private void thongKeTheoNgay(DateTime date)
        {
            SqlCommand cmd = new SqlCommand("SELECT MaPhong, ChiPhi " +
                "FROM HoaDon " +
                "WHERE CAST(NgayThanhToan AS DATE) = @date", mydb.getConnection);
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date.Date;

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;

                loadChart();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu thống kê", "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void loadChart()
        {
            string title = "";            
            // Thiết lập chart control
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            // Tạo Chart Area
            ChartArea chartArea = new ChartArea("ChartArea1");
            chart1.ChartAreas.Add(chartArea);

            // Tạo Series
            Series series = new Series("Doanh Thu Phòng");
            series.ChartType = SeriesChartType.Column;
            chart1.Series.Add(series);

            // Đọc dữ liệu từ DataGridView và thêm vào Chart
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["MaPhong"].Value != null && row.Cells["ChiPhi"].Value != null)
                {
                    string tenPhong = row.Cells["MaPhong"].Value.ToString();
                    decimal doanhThu;
                    if (decimal.TryParse(row.Cells["ChiPhi"].Value.ToString(), out doanhThu))
                    {
                        series.Points.AddXY(tenPhong, doanhThu);
                    }
                }
            }

            // Tùy chỉnh giao diện của Chart
            chart1.ChartAreas[0].AxisX.Title = "Số Phòng";
            chart1.ChartAreas[0].AxisY.Title = "Doanh Thu";
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
            chart1.Titles.Add(chartTitle);
        }
    }
}
