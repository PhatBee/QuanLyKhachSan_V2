using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    public class BAOCAO
    {
        MYDB mydb = new MYDB();

        public bool themBaoCao(string manv, DateTime ngay, int tonggiolam, int tonggiotre, int luong, int xacnhan)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO BaoCao (MaNV, Ngay, TongGioLam, TongGioTre, Luong, XacNhan) " +
                "VALUES (@manv, @ngay, @tonglam, @tongtre, @luong, @xn)", mydb.getConnection);
            cmd.Parameters.Add("@manv", SqlDbType.VarChar).Value = manv;
            cmd.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
            cmd.Parameters.Add("@tonglam", SqlDbType.Int).Value = tonggiolam;
            cmd.Parameters.Add("@tongtre", SqlDbType.Int).Value = tonggiotre;
            cmd.Parameters.Add("@luong", SqlDbType.Int).Value = luong;
            cmd.Parameters.Add("@xn", SqlDbType.Bit).Value = xacnhan;

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
    }
}
