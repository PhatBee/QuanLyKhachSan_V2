using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    internal class MYDB
    {
        // Tân
        // private static string connectionSTR = "Data Source=.;Initial Catalog=QuanLyKhachSan;Persist Security Info=True;User ID=sa;Password=1234;Encrypt=True;TrustServerCertificate=True";
        
        // Bee
        private static string connectionSTR = "Data Source=LAPTOP-1BLCIFVL\\PHATBEE;Initial Catalog=QuanLyKhachSan;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        // SqlConnection con = new SqlConnection("Data Source=azureforwin.database.windows.net;Initial Catalog=QuanLyKhachSan;User ID=phatbee;Password=Bee30092004.;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        SqlConnection con = new SqlConnection(connectionSTR);

        // get the connection
        public SqlConnection getConnection
        {
            get { return con; }
        }

        // open the connection
        public void openConection()
        {
            if ((con.State == System.Data.ConnectionState.Closed))
            {
                con.Open();
            }
        }

        // close the connection
        public void closeConection()
        {
            if ((con.State == System.Data.ConnectionState.Open))
            {
                con.Close();
            }
        }

        
    }
}
