using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    public class PhongADO
    {
        private static PhongADO instance;

        public static PhongADO Instance
        {
            get { if  (instance == null) instance = new PhongADO(); return PhongADO.instance; } 
            private set { PhongADO.instance = value; }
        }

        public static int PhongWidth = 50;
        public static int PhongHeight = 50;

        private PhongADO()
        {

        }

        public List<Phong> LoadDSPhong()
        {
            List<Phong> dsPhong = new List<Phong>();

            string connectionString = "Data Source=azureforwin.database.windows.net;Initial Catalog=QuanLyKhachSan;User ID=phatbee;Password=Bee30092004.;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(connectionString);

            string query = "SELECT * FROM ROOMS";

            con.Open();
            
            SqlCommand cmd = new SqlCommand(query, con);

            DataTable data = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(data);
            
            con.Close();

            foreach (DataRow item in data.Rows) 
            {
                Phong phong = new Phong(item);
                dsPhong.Add(phong);  
            }

            return dsPhong;


        }
    }
}
