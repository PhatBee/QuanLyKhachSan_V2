using Newtonsoft.Json;
using RestSharp;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace QuanLyKhachSan
{
    public partial class ThanhToanForm : Form
    {
        string _sophong;
        int _thanhtoan;
        DataTable _tbDichVu = new DataTable();
        DataTable dt = new DataTable();
        MYDB mydb = new MYDB();
        public ThanhToanForm(string sophong)
        {
            InitializeComponent();
            _sophong = sophong;
           
        }

        public Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        private void ThanhToanForm_Load(object sender, EventArgs e)
        {
            loadThongTin();
            loadDichVuThanhToan();

            // Định dạng datagrid
            dataGridView1.Columns[0].Visible = false;

            using (WebClient client = new WebClient())
            {
                var htmlData = client.DownloadData("https://raw.githubusercontent.com/PhatBee/QR/main/API.json");
                var bankRawJson = Encoding.UTF8.GetString(htmlData);
                var listBankData = JsonConvert.DeserializeObject<Bank>(bankRawJson);

                cbxNganHang.DataSource = listBankData.data;   // list banks
                cbxNganHang.DisplayMember = "shortName";
                cbxNganHang.ValueMember = "bin";
                cbxNganHang.SelectedValue = listBankData.data.FirstOrDefault().bin;
                cbxLoaiQR.SelectedIndex = 0;
            }
        }

        private void loadDichVuThanhToan()
        {
            MYDB mydb = new MYDB();
            SqlCommand cmd3 = new SqlCommand("SELECT MaPhong, TenDV 'Tên Dịch Vụ', DonGia 'Đơn Giá', Count(TenDV) 'Số Lượng', Sum(DonGia) 'Tổng' " +
                "FROM DichVuPhong INNER JOIN DichVu ON DichVu.MaDV = DichVuPhong.MaDV " +
                "Where MaPhong = @maphong and MaHD = @mahd " +
                "GROUP BY TenDV, DonGia, MaPhong", mydb.getConnection);
            cmd3.Parameters.Add("@maphong", SqlDbType.VarChar).Value = tbxSoPhong.Text;
            cmd3.Parameters.Add("@mahd", SqlDbType.VarChar).Value = dt.Rows[0]["MaHD"].ToString();
            DataTable dt3 = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd3);
            adapter.Fill(dt3);
            dataGridView1.DataSource = dt3;
            dataGridView1.AllowUserToAddRows = false;

            TimeSpan kc = datiRa.Value - datiVao.Value;
            int songay = (int)kc.TotalDays;

            int tongTienDichVu = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Kiểm tra nếu hàng không phải là hàng mới thêm và không phải là hàng header
                if (!row.IsNewRow)
                {
                    tongTienDichVu += Convert.ToInt32(row.Cells[4].Value.ToString());          // Chỉnh lại thứ tự của cột nếu đã ẩn đi MaPhong                                                          
                }
            }

            int tienphong = (songay * Convert.ToInt32(tbxGiaPhong.Text));
            lblTongTienPhong.Text = tienphong.ToString("#,##0");

            int thanhtien = tongTienDichVu + tienphong;
            _thanhtoan = thanhtien;

            

        }

        private void loadThongTin()
        {
            try
            {
                tbxSoPhong.Text = _sophong;

                MYDB mydb = new MYDB();

                SqlCommand cmd = new SqlCommand("SELECT MaHD, HoaDon.MaPhong, TenLoaiPhong, DonGia, TenKH, CCCD, SDT, NgayDat, NgayTra, TinhTrang FROM HOADON " +
                    "INNER JOIN Phong ON HoaDon.MaPhong = Phong.MaPhong " +
                    "INNER JOIN LoaiPhong ON Phong.MaLoaiPhong = LoaiPhong.MaLoaiPhong " +
                    "WHERE TinhTrang = 1 and HoaDon.MaPhong = @mp", mydb.getConnection);
                cmd.Parameters.Add("@mp", SqlDbType.VarChar).Value = tbxSoPhong.Text;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    tbxHoaDon.Text = dt.Rows[0]["MaHD"].ToString();
                    tbxGiaPhong.Text = dt.Rows[0]["DonGia"].ToString();
                    datiVao.Value = (DateTime)dt.Rows[0]["NgayDat"];
                    datiRa.Value = (DateTime)dt.Rows[0]["NgayTra"];
                    tbxLoaiPhong.Text = dt.Rows[0]["TenLoaiPhong"].ToString();
                    tbxTenKH.Text = dt.Rows[0]["TenKH"].ToString();
                    tbxCCCD.Text = dt.Rows[0]["CCCD"].ToString();
                    tbxSDT.Text = dt.Rows[0]["SDT"].ToString();

                }
                else
                {
                    MessageBox.Show("Lỗi, không lấy được thông tin dữ liệu", "Trả phòng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Hệ thống",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnTaoQR_Click(object sender, EventArgs e)
        {
            var apiRequest = new ApiRequest();

            if (cbxNganHang.SelectedValue.ToString() == "970415")
            {
                apiRequest.acqId = Convert.ToInt32(cbxNganHang.SelectedValue.ToString());
                apiRequest.accountNo = long.Parse("108875270343");
                apiRequest.accountName = "NGUYEN HOAI TAN";
                apiRequest.amount = Convert.ToInt32(_thanhtoan.ToString());
                apiRequest.format = "text";
                apiRequest.template = cbxLoaiQR.Text;
            }
            else if (cbxNganHang.SelectedValue.ToString() == "970436")
            {
                apiRequest.acqId = Convert.ToInt32(cbxNganHang.SelectedValue.ToString());
                apiRequest.accountNo = long.Parse("1015708276");
                apiRequest.accountName = "ONG VINH PHAT";
                apiRequest.amount = Convert.ToInt32(_thanhtoan.ToString());
                apiRequest.format = "text";
                apiRequest.template = cbxLoaiQR.Text;
            }
            
            var jsonRequest = JsonConvert.SerializeObject(apiRequest);
            // use restsharp for request api.
            var client = new RestClient("https://api.vietqr.io/v2/generate");
            var request = new RestRequest();

            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");

            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;
            var dataResult = JsonConvert.DeserializeObject<ApiResponse>(content);


            var image = Base64ToImage(dataResult.data.qrDataURL.Replace("data:image/png;base64,", ""));
            pictureBox1.Image = image;

            lblTenTaiKhoan.Text = apiRequest.accountName;
            lblSoTaiKhoan.Text = apiRequest.accountNo.ToString();
            lblNganHang.Text = cbxNganHang.Text;

            lblSoTien.Text = Convert.ToInt32(_thanhtoan).ToString("#,##0");
            lblNoiDung.Text = "Thanh toán tiền phòng: " + _sophong;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Đơn Giá" || dataGridView1.Columns[e.ColumnIndex].Name == "Tổng")
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("UPDATE Phong SET TinhTrang = 0 WHERE MaPhong = '" + _sophong + "'", mydb.getConnection);
                SqlCommand command1 = new SqlCommand("UPDATE HOADON SET ChiPhi = '"+_thanhtoan+"'  WHERE MaHD = '" + tbxHoaDon.Text + "'",mydb.getConnection);
                mydb.openConection();
                if (command.ExecuteNonQuery() == 1 && command1.ExecuteNonQuery()==1)
                {
                    MessageBox.Show("Xác nhận trả phòng thành công","Hệ thống", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ERROR","Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Hệ thống",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT HoaDon.MaHD, TenKH, CCCD, SDT, GhiChu, NgayDat, NgayTra, ChiPhi, HoaDon.MaPhong, Phong.MaLoaiPhong, TenLoaiPhong, LoaiPhong.DonGia as DonGiaPhong, DichVuPhong.MaDV, TenDV, DichVu.DonGia as DonGiaDichVu, Count(TenDV) as SoLuong, Sum(DichVu.DonGia) as TongTien " +
                "FROM HoaDon " +
                "INNER JOIN Phong ON HoaDon.MaPhong = Phong.MaPhong " +
                "INNER JOIN LoaiPhong ON Phong.MaLoaiPhong = LoaiPhong.MaLoaiPhong " +
                "INNER JOIN DichVuPhong ON HoaDon.MaHD = DichVuPhong.MaHD AND HoaDon.MaPhong = DichVuPhong.MaPhong " +
                "INNER JOIN DichVu ON DichVuPhong.MaDV = DichVu.MaDV " +
                "WHERE HoaDon.MaHD = @mahd " +
                "GROUP BY HoaDon.MaHD, TenKH, CCCD, SDT, GhiChu, NgayDat, NgayTra, ChiPhi, HoaDon.MaPhong, Phong.MaLoaiPhong, TenLoaiPhong, LoaiPhong.DonGia, DichVuPhong.MaDV, TenDV, DichVu.DonGia", mydb.getConnection);
            cmd.Parameters.Add("@mahd", SqlDbType.VarChar).Value = tbxHoaDon.Text;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable result = new DataTable();
            adpt.Fill(result);

            PreviewPrintBaoCao rpt = new PreviewPrintBaoCao();
            rpt.ShowReport(result);
            rpt.ShowDialog();
        }
    }
}
