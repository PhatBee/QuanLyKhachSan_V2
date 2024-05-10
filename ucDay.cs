using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class ucDay : UserControl
    {
        MYDB mydb = new MYDB();
        string _day, date, weekdate;
       

        private void ucDay_Load(object sender, EventArgs e)
        {
            if(_day!="")
            {
                if (DateTime.Now.Day.ToString() == _day && DateTime.Now.Month.ToString() == LichTrucForm._month.ToString())
                {
                    this.BackColor = Color.FromArgb(255, 150, 79);
                }
                SqlCommand command = new SqlCommand("Select ChiTiet From PhanCong INNER JOIN Ca on PhanCong.MaCa = Ca.MaCa Where MaNV = @manv And Ngay = @date ", mydb.getConnection);
                DateTime.TryParse(date.ToString(), out DateTime ngay);
                command.Parameters.Add("@date", SqlDbType.Date).Value = ngay;
                command.Parameters.Add("manv",SqlDbType.VarChar).Value = Globals.GlobalUserID;
                //MessageBox.Show(Globals.GlobalUserID);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                string tg = "";
                if (dt.Rows.Count > 0)
                {
                    for(int i = 0; i< dt.Rows.Count; i++)
                    {
                        tg += dt.Rows[i][0].ToString() + "\n ";
                    }
                }
                lblLichTruc.Text = tg;
            }
                
            
        }

        public ucDay(string day)
        {
            InitializeComponent();
            _day = day;
            label1.Text = day;
            checkBox1.Hide();
            date = _day + "/" + LichTrucForm._month + "/" + LichTrucForm._year;
           // MessageBox.Show(LichTrucForm._month + "/" + _day + "/" + LichTrucForm._year);
        }

        private void sundays()
        {
            try
            {
                DateTime day = DateTime.Parse(date);
                weekdate = day.ToString("ddd");

                if (weekdate == "CN")
                {
                    label1.ForeColor = Color.FromArgb(255, 128, 128);
                }
                else
                {
                    label1.ForeColor = Color.FromArgb(64, 64, 64);
                }
            }
            catch (Exception ex) { }
        }
    }
}
