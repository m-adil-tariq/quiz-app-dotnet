using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace QuizApp
{
    public partial class Test : BaseForm
    {
        string set_ex_id;
        int std_id;
        string ex_id;
        private System.Windows.Forms.Timer quizTimer;
        TimeSpan timeLeft;

        public Test(string set_ex_id, int std_id)
        {
            InitializeComponent();
            this.set_ex_id = set_ex_id;
            this.ex_id = returnClass.scalarReturn($"select ex_id_fk from set_exam where set_exam_id = '{set_ex_id}'");
            this.std_id = std_id;
            timeLeft = TimeSpan.FromMinutes(int.Parse(returnClass.scalarReturn($"select count(q_id) from question where q_fk_ex = {ex_id}")));
        }

        int i;
        string correct;
        float scoreVal = 0;

        SpeechSynthesizer synth = new SpeechSynthesizer();

        private void Speak(string text)
        {
            synth.SpeakAsyncCancelAll();
            synth.Volume = 100;
            synth.Rate = 0;
            synth.SpeakAsync(text);
        }
        private void QuizTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft.TotalSeconds > 1)
            {
                timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
                label3.Text = timeLeft.ToString(@"mm\:ss");
            }
            else
            {
                quizTimer.Stop();
                MessageBox.Show("Time is up! Auto-submitting your test.");

                AssignExamClass ac = new AssignExamClass(int.Parse(set_ex_id));
                float noOfQ = int.Parse(returnClass.scalarReturn($"select count(q_id) from question where q_fk_ex = {ex_id}"));
                score s = new score(Convert.ToInt32(scoreVal), (scoreVal / noOfQ) * 100, ac);
                var form = new TestEnd(s.Score, (int)(noOfQ));
                synth.SpeakAsyncCancelAll();
                this.Hide();
                form.FormClosed += (sc, args) => this.Close();
                form.Show();
            }
        }



        private void test_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            i = int.Parse(returnClass.scalarReturn($"select min(q_id) from question where q_fk_ex = {ex_id}"));

            label1.Text = returnClass.scalarReturn($"select q_title from question where q_id = {i}");
            radioButton1.Text = returnClass.scalarReturn($"select q_a from question where q_id = {i}");
            radioButton2.Text = returnClass.scalarReturn($"select q_b from question where q_id = {i}");
            radioButton3.Text = returnClass.scalarReturn($"select q_c from question where q_id = {i}");
            radioButton4.Text = returnClass.scalarReturn($"select q_d from question where q_id = {i}");

            quizTimer = new System.Windows.Forms.Timer();
            quizTimer.Interval = 1000;
            quizTimer.Tick += QuizTimer_Tick;
            quizTimer.Start();

            label3.Text = timeLeft.ToString(@"mm\:ss");



            SpeakFullQuestion();
        }

        private void SpeakFullQuestion()
        {
            string full = $"{label1.Text}. Option A: {radioButton1.Text}. Option B: {radioButton2.Text}. Option C: {radioButton3.Text}. Option D: {radioButton4.Text}.";
            Speak(full);
        }

        string s, selected;

        private void button1_Click(object sender, EventArgs e)
        {
            correct = returnClass.scalarReturn($"select q_correct from question where q_id = {i}");

            if (radioButton1.Checked) selected = radioButton1.Text;
            else if (radioButton2.Checked) selected = radioButton2.Text;
            else if (radioButton3.Checked) selected = radioButton3.Text;
            else if (radioButton4.Checked) selected = radioButton4.Text;
            else selected = "";

            if (selected == correct)
            {
                scoreVal++;
            }


            s = returnClass.scalarReturn($"select min(q_id) from question where q_id > {i} and q_fk_ex = {ex_id}");

            if (s == "")
            {
                float noOfQ = int.Parse(returnClass.scalarReturn($"select count(q_id) from question where q_fk_ex = {ex_id}"));
                MessageBox.Show("No more questions");


                AssignExamClass ac = new AssignExamClass(int.Parse(set_ex_id));
                score s = new score(Convert.ToInt32(scoreVal), (scoreVal / noOfQ) * 100, ac);
                var form = new TestEnd(s.Score, (int)(noOfQ));
                synth.SpeakAsyncCancelAll();
                this.Hide();
                form.FormClosed += (sc, args) => this.Close();
                form.Show();
                this.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;

                i = int.Parse(s);
                label1.Text = returnClass.scalarReturn($"select q_title from question where q_id = {i} and q_fk_ex = {ex_id}");
                radioButton1.Text = returnClass.scalarReturn($"select q_a from question where q_id = {i}");
                radioButton2.Text = returnClass.scalarReturn($"select q_b from question where q_id = {i}");
                radioButton3.Text = returnClass.scalarReturn($"select q_c from question where q_id = {i}");
                radioButton4.Text = returnClass.scalarReturn($"select q_d from question where q_id = {i}");

                SpeakFullQuestion();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e) { }
    }
}
