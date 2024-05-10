using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    public class Phong
    {
        MYDB mydb = new MYDB();
        public bool ThemPhong(string maphong, string maloaiphong)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Phong (MaPhong, MaLoaiPhong, TinhTrang) " +
                "VALUES (@mp, @mlp, @tt)", mydb.getConnection);
            command.Parameters.Add("@mp",SqlDbType.VarChar).Value = maphong;
            command.Parameters.Add("@mlp", SqlDbType.VarChar).Value = maloaiphong;
            command.Parameters.Add("@tt", SqlDbType.Bit).Value = 0;

            mydb.openConection();

            if (command.ExecuteNonQuery() == 1)
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

        public bool SuaPhong(string maphong, string maloaiphong)
        {
            SqlCommand command = new SqlCommand("UPDATE Phong SET MaLoaiPhong = @mlp WHERE MaPhong = @mp", mydb.getConnection);
            command.Parameters.Add("@mp", SqlDbType.VarChar).Value = maphong;
            command.Parameters.Add("@mlp", SqlDbType.VarChar).Value = maloaiphong;

            mydb.openConection();

            if (command.ExecuteNonQuery() == 1)
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

        public bool XoaPhong(string maphong)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Phong WHERE MaPhong = @mp", mydb.getConnection);
            command.Parameters.Add("@mp", SqlDbType.VarChar).Value = maphong;

            mydb.openConection();

            if (command.ExecuteNonQuery() == 1)
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

        public DataTable getPhong(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public Phong()
        {
           
        }

        public Phong(string maphong, bool trangthai, string loai) 
        {
            this.Maphong = maphong;
            this.Trangthai = trangthai;
            this.Loai = loai;
        }

        public Phong(DataRow row)
        {
            this.Maphong = row["MaPhong"].ToString();
            this.Loai = row["MaLoaiPhong"].ToString();
            this.trangthai = (bool)row["TinhTrang"];


        }

        private string maphong;

        public string Maphong { get => maphong; set => maphong = value; }

        private bool trangthai;

        public bool Trangthai { get => trangthai; set => trangthai = value; }
        

        private string loai;


        public string Loai { get => loai; set => loai = value; }
       
    }
}
