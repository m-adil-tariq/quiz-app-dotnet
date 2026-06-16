using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    class questions
    {
        public int q_id { get; set; }
        public string q_title { get; set; }
        public string q_a { get; set; }
        public string q_b { get; set; }
        public string q_c { get; set; }
        public string q_d { get; set; }
        public string q_correct { get; set; }
        public string q_addeddate { get; set; }
        Admin a;
        Exam e;

        public string q_fk_ad { get; set; }
        public string q_fk_ex { get; set; }

        public questions(string q_title, string q_a, string q_b, string q_c, string q_d, string q_correct, Admin a, Exam e)
        {
            this.q_title = q_title;
            this.q_a = q_a;
            this.q_b = q_b;
            this.q_c = q_c;
            this.q_d = q_d;
            this.q_correct = q_correct;
            this.q_addeddate = DateTime.Today.ToShortDateString();
            this.a = a;
            this.e = e;
            q_fk_ad = a.ad_user;
            q_fk_ex = e.ex_id.ToString();

            string msg = " ";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["quiz"].ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("insert_question", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@q_title", SqlDbType.NVarChar).Value = q_title;
                cmd.Parameters.Add("@q_a", SqlDbType.NVarChar, 200).Value = q_a;
                cmd.Parameters.Add("@q_b", SqlDbType.NVarChar, 200).Value = q_b;
                cmd.Parameters.Add("@q_c", SqlDbType.NVarChar, 200).Value = q_c;
                cmd.Parameters.Add("@q_d", SqlDbType.NVarChar, 200).Value = q_d;
                cmd.Parameters.Add("@q_correct", SqlDbType.NVarChar, 200).Value = q_correct;
                cmd.Parameters.Add("@q_addeddate", SqlDbType.NVarChar, 20).Value = q_addeddate;
                cmd.Parameters.Add("@q_fk_ad", SqlDbType.Int).Value = q_fk_ad;
                cmd.Parameters.Add("@q_fk_ex", SqlDbType.Int).Value = q_fk_ex;

                SqlParameter outputIdParam = new SqlParameter("@q_id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdParam);

                conn.Open();
                cmd.ExecuteNonQuery();

                q_id = (int)cmd.Parameters["@q_id"].Value;
                msg = "data successfully inserted!";
            }
            catch (Exception ex)
            {
                msg = "data is not successfully inserted!: " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
            MessageBox.Show(msg);
        }

        public static void del_q(int id)
        {

            returnClass.execute_cmd("Delete from question where q_id = " + id);
        }
    }
}
