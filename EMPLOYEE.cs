using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using System.Net;
using System.Xml.Linq;
using System.IO;

namespace QuanLyKhachSan
{
    internal class EMPLOYEE
    {
        MYDB mydb = new MYDB();

        public bool insertEmployee(string manv, string hoten, DateTime ngaysinh, string chucvu, string phai, string cccd, string sdt, string diachi, MemoryStream hinhanh)
        {
            SqlCommand command = new SqlCommand("INSERT INTO NhanVien (MaNV, TenNV, NgaySinh, Phai, CCCD, SoDT, DiaChi, HinhAnh, MaCV)"
                + "VALUES (@manv, @hoten, @ngaysinh, @phai, @cccd, @sdt, @diachi, @hinhanh, @chucvu)", mydb.getConnection);
            command.Parameters.Add("@manv", SqlDbType.VarChar).Value = manv;
            command.Parameters.Add("@hoten", SqlDbType.NVarChar).Value = hoten;
            command.Parameters.Add("@ngaysinh", SqlDbType.DateTime).Value = ngaysinh;
            command.Parameters.Add("@chucvu", SqlDbType.VarChar).Value = chucvu;
            command.Parameters.Add("@phai", SqlDbType.NVarChar).Value = phai;
            command.Parameters.Add("@cccd", SqlDbType.VarChar).Value = cccd;
            command.Parameters.Add("@sdt", SqlDbType.VarChar).Value = sdt;
            command.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = diachi;
            command.Parameters.Add("@hinhanh", SqlDbType.Image).Value = hinhanh.ToArray();


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

        public bool updateEmployee(string manv, string hoten, DateTime ngaysinh, string chucvu, string phai, string cccd, string sdt, string diachi, MemoryStream hinhanh)
        {
            SqlCommand command = new SqlCommand("UPDATE NhanVien SET TenNV = @hoten, NgaySinh = @ngaysinh, MaCV = @chucvu, Phai = @phai, CCCD = @cccd, " +
                "SoDT = @sdt, DiaChi = @diachi, HinhAnh = @hinhanh WHERE MaNV = @manv", mydb.getConnection);
            command.Parameters.Add("@manv", SqlDbType.VarChar).Value = manv;
            command.Parameters.Add("@hoten", SqlDbType.NVarChar).Value = hoten;
            command.Parameters.Add("@ngaysinh", SqlDbType.DateTime).Value = ngaysinh;
            command.Parameters.Add("@chucvu", SqlDbType.VarChar).Value = chucvu;
            command.Parameters.Add("@phai", SqlDbType.NVarChar).Value = phai;
            command.Parameters.Add("@cccd", SqlDbType.VarChar).Value = cccd;
            command.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = diachi;
            command.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = sdt;
            command.Parameters.Add("@hinhanh", SqlDbType.Image).Value = hinhanh.ToArray();
            /*command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;*/


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

        public bool deleteEmployee(string id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Employees WHERE MaNV = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
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

        public bool insertAccount(string manv, string user, string pass)
        {
            SqlCommand command = new SqlCommand("INSERT INTO DangNhap (MaNV, Username, Password)"
               + "VALUES (@manv, @us, @pass)", mydb.getConnection);
            command.Parameters.Add("@manv", SqlDbType.VarChar).Value = manv;
            command.Parameters.Add("@us", SqlDbType.VarChar).Value = user;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
            


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

        public DataTable getStudents(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
