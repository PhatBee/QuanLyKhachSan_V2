using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    public class HOADON
    {
        MYDB mydb = new MYDB();

        public bool themHoaDon(string mahd, string maphong, string tenkhach, string cccd, string sdt, string ghichu, DateTime NgayDat, DateTime NgayTra)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO HoaDon (MaHD, MaPhong, TenKH, CCCD, SDT, GhiChu, NgayDat, NgayTra) " +
                "VALUES (@mahd, @map, @tenkh, @cccd, @sdt, @gc, @dat, @tra)", mydb.getConnection);
            cmd.Parameters.Add("@mahd", SqlDbType.VarChar).Value = mahd;
            cmd.Parameters.Add("@map", SqlDbType.VarChar).Value = maphong;
            cmd.Parameters.Add("@tenkh", SqlDbType.NVarChar).Value = tenkhach;
            cmd.Parameters.Add("@cccd", SqlDbType.VarChar).Value = cccd;
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar).Value = sdt;
            cmd.Parameters.Add("@gc", SqlDbType.NVarChar).Value = ghichu;
            cmd.Parameters.Add("@dat", SqlDbType.DateTime).Value = NgayDat;
            cmd.Parameters.Add("@tra", SqlDbType.DateTime).Value = NgayTra;

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

        public bool capNhatKhachHang(string mahd, string maphong, string tenkhach, string cccd, string sdt, string ghichu)
        {
            SqlCommand cmd = new SqlCommand("UPDATE HoaDon SET MaPhong = @map, TenKH = @tenkh, CCCD = @cccd, SDT = @sdt, GhiChu = @gc " +
                "WHERE MaHD = @mahd", mydb.getConnection);
            cmd.Parameters.Add("@mahd", SqlDbType.VarChar).Value = mahd;
            cmd.Parameters.Add("@map", SqlDbType.VarChar).Value = maphong;
            cmd.Parameters.Add("@tenkh", SqlDbType.NVarChar).Value = tenkhach;
            cmd.Parameters.Add("@cccd", SqlDbType.VarChar).Value = cccd;
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar).Value = sdt;
            cmd.Parameters.Add("@gc", SqlDbType.NVarChar).Value = ghichu;

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
