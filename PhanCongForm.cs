using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;

namespace QuanLyKhachSan
{
    public partial class PhanCongForm : Form
    {
        public PhanCongForm()
        {
            InitializeComponent();
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {

            MYDB mydb = new MYDB();
            DateTime date = dtpBatDau.Value;

            /*if (thoiGianHopLe(date))
            {*/
                SqlDataAdapter adapter = new SqlDataAdapter("Select MaNV from NhanVien", mydb.getConnection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                int soNhanVien = table.Rows.Count;
                Dictionary<string, int> CaNhanVienMotNgay = new Dictionary<string, int>();

                // Dictionary<int, Dictionary<string, int>> caLamViec = new Dictionary<int, Dictionary<string, int>>();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Ca", mydb.getConnection);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);

                int[,] A = new int[soNhanVien, soNhanVien];
                A[0, 0] = 1;
                A[1, 0] = 1;
                A[2, 0] = 1;
                A[3, 0] = 1;
                A[4, 0] = 5;
                A[5, 0] = 6;
                A[6, 0] = 7;
                A[7, 0] = 2;

                for (int cot = 1; cot < soNhanVien; cot++)
                {
                    for (int hang = 0; hang < soNhanVien; hang++)
                    {
                        if (hang == 0)
                            A[hang, cot] = A[soNhanVien - 1, cot - 1];
                        else
                            A[hang, cot] = A[hang - 1, cot - 1];
                    }
                }
                DataTable dataTable = new DataTable();

                DataColumn colNgay = new DataColumn("Ngày", typeof(DateTime));
                colNgay.DateTimeMode = DataSetDateTime.UnspecifiedLocal;
                dataTable.Columns.Add(colNgay);

                dataTable.Columns.Add("Nhân viên");
                dataTable.Columns.Add("Ca");
                for (int i = 0; i < soNhanVien; i++)
                {

                    for (int j = 0; j < soNhanVien; j++)
                    {

                        string maNV = table.Rows[j][0].ToString();
                        CaNhanVienMotNgay[maNV] = A[j, i];
                    }
                    foreach (var clv in CaNhanVienMotNgay)
                    {
                        string tg = "";
                        switch (clv.Value)
                        {
                            case 1:
                                tg = dt.Rows[0]["ChiTiet"].ToString();
                                break;
                            case 2:
                                tg = dt.Rows[1]["ChiTiet"].ToString();
                                break;
                            case 5:
                                tg = dt.Rows[1]["ChiTiet"].ToString() + "và " + dt.Rows[2]["ChiTiet"].ToString();
                                break;
                            case 6:
                                tg = dt.Rows[1]["ChiTiet"].ToString() + "và " + dt.Rows[3]["ChiTiet"].ToString();
                                break;
                            case 7:
                                tg = dt.Rows[1]["ChiTiet"].ToString() + "và " + dt.Rows[4]["ChiTiet"].ToString();
                                break;


                        }
                        dataTable.Rows.Add(date.AddDays(i), clv.Key, tg);
                    }
                }

                MessageBox.Show(dataTable.Rows.Count.ToString());
                dataGridView1.DataSource = dataTable;
                dataGridView1.AllowUserToAddRows = false;

                dataGridView1.Columns["Ngày"].DefaultCellStyle.Format = "dd/MM/yyyy";

                /*int k = 0;
                int n = 10;
                Dictionary<string, int> CaNhanVienMotNgay = new Dictionary<string, int>();
                DateTime date = DateTime.Now;
                Dictionary<DateTime, Dictionary<string, int>> caLamViec = new Dictionary<DateTime, Dictionary<string,  int >>();
                int[] A = new int[1000];
                A[0] = 1;
                A[1] = 1;
                A[2] = 1;
                A[3] = 1;
                A[4] = 5;
                A[5] = 6;
                A[6] = 7;
                A[7] = 2;

                for(int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        string maNV = ((j + i) % n).ToString();
                        CaNhanVienMotNgay[maNV] = A[k];
                        k = (k + 1) % n;
                    }

                    caLamViec.Add(date.AddDays(i), CaNhanVienMotNgay);
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("Ngày");
                dt.Columns.Add("Nhân viên");
                dt.Columns.Add("Ca");

                foreach (var cgv in caLamViec)
                {
                    DateTime ngay = cgv.Key;
                    Dictionary<string, int> caNhanVien = cgv.Value;

                    foreach (var kvp in caNhanVien)
                    {
                        string maNV = kvp.Key;
                        int ca = kvp.Value;

                        dt.Rows.Add(ngay.ToString(), maNV, ca);
                    }
                }

                dataGridView1.DataSource = dt;*/
            //}
        }

        private bool thoiGianHopLe(DateTime ngay)
        {
            if (ngay.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Thời gian phân công nhỏ hơn thời gian hiện tại", "Phân công", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            MYDB mydb = new MYDB();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT Ngay FROM PhanCong", mydb.getConnection);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            int n = dt.Rows.Count;
            if (n > 0)
            {
                DateTime datetime = Convert.ToDateTime(dt.Rows[n - 1][0]);
                ngay = new DateTime(ngay.Year, ngay.Month, ngay.Day);
                if (datetime >= ngay)
                {
                    MessageBox.Show("Thời gian phân công không hợp lệ, hãy phân công bắt đầu từ ngày: " + datetime.AddDays(1).ToString(), "Phân công", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (datetime.AddDays(3) < ngay)
                {
                    MessageBox.Show("Thời gian phân công quá xa, hãy phân công cách ngày cuối cùng không quá 3 ngày, ngày phân công đầu tiên tiếp theo là: " + datetime.AddDays(1).ToString(), "Phân công", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private void PhanCongForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            PHANCONG pc = new PHANCONG();
            MYDB mydb = new MYDB();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Ca", mydb.getConnection);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            try
            {
                // Ngay     NhanVien        Ca
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    if (!row.IsNewRow) // Đảm bảo không phải hàng mới
                    {
                        object ngayvalue = row.Cells["Ngày"].Value;

                        DateTime.TryParse(ngayvalue.ToString(), out DateTime ngay);

                        string manv = row.Cells[1].Value.ToString();
                        string phanca = row.Cells[2].Value.ToString();

                        if (phanca == dt.Rows[0]["ChiTiet"].ToString())
                        {
                            string maca = dt.Rows[0]["MaCa"].ToString();
                            if (pc.themPhanCong(manv, ngay, maca))
                            {

                            }
                        }
                        else if (phanca == dt.Rows[1]["ChiTiet"].ToString())
                        {
                            string maca = dt.Rows[1]["MaCa"].ToString();
                            if (pc.themPhanCong(manv, ngay, maca))
                            {

                            }
                        }
                        else if (phanca == (dt.Rows[1]["ChiTiet"].ToString() + "và " + dt.Rows[2]["ChiTiet"].ToString()))
                        {
                            string maca = dt.Rows[1]["MaCa"].ToString(); ;
                            if (pc.themPhanCong(manv, ngay, maca))
                            {

                            }
                            maca = dt.Rows[2]["MaCa"].ToString(); ;
                            if (pc.themPhanCong(manv, ngay, maca))
                            {

                            }
                        }
                        else if (phanca == (dt.Rows[1]["ChiTiet"].ToString() + "và " + dt.Rows[3]["ChiTiet"].ToString()))
                        {
                            string maca = dt.Rows[1]["MaCa"].ToString();
                            if (pc.themPhanCong(manv, ngay, maca))
                            {

                            }
                            maca = dt.Rows[3]["MaCa"].ToString();
                            if (pc.themPhanCong(manv, ngay, maca))
                            {

                            }
                        }
                        else if (phanca == dt.Rows[1]["ChiTiet"].ToString() + "và " + dt.Rows[4]["ChiTiet"].ToString())
                        {
                            string maca = dt.Rows[1]["MaCa"].ToString();
                            if (pc.themPhanCong(manv, ngay, maca))
                            {

                            }
                            maca = dt.Rows[4]["MaCa"].ToString();
                            if (pc.themPhanCong(manv, ngay, maca))
                            {

                            }
                        }
                        else if (phanca == "")
                        {

                        }
                    }
                }
                MessageBox.Show("Phân ca thành công", "Phân công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi phân ca, vui lòng xem lại \n\nThông tin lỗi: " + ex.Message, "Phân công", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLuu2_Click(object sender, EventArgs e)
        {
            PHANCONG pc = new PHANCONG();
            MYDB mydb = new MYDB();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Ca", mydb.getConnection);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            DataTable phancong = new DataTable();
            phancong.Columns.Add("MaNV");
            DataColumn colNgay = new DataColumn("Ngày", typeof(DateTime));
            colNgay.DateTimeMode = DataSetDateTime.UnspecifiedLocal;
            phancong.Columns.Add(colNgay);
            phancong.Columns.Add("Ca");

            bool flag = true;

            //try
            //{
            // Ngay     NhanVien        Ca
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (!row.IsNewRow) // Đảm bảo không phải hàng mới
                {
                    object ngayvalue = row.Cells["Ngày"].Value;

                    DateTime.TryParse(ngayvalue.ToString(), out DateTime ngay);

                    string manv = row.Cells[1].Value.ToString();
                    string phanca = row.Cells[2].Value.ToString();

                    if (phanca == dt.Rows[0]["ChiTiet"].ToString())
                    {
                        string maca = dt.Rows[0]["MaCa"].ToString();
                        if (!pc.exist(manv, ngay, maca))
                        {
                            phancong.Rows.Add(manv, ngay, maca);
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                    else if (phanca == dt.Rows[1]["ChiTiet"].ToString())
                    {
                        string maca = dt.Rows[1]["MaCa"].ToString();
                        if (!pc.exist(manv, ngay, maca))
                        {
                            phancong.Rows.Add(manv, ngay, maca);
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                    else if (phanca == (dt.Rows[1]["ChiTiet"].ToString() + "và " + dt.Rows[2]["ChiTiet"].ToString()))
                    {
                        string maca = dt.Rows[1]["MaCa"].ToString(); ;
                        if (!pc.exist(manv, ngay, maca))
                        {
                            phancong.Rows.Add(manv, ngay, maca);
                        }
                        maca = dt.Rows[2]["MaCa"].ToString(); ;
                        if (!pc.exist(manv, ngay, maca))
                        {
                            phancong.Rows.Add(manv, ngay, maca);
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                    else if (phanca == (dt.Rows[1]["ChiTiet"].ToString() + "và " + dt.Rows[3]["ChiTiet"].ToString()))
                    {
                        string maca = dt.Rows[1]["MaCa"].ToString();
                        if (!pc.exist(manv, ngay, maca))
                        {
                            phancong.Rows.Add(manv, ngay, maca);
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                        maca = dt.Rows[3]["MaCa"].ToString();
                        if (!pc.exist(manv, ngay, maca))
                        {
                            phancong.Rows.Add(manv, ngay, maca);
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                    else if (phanca == dt.Rows[1]["ChiTiet"].ToString() + "và " + dt.Rows[4]["ChiTiet"].ToString())
                    {
                        string maca = dt.Rows[1]["MaCa"].ToString();
                        if (!pc.exist(manv, ngay, maca))
                        {
                            phancong.Rows.Add(manv, ngay, maca);
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                        maca = dt.Rows[4]["MaCa"].ToString();
                        if (!pc.exist(manv, ngay, maca))
                        {
                            phancong.Rows.Add(manv, ngay, maca);
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                    else if (phanca == "")
                    {

                    }

                }
            }
            if (flag)
            {
                dataGridView2.DataSource = phancong;
                dataGridView2.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
                foreach (DataRow phc in phancong.Rows)
                {

                    string manv = phc[0].ToString();
                    string maca = phc[2].ToString();
                    DateTime ngay = Convert.ToDateTime(phc[1].ToString());
                    pc.themPhanCong(manv, ngay, maca);
                }
                MessageBox.Show("Phân ca thành công", "Phân công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Lỗi phân ca do phân công đã được tạo, vui lòng xem lại", "Phân công", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //}
            /*catch (Exception ex)
            {
                MessageBox.Show("Lỗi phân ca, vui lòng xem lại \n\nThông tin lỗi: " + ex.Message, "Phân công", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXemDanhSach_Click(object sender, EventArgs e)
        {

        }

        private void buttonPhanCong_Click(object sender, EventArgs e)
        {
            MYDB mydb = new MYDB();
            DateTime date = dtpBatDau.Value;


            SqlDataAdapter adapter = new SqlDataAdapter("Select MaNV from NhanVien", mydb.getConnection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            int soNhanVien = table.Rows.Count;
            Dictionary<string, int> CaNhanVienMotNgay = new Dictionary<string, int>();

            // Dictionary<int, Dictionary<string, int>> caLamViec = new Dictionary<int, Dictionary<string, int>>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Ca", mydb.getConnection);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            int[,] A = new int[soNhanVien, soNhanVien];
            A[0, 0] = 3;
            A[1, 0] = 7;
            A[2, 0] = 7;
            A[3, 0] = 7;
            A[4, 0] = 7;
            A[5, 0] = 11;


            for (int cot = 1; cot < soNhanVien; cot++)
            {
                for (int hang = 0; hang < soNhanVien; hang++)
                {
                    if (hang == 0)
                        A[hang, cot] = A[soNhanVien - 1, cot - 1];
                    else
                        A[hang, cot] = A[hang - 1, cot - 1];
                }
            }
            DataTable dataTable = new DataTable();

            DataColumn colNgay = new DataColumn("Ngày", typeof(DateTime));
            colNgay.DateTimeMode = DataSetDateTime.UnspecifiedLocal;
            dataTable.Columns.Add(colNgay);

            dataTable.Columns.Add("Nhân viên");
            dataTable.Columns.Add("Ca");
            for (int i = 0; i < soNhanVien; i++)
            {

                for (int j = 0; j < soNhanVien; j++)
                {

                    string maNV = table.Rows[j][0].ToString();
                    CaNhanVienMotNgay[maNV] = A[j, i];
                }
                foreach (var clv in CaNhanVienMotNgay)
                {
                    string tg = "";
                    switch (clv.Value)
                    {
                        case 3:
                            tg = dt.Rows[0]["ChiTiet"].ToString() + " và " + dt.Rows[1]["ChiTiet"].ToString(); 
                            break;
                        case 7:
                            tg = dt.Rows[2]["ChiTiet"].ToString() + " và " + dt.Rows[3]["ChiTiet"].ToString();
                            break;
                        case 11:
                            tg = dt.Rows[4]["ChiTiet"].ToString() + " và " + dt.Rows[5]["ChiTiet"].ToString();
                            break;
                       /* case 6:
                            tg = dt.Rows[1]["ChiTiet"].ToString() + "và " + dt.Rows[3]["ChiTiet"].ToString();
                            break;
                        case 7:
                            tg = dt.Rows[1]["ChiTiet"].ToString() + "và " + dt.Rows[4]["ChiTiet"].ToString();
                            break;*/


                    }
                    dataTable.Rows.Add(date.AddDays(i), clv.Key, tg);
                }
            }

            MessageBox.Show(dataTable.Rows.Count.ToString());
            dataGridView1.DataSource = dataTable;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns["Ngày"].DefaultCellStyle.Format = "dd/MM/yyyy";

        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            PHANCONG pc = new PHANCONG();
            MYDB mydb = new MYDB();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Ca", mydb.getConnection);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            try
            {
                // Ngay     NhanVien        Ca
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    if (!row.IsNewRow) // Đảm bảo không phải hàng mới
                    {
                        object ngayvalue = row.Cells["Ngày"].Value;

                        DateTime.TryParse(ngayvalue.ToString(), out DateTime ngay);

                        string manv = row.Cells[1].Value.ToString();
                        string phanca = row.Cells[2].Value.ToString();

                        if (phanca == (dt.Rows[0]["ChiTiet"].ToString() + " và " + dt.Rows[1]["ChiTiet"].ToString()))
                        {
                            string maca = dt.Rows[0]["MaCa"].ToString(); ;
                            if (pc.themPhanCong(manv, ngay, maca))
                            {

                            }
                            maca = dt.Rows[1]["MaCa"].ToString(); ;
                            if (pc.themPhanCong(manv, ngay, maca))
                            {

                            }
                        }
                        else if (phanca == (dt.Rows[2]["ChiTiet"].ToString() + " và " + dt.Rows[3]["ChiTiet"].ToString()))
                        {
                            string maca = dt.Rows[2]["MaCa"].ToString();
                            if (pc.themPhanCong(manv, ngay, maca))
                            {

                            }
                            maca = dt.Rows[3]["MaCa"].ToString();
                            if (pc.themPhanCong(manv, ngay, maca))
                            {

                            }
                        }
                        else if (phanca == dt.Rows[4]["ChiTiet"].ToString() + " và " + dt.Rows[5]["ChiTiet"].ToString())
                        {
                            string maca = dt.Rows[4]["MaCa"].ToString();
                            if (pc.themPhanCong(manv, ngay, maca))
                            {

                            }
                            maca = dt.Rows[5]["MaCa"].ToString();
                            if (pc.themPhanCong(manv, ngay, maca))
                            {

                            }
                        }
                        else if (phanca == "")
                        {

                        }
                    }
                }
                MessageBox.Show("Phân ca thành công", "Phân công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi phân ca, vui lòng xem lại \n\nThông tin lỗi: " + ex.Message, "Phân công", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
