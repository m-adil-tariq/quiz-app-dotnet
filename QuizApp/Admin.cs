using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuizApp
{
    public class Admin
    {
        int? ad_id;
        public string ad_user;
        public string ad_password;
        addAdmin a;

        public Admin(string user, string pass)
        {
            ad_user = user;
            ad_password = pass;
        }

        public Admin(addAdmin a, string ad_user, string ad_password)
        {
            this.ad_user = ad_user;
            this.ad_password = ad_password;
            this.a = a;

            string msg = " ";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["quiz"].ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("insert_admin", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ad_user", SqlDbType.NVarChar, 20).Value = ad_user;
                cmd.Parameters.Add("@ad_password", SqlDbType.NVarChar, 20).Value = ad_password;

                SqlParameter outputIdParam = new SqlParameter("@ad_id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdParam);

                conn.Open();
                cmd.ExecuteNonQuery();

                ad_id = (int)outputIdParam.Value;

                msg = $"New Admin successfully added!!  \n\n\nad_id : {ad_id}";
                MetroFramework.MetroMessageBox.Show(a, msg, "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                msg = "data is not successfully inserted!";
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
