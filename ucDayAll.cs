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
    public partial class ucDayAll : UserControl
    {
        MYDB mydb = new MYDB();
        string _day, date, weekdate;

        public ucDayAll(string day)
        {
            InitializeComponent();
            _day = day;
            label1.Text = day;
            checkBox1.Hide();
            date = _day + "/" + LichTrucTatCaNhanVien._month + "/" + LichTrucTatCaNhanVien._year;
            // MessageBox.Show(LichTrucForm._month + "/" + _day + "/" + LichTrucForm._year);
        }

        private void ucDayAll_Load(object sender, EventArgs e)
        {
            if (_day != "")
            {
                if (DateTime.Now.Day.ToString() == _day && DateTime.Now.Month.ToString() == LichTrucForm._month.ToString())
                {
                    this.BackColor = Color.FromArgb(255, 150, 79);
                }
                SqlCommand command = new SqlCommand("Select PhanCong.MaCa, MaNV From PhanCong " +
                    "INNER JOIN Ca on PhanCong.MaCa = Ca.MaCa " +
                    "Where Ngay = @date " +
                    "Order By PhanCong.MaCa", mydb.getConnection);
                DateTime.TryParse(date.ToString(), out DateTime ngay);
                command.Parameters.Add("@date", SqlDbType.Date).Value = ngay;
                //command.Parameters.Add("manv", SqlDbType.VarChar).Value = Globals.GlobalUserID;
                //MessageBox.Show(Globals.GlobalUserID);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                string tg = "";
                string maHienTai = "";
                
                foreach (DataRow dr in dt.Rows)
                {
                    string maCa = dr[0].ToString();
                    string maNv = dr[1].ToString();

                    if (maHienTai != maCa)
                    {
                        if (maHienTai != "")
                        {
                            tg += "\n";
                        }

                        maHienTai = maCa;
                        tg += ConvertCaString(maCa) + ": ";
                    }
                    else
                    {
                        tg += ", ";
                    }
                    tg += maNv;
                     
                }
                lblLichTruc.Text = tg;
            }
        }

        private static string ConvertCaString(string input)
        {
            string convert = "Ca " + int.Parse(input.Substring(2));
            return convert;
        }
    }
}
