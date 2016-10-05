using Revision_Helper.Properties;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace Revision_Helper
{
    public partial class TestMenu : Form
    {
        int Res;

        DatabaseConnection objConnectTopics;
        DatabaseConnection objConnectQuestions;
        DatabaseConnection objConnectSubjects;
        string conString;

        DataSet dataSetTopics;
        DataSet dataSetQuestions;
        DataSet dataSetSubjects;
        ColouredCheckedListBox lbxTopics = new ColouredCheckedListBox();
        public TestMenu(int res)
        {
            lbxTopics.Location = new Point(12, 12);
            lbxTopics.Size = new Size(637, 949);
            lbxTopics.Font = new Font("Times New Roman", 12);
            lbxTopics.SelectedIndexChanged += new EventHandler(lbxTopics_SelectedIndexChanged);
            Controls.Add(lbxTopics);
            ActiveControl = lbxTopics;
            Res = res;
            InitializeComponent();
            InitialAdjust();
            try
            {
                objConnectTopics = new DatabaseConnection();
                objConnectQuestions = new DatabaseConnection();
                objConnectSubjects = new DatabaseConnection();
                conString = Settings.Default.RevisionDatabaseConnectionString;
                objConnectTopics.connectionString = conString;
                objConnectQuestions.connectionString = conString;
                objConnectSubjects.connectionString = conString;

                objConnectTopics.SQL = Settings.Default.SqlSelectFromtblTopics;
                dataSetTopics = objConnectTopics.GetConnection;

                objConnectQuestions.SQL = Settings.Default.SqlSelectFromtblQuestions;
                dataSetQuestions = objConnectQuestions.GetConnection;


                objConnectSubjects.SQL = Settings.Default.SqlSelectFromtblSubjects;
                dataSetSubjects = objConnectSubjects.GetConnection;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            List<string> list = new List<string>();
            for (int j = 0; j < dataSetSubjects.Tables[0].Rows.Count; j++)
            {
                for (int i = 0; i < dataSetTopics.Tables[0].Rows.Count; i++)
                {
                    if (dataSetTopics.Tables[0].Rows[i][8].ToString() == dataSetSubjects.Tables[0].Rows[j][1].ToString())
                    {
                        list.Add(dataSetTopics.Tables[0].Rows[i][1].ToString());
                    }
                }
                list.Sort();
                for (int i = 0; i < list.Count; i++)
                {
                    lbxTopics.Items.Add(list[i]);
                }
                list.Clear();
            }
            UpdateOverall();
            FillCbx();
        }

        private void UpdateOverall()
        {
            int total;
            int correct = 0;
            int incorrect = 0;
            int accuracy;
            int speed = 0;
            int skill;
            for (int i = 0; i < dataSetTopics.Tables[0].Rows.Count; i++)
            {
                correct += (int)dataSetTopics.Tables[0].Rows[i][5];
                incorrect += (int)dataSetTopics.Tables[0].Rows[i][6];
                speed += (int)dataSetTopics.Tables[0].Rows[i][7];
            }
            int populatedRows = 0;
            lbxTopics.colours.Clear();
            for (int i = 0; i < dataSetTopics.Tables[0].Rows.Count; i++)
            {
                int index = GetIndex(i);
                lbxTopics.colours.Add(GetSkillColour(GetTopicSkill(index)));
                if ((int)dataSetTopics.Tables[0].Rows[i][7] > 0)
                {
                    populatedRows++;
                }
            }
            if (populatedRows > 0)
            {
                speed /= populatedRows;
            }
            else
            {
                speed = 0;
            }
            total = correct + incorrect;
            if (total > 0)
            {
                accuracy = correct * 100 / total;
            }
            else
            {
                accuracy = 0;
            }
            lblOverallTotal.Text = "Questions Attempted: " + total;
            lblOverallCorrect.Text = "Correct: " + correct;
            lblOverallIncorrect.Text = "Incorrect: " + incorrect;
            lblOverallAccuracy.Text = "Accuracy: " + accuracy + "%";
            double spq = speed;
            spq = Math.Round((spq /= 33), 2);
            lblOverallSpeed.Text = "Speed: " + spq + " SPQ";
            AssignBackColoursOverall(accuracy, spq, total);
        }

        private void UpdateTopic()
        {
            if (lbxTopics.SelectedIndex > -1)
            {
                lblTopic.Text = dataSetTopics.Tables[0].Rows[GetIndex(lbxTopics.SelectedIndex)][1].ToString();
                int total;
                int correct;
                int incorrect;
                int accuracy;
                int speed;
                correct = (int)dataSetTopics.Tables[0].Rows[GetIndex(lbxTopics.SelectedIndex)][5];
                incorrect = (int)dataSetTopics.Tables[0].Rows[GetIndex(lbxTopics.SelectedIndex)][6];
                speed = (int)dataSetTopics.Tables[0].Rows[GetIndex(lbxTopics.SelectedIndex)][7];
                total = correct + incorrect;
                if (total > 0)
                {
                    accuracy = correct * 100 / total;
                }
                else
                {
                    accuracy = 0;
                }
                lblTopicTotal.Text = "Questions Attempted: " + total;
                lblTopicCorrect.Text = "Correct: " + correct;
                lblTopicIncorrect.Text = "Incorrect: " + incorrect;
                lblTopicAccuracy.Text = "Accuracy: " + accuracy + "%";
                double spq = speed;
                spq = Math.Round((spq /= 33), 2);
                lblTopicSpeed.Text = "Speed: " + spq + " SPQ";
                AssignBackColoursTopic(accuracy, spq, total);
            }
            else
            {
                lblTopic.Text = "";
                lblTopicTotal.Text = "";
                lblTopicCorrect.Text = "";
                lblTopicIncorrect.Text = "";
                lblTopicAccuracy.Text = "";
                lblTopicSpeed.Text = "";
                lblTopicSkill.Text = "";
            }
        }

        private double GetTopicSkill(int index)
        {
            int total;
            int correct;
            int incorrect;
            int accuracy;
            int speed;
            correct = (int)dataSetTopics.Tables[0].Rows[index][5];
            incorrect = (int)dataSetTopics.Tables[0].Rows[index][6];
            speed = (int)dataSetTopics.Tables[0].Rows[index][7];
            total = correct + incorrect;
            if (total > 0)
            {
                accuracy = correct * 100 / total;
            }
            else
            {
                accuracy = 0;
            }
            double spq = speed;
            spq = Math.Round((spq /= 33), 2);
            return CalculateSkill(accuracy, spq);
        }

        private void AssignBackColoursOverall(int accuracy, double spq, int total)
        {
            double skill = CalculateSkill(accuracy, spq);
            lblOverallAccuracy.BackColor = GetAcccuracyColour(accuracy);
            lblOverallSpeed.BackColor = GetSpeedColour(spq);
            lblOverallSkill.BackColor = GetSkillColour(skill);
            lblOverallSkill.Text = "Rank: " + GetSkillText(skill);
        }

        private void AssignBackColoursTopic(int accuracy, double spq, int total)
        {
            double skill = CalculateSkill(accuracy, spq);
            lblTopicAccuracy.BackColor = GetAcccuracyColour(accuracy);
            lblTopicSpeed.BackColor = GetSpeedColour(spq);
            lblTopicSkill.BackColor = GetSkillColour(skill);
            lblTopicSkill.Text = "Rank: " + GetSkillText(skill);
        }

        private double CalculateSkill(int accuracy, double spq)
        {
            if (accuracy == 0 || spq == 0)
            {
                return 0;
            }
            double skill;
            if (spq > 3.6)
            {
                skill = (accuracy / spq) * 2;
            }
            else
            {
                skill = (accuracy / 3.6) * 2;
            }
            return Math.Round(skill, 3);
        }

        private Color GetAcccuracyColour(int accuracy)
        {
            if (accuracy < 40)
            {
                return Color.Red;
            }
            else if (accuracy < 58)
            {
                return Color.Tomato;
            }
            else if (accuracy < 67)
            {
                return Color.DarkOrange;
            }
            else if (accuracy < 76)
            {
                return Color.Orange;
            }
            else if (accuracy < 84)
            {
                return Color.Gold;
            }
            else if (accuracy < 92)
            {
                return Color.Yellow;
            }
            else if (accuracy < 99)
            {
                return Color.GreenYellow;
            }
            else
            {
                return Color.LawnGreen;
            }
        }

        private Color GetSpeedColour(double spq)
        {
            if (spq > 15 || spq == 0)
            {
                return Color.Red;
            }
            else if (spq > 12.9)
            {
                return Color.Tomato;
            }
            else if (spq > 10.8)
            {
                return Color.DarkOrange;
            }
            else if (spq > 9)
            {
                return Color.Orange;
            }
            else if (spq > 7.5)
            {
                return Color.Gold;
            }
            else if (spq > 5.4)
            {
                return Color.Yellow;
            }
            else if (spq > 4.5)
            {
                return Color.GreenYellow;
            }
            else
            {
                return Color.LawnGreen;
            }
        }

        private Color GetSkillColour(double skill)
        {
            if (skill < 5.3)
            {
                return Color.Red;
            }
            else if (skill < 9)
            {
                return Color.Tomato;
            }
            else if (skill < 12.7)
            {
                return Color.DarkOrange;
            }
            else if (skill < 16.9)
            {
                return Color.Orange;
            }
            else if (skill < 22.4)
            {
                return Color.Gold;
            }
            else if (skill < 34.1)
            {
                return Color.Yellow;
            }
            else if (skill < 44)
            {
                return Color.GreenYellow;
            }
            else
            {
                return Color.LawnGreen;
            }
        }

        private string GetSkillText(double skill)
        {
            if (skill < 5.3)
            {
                return "Abysmal";
            }
            else if (skill < 9)
            {
                return "Disappointment";
            }
            else if (skill < 12.7)
            {
                return "Shoddy";
            }
            else if (skill < 16.9)
            {
                return "Adept";
            }
            else if (skill < 22.4)
            {
                return "Commendable";
            }
            else if (skill < 34.1)
            {
                return "Skillful";
            }
            else if (skill < 44)
            {
                return "Professional";
            }
            else
            {
                return "Sensational";
            }
        }

        private void FillCbx()
        {
            cbxLength.Items.Clear();
            cbxLength.Items.Add(1);
            cbxLength.Items.Add(3);
            cbxLength.Items.Add(5);
            cbxLength.Items.Add(10);
            cbxLength.Items.Add(20);
            cbxLength.Items.Add(30);
            cbxLength.Items.Add(50);
            cbxLength.Items.Add(100);
            cbxLength.Items.Add(200);
            cbxLength.SelectedIndex = 3;
        }

        private void lbxTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxTopics.SelectedIndex > -1)
            {
                UpdateTopic();
                picImage.Image = Base64StringToImage(dataSetTopics.Tables[0].Rows[GetIndex(lbxTopics.SelectedIndex)][4].ToString());
            }
        }

        private int maxQuestions()
        {
            int max = 0;
            for (int i = 0; i < dataSetTopics.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < dataSetQuestions.Tables[0].Rows.Count; j++)
                {
                    if (dataSetQuestions.Tables[0].Rows[j][1].ToString() == dataSetTopics.Tables[0].Rows[i][1].ToString() && lbxTopics.GetItemCheckState(GetCurrentPosition(dataSetTopics.Tables[0].Rows[i][1].ToString())) == CheckState.Checked)
                    {
                        max++;
                    }
                }
            }
            return max;
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            if ((int)cbxLength.SelectedItem > maxQuestions())
            {
                MessageBox.Show("There are not enough questions to create a test of this length.");
                return;
            }
            DataSet tblQuestions = dataSetQuestions.Clone();
            for (int i = 0; i < dataSetTopics.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < dataSetQuestions.Tables[0].Rows.Count; j++)
                {
                    if (lbxTopics.GetItemCheckState(GetCurrentPosition(dataSetTopics.Tables[0].Rows[i][1].ToString())) == CheckState.Checked && dataSetQuestions.Tables[0].Rows[j][1].ToString() == dataSetTopics.Tables[0].Rows[i][1].ToString())
                    {
                        DataRow row = dataSetQuestions.Tables[0].Rows[j];
                        tblQuestions.Tables[0].ImportRow(row);
                    }
                }
            }
            Test test = new Test(Res, tblQuestions.Tables[0], (int)cbxLength.SelectedItem);
            test.ShowDialog();
            ActiveControl = lbxTopics;
            dataSetTopics = objConnectTopics.GetConnection;
            dataSetQuestions = objConnectQuestions.GetConnection;
            UpdateTopic();
            UpdateOverall();
        }

        private Image Base64StringToImage(string base64String)
        {
            if (base64String == "")
            {
                return null;
            }
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                MemoryStream stream = new MemoryStream(imageBytes, 0, imageBytes.Length);
                stream.Write(imageBytes, 0, imageBytes.Length);
                return Image.FromStream(stream, true);
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            foreach (int i in lbxTopics.CheckedIndices)
            {
                lbxTopics.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lbxTopics.Items.Count; i++)
            {
                lbxTopics.SetItemChecked(i, true);
            }
        }

        private void InitialAdjust()
        {
            foreach (Control cont in this.Controls)
            {
                Shift(cont);
            }
            btnSelectAll.Height += ((Res - 1) * 4);
            btnClearAll.Height += ((Res - 1) * 4);
            btnSelectSubject.Height += ((Res - 1) * 4);
            btnSelectAll.Location = new Point(btnSelectAll.Location.X, (btnSelectAll.Location.Y - ((Res - 1) * 4)));
            btnClearAll.Location = new Point(btnClearAll.Location.X, (btnClearAll.Location.Y - ((Res - 1) * 4)));
            btnSelectSubject.Location = new Point(btnSelectSubject.Location.X, (btnSelectSubject.Location.Y - ((Res - 1) * 4)));
            cbxSubject.Location = new Point(cbxSubject.Location.X, (cbxSubject.Location.Y - ((Res - 1) * 4)));
            if (Res == 2)
            {
                cbxSubject.Location = new Point(cbxSubject.Location.X, (cbxSubject.Location.Y - 5));
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

        private void btnSelectSubject_Click(object sender, EventArgs e)
        {
                for (int i = 0; i < lbxTopics.Items.Count; i++)
                {
                    lbxTopics.SetItemChecked(i, false);
                    if (dataSetTopics.Tables[0].Rows[GetIndex(i)][8].ToString() == cbxSubject.SelectedItem.ToString())
                    {
                        lbxTopics.SetItemChecked(i, true);
                }
            }
        }

        private void TestMenu_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dataSetSubjects.Tables[0].Rows.Count; i++)
            {
                cbxSubject.Items.Add(dataSetSubjects.Tables[0].Rows[i][1].ToString());
                cbxSubject.SelectedIndex = i;
            }
        }

        private int GetIndex(int x)
        {
            for (int i = 0; i < dataSetTopics.Tables[0].Rows.Count; i++)
            {
                if (dataSetTopics.Tables[0].Rows[i][1].ToString() == lbxTopics.Items[x].ToString())
                {
                    return i;
                }
            }
            return -1;
        }

        private int GetCurrentPosition(string topic)
        {
            for (int i = 0; i < lbxTopics.Items.Count; i++)
            {
                if (lbxTopics.Items[i].ToString() == topic)
                {
                    return i;
                }
            }
           return -1;
        }
    }
}
