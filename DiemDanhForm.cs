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
    public partial class DiemDanhForm : Form
    {
        public DiemDanhForm()
        {
            InitializeComponent();
        }
        MYDB mydb = new MYDB();
        private void DiemDanhForm_Load(object sender, EventArgs e)
        {
            DateTime currentDay = DateTime.Now;

            string query = "Select  from  Ca INNER JOIN  PhanCong on Ca.MaCa = PhanCong.MaCa Where PhanCong.MaNV = '" + Globals.GlobalUserID + "'";
            DataTable dataTable = new DataTable();
            dataTable = createTable(query);


        }
        public DataTable createTable(string query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, mydb.getConnection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
