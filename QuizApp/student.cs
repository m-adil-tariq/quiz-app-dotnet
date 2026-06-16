using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    class student
    {
        Admin a;
        public int id;
        public string name;
        public string batchcode;
        public string password;
        public int std_ad_id;

        addStudent s;

        public student(int id)
        {
            this.id = id;
            name = returnClass.scalarReturn($"select std_name from student where std_id = '{id}'");
            batchcode = returnClass.scalarReturn($"select std_batchcode from student where std_id = '{id}'");
            password = returnClass.scalarReturn($"select std_password from student where std_id = '{id}'");
            std_ad_id = int.Parse(returnClass.scalarReturn($"select std_ad_id from student where std_id = '{id}'"));
        }

        public student(string name, string batchcode, string password, Admin a, addStudent s)
        {
            this.name = name;
            this.batchcode = batchcode;
            this.password = password;
            this.a = a;
            std_ad_id = int.Parse(a.ad_user);
            this.s = s;

            string msg = " ";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["quiz"].ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("insert_student", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@std_name", SqlDbType.NVarChar, 20).Value = name;
                cmd.Parameters.Add("@std_batchcode", SqlDbType.NVarChar, 20).Value = batchcode;
                cmd.Parameters.Add("@std_password", SqlDbType.NVarChar, 20).Value = password;
                cmd.Parameters.Add("@std_ad_id", SqlDbType.Int).Value = std_ad_id;

                SqlParameter outputIdParam = new SqlParameter("@std_id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdParam);

                conn.Open();
                cmd.ExecuteNonQuery();

                id = (int)outputIdParam.Value;

                msg = $"New Student successfully added!!  \n\n\nstd_id : {id}";
                MetroFramework.MetroMessageBox.Show(s, msg, "Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public static void del_student(int id)
        {
            returnClass.execute_cmd("Delete from score where fk_set_ex_id = (select set_exam_id from set_exam where std_id_fk =" + id + ")");
            returnClass.execute_cmd("Delete from set_exam where std_id_fk = " + id);
            returnClass.execute_cmd("Delete from student where std_id = " + id);
        }
    }
}
