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
    class score
    {
        public int? id;
        public int Score;
        public float percentage;
        AssignExamClass ac;

        public int fk_set_ex_id;

        public score(int score, float percentage, AssignExamClass ac)
        {
            this.ac = ac;
            Score = score;
            this.percentage = percentage;

            this.fk_set_ex_id = ac.set_exam_id;

            string msg = " ";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["quiz"].ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("insert_score", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@score", SqlDbType.Int).Value = Score;
                cmd.Parameters.Add("@percentage", SqlDbType.Float).Value = percentage;
                cmd.Parameters.Add("@fk_set_ex_id", SqlDbType.Int).Value = fk_set_ex_id;
                
                SqlParameter outputIdParam = new SqlParameter("@score_id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdParam);

                conn.Open();
                cmd.ExecuteNonQuery();

                id = (int)cmd.Parameters["@score_id"].Value;
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
    }
        public static void del_score(int id)
        {

            returnClass.execute_cmd("Delete from score where score_id = " + id);
        }
    }
}
