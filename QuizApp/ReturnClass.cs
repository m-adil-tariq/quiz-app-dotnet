using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace QuizApp
{
    class returnClass
    {
        static string connString = ConfigurationManager.ConnectionStrings["quiz"].ConnectionString;

        public static string scalarReturn(string q)
        {
            string s;
            var conn = new SqlConnection(connString);
            conn.Open();

            try
            {
                var cmd = new SqlCommand(q, conn);
                s = cmd.ExecuteScalar().ToString();
            }
            catch(Exception ex)
            {
                s = "";
            }
            conn.Close();
            return s;
        }
        public static void execute_cmd(string q)
        {
            var conn = new SqlConnection(connString);
            conn.Open();
            try
            {
                new SqlCommand(q, conn).ExecuteNonQuery();
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Nah"+ex.Message);

            }
            conn.Close();
        }
    }
}
