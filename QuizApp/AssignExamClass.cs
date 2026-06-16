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
    class AssignExamClass
    {
        public string date;
        public int set_exam_id;
        student s;
        Exam ex;

        public int std_id;
        public int ex_id;
        AssignExam a;

        public AssignExamClass(int id)
        {
            set_exam_id = id;
            date = returnClass.scalarReturn($"select set_exam_date from set_exam where set_exam_id = '{id}'");
        }

        public AssignExamClass(AssignExam a, student s, Exam ex)
        {
            this.s = s;
            this.ex = ex;
            this.a = a;
            this.std_id = s.id;
            this.ex_id = ex.ex_id;
            date = DateTime.Today.ToShortDateString();


            string msg = " ";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["quiz"].ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("assign_exam", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@set_exam_date", SqlDbType.VarChar, 20).Value = date;
                cmd.Parameters.Add("@std_id_fk", SqlDbType.Int).Value = std_id;
                cmd.Parameters.Add("@ex_id_fk", SqlDbType.Int).Value = ex_id;

                SqlParameter outputIdParam = new SqlParameter("@set_exam_id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdParam);

                conn.Open();
                cmd.ExecuteNonQuery();

                set_exam_id = (int)outputIdParam.Value;

                msg = "Exam Assigned Successfully";
                MetroFramework.MetroMessageBox.Show(a, msg, "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exe)
            {
                msg = "Something Went Wrong";
                MetroFramework.MetroMessageBox.Show(a, msg, "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
        }
        public static void del_assignexam(int id)
        {

            returnClass.execute_cmd("Delete from score where fk_set_ex_id = " + id);
            returnClass.execute_cmd("Delete from set_exam where set_exam_id = " + id);
        }
    }
}
