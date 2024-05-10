using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    public class PHANCONG
    {
        MYDB mydb = new MYDB();

        public bool themPhanCong(string manv, DateTime Ngay, string maca)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO PhanCong (MaNV, Ngay, MaCa) " +
                "VALUES (@mnv, @ngay, @maca)", mydb.getConnection);

            cmd.Parameters.Add("@mnv", SqlDbType.VarChar).Value = manv;
            cmd.Parameters.Add("@ngay", SqlDbType.DateTime).Value = Ngay;
            cmd.Parameters.Add("@maca", SqlDbType.VarChar).Value = maca;

            mydb.openConection();

            if (cmd.ExecuteNonQuery() == 1)
            {
                mydb.closeConection();
                return true;
            }
            else
            {
                mydb.closeConection();
                return false;
            }
        }

        public bool exist(string manv, DateTime Ngay, string maca)
        {
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT Ngay FROM PhanCong " +
                "WHERE MaNV = @manv and MaCa = @maca", mydb.getConnection);

            cmd.Parameters.Add("@manv", SqlDbType.VarChar).Value = manv;
            cmd.Parameters.Add("@maca", SqlDbType.VarChar).Value = maca;

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            adpt.Fill(tb);

            if (tb.Rows.Count > 0)
            {
                foreach (DataRow dr in tb.Rows) 
                {
                    DateTime pc = (DateTime)dr["Ngay"];
                    if (pc.Date == Ngay.Date)
                    {
                        return true;
                    }    
                }
                return false;
            }
            else
            {
                return false;
            }    
        }
    }
}
