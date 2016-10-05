using Revision_Helper.Properties;
using System;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;

namespace Revision_Helper
{
    public partial class Test : Form
    {
        int Res;

        DatabaseConnection objConnectTopics;
        DatabaseConnection objConnectQuestions;
        string conString;

        DataSet dataSetTopics;
        DataTable dataTableQuestions;

        int TestLength;
        int[] questionNums;
        int questionIndex = 0;
        int time = 0;
        Button correctButton = new Button();
        Button[] incorrectButton = new Button[3];
        Random rnd = new Random();

        int speed = 0;
        int correct = 0;
        int incorrect = 0;

        public Test(int res, DataTable tblQuestions, int testLength)
        {
            Res = res;
            TestLength = testLength;
            InitializeComponent();
            InitialAdjust();
            questionNums = new int[TestLength];
            BackColor = new ColourRandomisor().colour;
            try
            {
                objConnectTopics = new DatabaseConnection();
                conString = Settings.Default.RevisionDatabaseConnectionString;
                objConnectTopics.connectionString = conString;

                objConnectTopics.SQL = Settings.Default.SqlSelectFromtblTopics;
                dataSetTopics = objConnectTopics.GetConnection;

                dataTableQuestions = tblQuestions;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            lblCount.Text = "0/" + TestLength;
            SelectQuestions();
            NextQuestion();
        }

        private void SelectQuestions()
        {
            for (int j = 0; j < questionNums.Length; j++)
            {
                questionNums[j] = -1;
            }
            int i = 0;
            while (questionNums[TestLength - 1] == -1)
            {
                int num = rnd.Next(0, dataTableQuestions.Rows.Count);
                if (!CheckIfContainsNum(questionNums, num))
                {
                    questionNums[i] = num;
                    i++;
                }
            }
        }

        private bool CheckIfContainsNum(int[] array, int num)
        {
            foreach (int item in array)
            {
                if (num == item)
                {
                    return true;
                }
            }
            return false;
        }

        public void SetIncorrctAnswers(ref Button button1, ref Button button2, ref Button button3, int howManyAnswers)
        {
            if (howManyAnswers == 2)
            {
                incorrectButton[0] = button1;
            }

            if (howManyAnswers == 3)
            {
                if (rnd.Next(1, 3) == 1)
                {
                    incorrectButton[0] = button1;
                    incorrectButton[1] = button2;
                }
                else
                {
                    incorrectButton[1] = button1;
                    incorrectButton[0] = button2;
                }
            }

            if (howManyAnswers == 4)
            {
                int num = rnd.Next(1, 4);
                if (num == 1)
                {
                    incorrectButton[0] = button1;
                    if (rnd.Next(1, 3) == 1)
                    {
                        incorrectButton[1] = button2;
                        incorrectButton[2] = button3;
                    }
                    else
                    {
                        incorrectButton[2] = button2;
                        incorrectButton[1] = button3;
                    }
                }
                if (num == 2)
                {
                    incorrectButton[0] = button2;
                    if (rnd.Next(1, 3) == 1)
                    {
                        incorrectButton[1] = button1;
                        incorrectButton[2] = button3;
                    }
                    else
                    {
                        incorrectButton[2] = button1;
                        incorrectButton[1] = button3;
                    }
                }
                if (num == 3)
                {
                    incorrectButton[0] = button3;
                    if (rnd.Next(1, 3) == 1)
                    {
                        incorrectButton[1] = button2;
                        incorrectButton[2] = button1;
                    }
                    else
                    {
                        incorrectButton[2] = button2;
                        incorrectButton[1] = button1;
                    }
                }
            }
        }

        private void NextQuestion()
        {
            if (questionIndex >= TestLength)
            {
                lblCount.Dispose();
            }
            lblCount.Text = (questionIndex + 1) + "/" + TestLength;
            if (questionIndex >= TestLength)
            {
                try
                {
                    objConnectTopics.UpdateDatabase(dataSetTopics);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                    return;
                }
                Close();
                Results results = new Results(correct, incorrect, speed/(correct+incorrect));
                results.ShowDialog();
                return;
            }
            btnA1.Enabled = true;
            btnA2.Enabled = true;
            btnA3.Enabled = true;
            btnA4.Enabled = true;
            btnA1.BackColor = Color.Tomato;
            btnA2.BackColor = Color.Khaki;
            btnA3.BackColor = Color.DarkSeaGreen;
            btnA4.BackColor = Color.MediumPurple;
            btnA1.Text = "";
            btnA2.Text = "";
            btnA3.Text = "";
            btnA4.Text = "";
            txtQuestion.Text = dataTableQuestions.Rows[questionNums[questionIndex]][2].ToString();
            int howManyAnswers = 0;
            for (int i = 3; i < 7; i++)
            {
                if (dataTableQuestions.Rows[questionNums[questionIndex]][i].ToString() != "")
                {
                    howManyAnswers++;
                }
            }
            switch (rnd.Next(1, howManyAnswers + 1))
            {
                case 1: correctButton = btnA1; SetIncorrctAnswers(ref btnA2, ref btnA3, ref btnA4, howManyAnswers); break;
                case 2: correctButton = btnA2; SetIncorrctAnswers(ref btnA1, ref btnA3, ref btnA4, howManyAnswers); break;
                case 3: correctButton = btnA3; SetIncorrctAnswers(ref btnA1, ref btnA2, ref btnA4, howManyAnswers); break;
                case 4: correctButton = btnA4; SetIncorrctAnswers(ref btnA1, ref btnA2, ref btnA3, howManyAnswers); break;
                default: break;
            }
            correctButton.Text = dataTableQuestions.Rows[questionNums[questionIndex]][3].ToString();
            int skip = 0;
            for (int i = 0; i < howManyAnswers - 1; i++)
            {
                if (dataTableQuestions.Rows[questionNums[questionIndex]][i + 4 + skip].ToString() != "")
                {
                    incorrectButton[i].Text = dataTableQuestions.Rows[questionNums[questionIndex]][i + 4 + skip].ToString();
                }
                else
                {
                    skip++;
                    i--;
                }
            }
            if (btnA1.Text == "")
            {
                btnA1.Enabled = false;
            }
            if (btnA2.Text == "")
            {
                btnA2.Enabled = false;
            }
            if (btnA3.Text == "")
            {
                btnA3.Enabled = false;
            }
            if (btnA4.Text == "")
            {
                btnA4.Enabled = false;
            }
            tmrSpeed.Start();
        }

        private void btn_Selected(object sender, EventArgs e)
        {
            tmrSpeed.Stop();
            int index = GetTopicRow(dataTableQuestions.Rows[questionNums[questionIndex]][1].ToString());
            Control button = ((Control)sender);
            if (sender == correctButton)
            {
                button.BackColor = Color.Green;
                int x = (int)dataSetTopics.Tables[0].Rows[index][5];
                dataSetTopics.Tables[0].Rows[index][5] = x+1;
                correct++;
            }
            else
            {
                button.BackColor = Color.Red;
                int x = (int)dataSetTopics.Tables[0].Rows[index][6];
                dataSetTopics.Tables[0].Rows[index][6] = x + 1;
                incorrect++;
            }
            int total = (int)dataSetTopics.Tables[0].Rows[index][6] + (int)dataSetTopics.Tables[0].Rows[index][5];
            int y = (int)dataSetTopics.Tables[0].Rows[index][7];
            dataSetTopics.Tables[0].Rows[index][7] = (((y * (total - 1)) + time) / total);
            speed += time;
            questionIndex++;
            txtQuestion.Text = "";
            btnA1.Enabled = false;
            btnA2.Enabled = false;
            btnA3.Enabled = false;
            btnA4.Enabled = false;
            time = 0;
            tmrSpeed.Start();
        }

        private void tmrSpeed_Tick(object sender, EventArgs e)
        {
            if (tmrSpeed.Enabled)
            {
                time++;
            }
            if (time == 50 && txtQuestion.Text == "")
            {
                time = 0;
                tmrSpeed.Stop();
                NextQuestion();
            }
        }

        private void Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrSpeed.Stop();
            tmrSpeed.Dispose();
            tmrSpeed = null;
            this.Dispose();
        }

        private int GetTopicRow(string Topic)
        {
            for (int i = 0; i < dataSetTopics.Tables[0].Rows.Count; i++)
            {
                if (dataSetTopics.Tables[0].Rows[i][1].ToString() ==Topic )
                {
                    return i;
                }
            }
            return -1;
        }

        private void InitialAdjust()
        {
            foreach (Control cont in this.Controls)
            {
                Shift(cont);
            }
        }

        private void Shift(Control cont)
        {
            if (Res == 2)
            {
                cont.Font = new Font(cont.Font.FontFamily, cont.Font.Size / 6);
                cont.Font = new Font(cont.Font.FontFamily, cont.Font.Size * 5);
                cont.Location = new Point(cont.Location.X / 6, cont.Location.Y / 6);
                cont.Location = new Point(cont.Location.X * 5, cont.Location.Y * 5);
                cont.Height /= 6;
                cont.Height *= 5;
                cont.Width /= 6;
                cont.Width *= 5;
            }
            else if (Res == 3)
            {
                cont.Font = new Font(cont.Font.FontFamily, cont.Font.Size / 3);
                cont.Font = new Font(cont.Font.FontFamily, cont.Font.Size * 2);
                cont.Location = new Point(cont.Location.X / 3, cont.Location.Y / 3);
                cont.Location = new Point(cont.Location.X * 2, cont.Location.Y * 2);
                cont.Height /= 3;
                cont.Height *= 2;
                cont.Width /= 3;
                cont.Width *= 2;
            }
        }
    }
}