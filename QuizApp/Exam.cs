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
using System.Xml.Linq;

namespace QuizApp
{
    class Exam
    {
        public int ex_id;
        string ex_name;

        addExam e;

        public Exam(int ex_id)
        {
            this.ex_id = ex_id;
            ex_name = returnClass.scalarReturn("select ex_name from exam where ex_id = '" + ex_id + "'");
        }
        public Exam(addExam e, string ex_name)
        {
            this.ex_name = ex_name;
            this.e = e;


            string msg = " ";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["quiz"].ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("insert_exam", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ex_name", SqlDbType.NVarChar, 20).Value = ex_name;

                SqlParameter outputIdParam = new SqlParameter("@ex_id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdParam);

                conn.Open();
                cmd.ExecuteNonQuery();

                ex_id = (int)outputIdParam.Value;

                msg = $"New Exam successfully added!!  \n\n\nex_id : {ex_id}";
                MetroFramework.MetroMessageBox.Show(e, msg, "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                msg = "data is not successfully inserted!" + ex.Message;
                MetroFramework.MetroMessageBox.Show(e, msg, "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
        }
        public static void del_exam(int id)
        {
            returnClass.execute_cmd("Delete from score where fk_set_ex_id in (select set_exam_id from set_exam where ex_id_fk =" + id + ")");
            returnClass.execute_cmd("Delete from set_exam where ex_id_fk = " + id);
            returnClass.execute_cmd("Delete from question where q_fk_ex = " + id);
            returnClass.execute_cmd("Delete from exam where ex_id = " + id);
        }
    }
}
