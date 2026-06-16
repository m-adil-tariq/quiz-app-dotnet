using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    class ViewClass
    {
        private string connstring = ConfigurationManager.ConnectionStrings["quiz"].ConnectionString;
        private string query;

        public ViewClass(string q)
        {
            this.query = q;
        }

        public DataTable showrecord()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No records were found!");
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
    }
}
