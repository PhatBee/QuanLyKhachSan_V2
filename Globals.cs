using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    public class Globals
    {
        public static string GlobalUserID { get; private set; }

        public static void SetGlobalUserID(string userid)
        {
            GlobalUserID = userid;
        }
    }
}
