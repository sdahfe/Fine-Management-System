using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace Semester_MS
{    //Makiing connection with database using state class
    public static class state
    {
      
        public static SqlConnection con = new SqlConnection(@"Server = DESKTOP-0EGE15A;Initial Catalog=gpgc;Integrated Security=True");
        public static int Admin_login_id { get; set; }
        public static int Teacher_login_id { get; set; }
        public static int Student_login_id { get; set; }
        public static string section { get; set; }
        public static void clearVirtualtbl()
        {
            state.con.Open();
            SqlCommand cmd = new SqlCommand("delete from virtualtbl", state.con);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from sorttbl";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from finaltbl";
            cmd.ExecuteNonQuery();
            state.con.Close();
        }

    }
}
