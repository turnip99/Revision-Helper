using Revision_Helper.Properties;
using System;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Revision_Helper
{
    public partial class AddTopic : Form
    {
        int Res;

        DatabaseConnection objConnectTopics;
        DatabaseConnection objConnectQuestions;
        DatabaseConnection objConnectSubjects;
        string conString;

        DataSet dataSetTopics;
        DataSet dataSetQuestions;
        DataSet dataSetSubjects;

        List<Question> questionsList = new List<Question>();
        int questionSpawnPosition = 1;

        char Mode;
        int DataIndex;
        int questionCount;

        public AddTopic(int res, char mode, int dataIndex)
        {
            Res = res;
            Mode = mode;
            DataIndex = dataIndex;
            InitializeComponent();
            InitialAdjust();
            BackColor = new ColourRandomisor().colour;
            ActiveControl = txtTopic;
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
            questionsList.Add(new Question(Res, 250 + (questionSpawnPosition * 160), this));
            questionsList[0].delete.Visible = false;
            if (mode == 'e')
            {
                txtTopic.Enabled = false;
                btnAdd.Text = "Update Topic!";
                txtTopic.Text = dataSetTopics.Tables[0].Rows[dataIndex][1].ToString();
                txtText1.Text = dataSetTopics.Tables[0].Rows[dataIndex][2].ToString();
                txtText2.Text = dataSetTopics.Tables[0].Rows[dataIndex][3].ToString();
                picImage.Image = Base64StringToImage(dataSetTopics.Tables[0].Rows[dataIndex][4].ToString());
                bool found = false;
                int x = 0;
                questionCount = 0;
                for (int i = 0; i < dataSetQuestions.Tables[0].Rows.Count; i++)
                {
                    if (dataSetQuestions.Tables[0].Rows[i][1].ToString() == dataSetTopics.Tables[0].Rows[dataIndex][1].ToString())
                    {
                        questionCount++;
                        if (questionCount > 1)
                        {
                            AddQuestion();
                        }
                        questionsList[questionsList.Count - 1].text[0].Text = dataSetQuestions.Tables[0].Rows[i][2].ToString();
                        questionsList[questionsList.Count - 1].text[1].Text = dataSetQuestions.Tables[0].Rows[i][3].ToString();
                        questionsList[questionsList.Count - 1].text[2].Text = dataSetQuestions.Tables[0].Rows[i][4].ToString();
                        questionsList[questionsList.Count - 1].text[3].Text = dataSetQuestions.Tables[0].Rows[i][5].ToString();
                        questionsList[questionsList.Count - 1].text[4].Text = dataSetQuestions.Tables[0].Rows[i][6].ToString();
                    }
                }
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                Byte[] byteData = new Byte[fs.Length];
                fs.Read(byteData, 0, byteData.Length);
                fs.Close();
                MemoryStream stmData = new MemoryStream(byteData);
                picImage.Image = Image.FromStream(stmData);
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            AddQuestion();
        }

        private void AddQuestion()
        {
            questionSpawnPosition++;
            questionsList.Add(new Question(Res, 250 + (questionSpawnPosition * 160), this));
            switch (Res)
            {
                case 1: btnPlus.Location = new Point(btnPlus.Location.X, btnPlus.Location.Y + 160);
                    btnAdd.Location = new Point(btnAdd.Location.X, btnAdd.Location.Y + 160); Height += 160; break;
                case 2:
                    btnPlus.Location = new Point(btnPlus.Location.X, btnPlus.Location.Y + 133);
                    btnAdd.Location = new Point(btnAdd.Location.X, btnAdd.Location.Y + 133); Height += 133; break;
                case 3:
                    btnPlus.Location = new Point(btnPlus.Location.X, btnPlus.Location.Y + 107);
                    btnAdd.Location = new Point(btnAdd.Location.X, btnAdd.Location.Y + 107); Height += 107; break;
                default: break;
            }
            if (questionSpawnPosition == 4)
            {
                btnPlus.Dispose();
            }
            questionsList[0].delete.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {           
            if (txtTopic.Text == "")
            {
                MessageBox.Show("You must enter a topic name.");
                return;
            }
            for (int i = 0; i < questionSpawnPosition; i++)
            {
                if (!(questionsList[i].text[0].Text != "" && questionsList[i].text[1].Text != "" && (questionsList[i].text[2].Text != "" || questionsList[i].text[3].Text != "" || questionsList[i].text[4].Text != "")) && (questionsList[i].delete.Text == "Keep"))
                {
                    MessageBox.Show("One of your questions is invalid.");
                    return;
                }
            }
            bool allDelete = true;
            foreach (Question item in questionsList)
            {
                if (item.delete.Text == "Keep")
                {
                    allDelete = false;
                }
            }
            if (allDelete)
            {
                MessageBox.Show("You cannot delete all questions.");
                return;
            }
            if (Mode == 'a')
            {
                for (int i = 0; i < dataSetTopics.Tables[0].Rows.Count; i++)
                {
                    if (dataSetTopics.Tables[0].Rows[i][1].ToString() == txtTopic.Text)
                    {
                        MessageBox.Show("This topic name has already been taken.");
                        return;
                    }
                }
                DataRow topicRow = dataSetTopics.Tables[0].NewRow();
                topicRow[1] = txtTopic.Text;
                topicRow[2] = txtText1.Text;
                topicRow[3] = txtText2.Text;
                if (picImage.Image != null)
                {
                    topicRow[4] = ImageToBase64String(picImage.Image);
                }
                topicRow[5] = 0;
                topicRow[6] = 0;
                topicRow[7] = 0;
                topicRow[8] = cbxSubject.SelectedItem.ToString();
                dataSetTopics.Tables[0].Rows.Add(topicRow);
                try
                {
                    objConnectTopics.UpdateDatabase(dataSetTopics);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                    return;
                }
                for (int i = 0; i < questionSpawnPosition; i++)
                {
                    if (questionsList[i].delete.Text == "Keep")
                    {
                        DataRow questionRow = dataSetQuestions.Tables[0].NewRow();
                        questionRow[1] = txtTopic.Text;
                        questionRow[2] = questionsList[i].text[0].Text;
                        questionRow[3] = questionsList[i].text[1].Text;
                        questionRow[4] = questionsList[i].text[2].Text;
                        questionRow[5] = questionsList[i].text[3].Text;
                        questionRow[6] = questionsList[i].text[4].Text;
                        dataSetQuestions.Tables[0].Rows.Add(questionRow);
                    }
                }
                try
                {
                    objConnectQuestions.UpdateDatabase(dataSetQuestions);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                    return;
                }
                MessageBox.Show("New topic successfully added!");
            }
            else
            {
                dataSetTopics.Tables[0].Rows[DataIndex][2] = txtText1.Text;
                dataSetTopics.Tables[0].Rows[DataIndex][3] = txtText2.Text;
                if (picImage.Image != null)
                {
                    dataSetTopics.Tables[0].Rows[DataIndex][4] = ImageToBase64String(picImage.Image);
                }
                dataSetTopics.Tables[0].Rows[DataIndex][8] = cbxSubject.SelectedItem.ToString();
                try
                {
                    objConnectTopics.UpdateDatabase(dataSetTopics);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                    return;
                }
                int x = 0;
                int[] toBeDeleted = new int[4];
                for (int i = 0; i < dataSetQuestions.Tables[0].Rows.Count; i++)
                {
                    if (dataSetQuestions.Tables[0].Rows[i][1].ToString() == dataSetTopics.Tables[0].Rows[DataIndex][1].ToString())
                    {
                        if (questionsList[x].delete.Text == "Keep")
                        {
                            dataSetQuestions.Tables[0].Rows[i][2] = questionsList[x].text[0].Text;
                            dataSetQuestions.Tables[0].Rows[i][3] = questionsList[x].text[1].Text;
                            dataSetQuestions.Tables[0].Rows[i][4] = questionsList[x].text[2].Text;
                            dataSetQuestions.Tables[0].Rows[i][5] = questionsList[x].text[3].Text;
                            dataSetQuestions.Tables[0].Rows[i][6] = questionsList[x].text[4].Text;
                        }
                        else
                        {
                            toBeDeleted[x] = 1;
                        }
                        x++;
                    }
                }
                for (int i = questionCount; i < questionSpawnPosition; i++)
                {
                    if (questionsList[i].delete.Text == "Keep")
                    {
                        DataRow questionRow = dataSetQuestions.Tables[0].NewRow();
                        questionRow[1] = txtTopic.Text;
                        questionRow[2] = questionsList[i].text[0].Text;
                        questionRow[3] = questionsList[i].text[1].Text;
                        questionRow[4] = questionsList[i].text[2].Text;
                        questionRow[5] = questionsList[i].text[3].Text;
                        questionRow[6] = questionsList[i].text[4].Text;
                        dataSetQuestions.Tables[0].Rows.Add(questionRow);
                    }
                }
                int howManySeen = 0;
                for (int i = 0; i < dataSetQuestions.Tables[0].Rows.Count; i++)
                {
                    if (howManySeen > questionSpawnPosition)
                    {
                        break;
                    }
                    if (dataSetTopics.Tables[0].Rows[DataIndex][1].ToString() == dataSetQuestions.Tables[0].Rows[i][1].ToString())
                    {
                        if (toBeDeleted[howManySeen] == 1)
                        {
                            dataSetQuestions.Tables[0].Rows[i].Delete();
                        }
                        howManySeen++;
                    }
                }
                try
                {
                    objConnectQuestions.UpdateDatabase(dataSetQuestions);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                    return;
                }
                MessageBox.Show("Topic successfully updated!");
            }
            Close();
        }

        private string ImageToBase64String(Image image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, image.RawFormat);
                return Convert.ToBase64String(stream.ToArray());
            }
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

        private void InitialAdjust()
        {
            foreach (Control cont in this.Controls)
            {
                Shift(cont);
            }
            btnAdd.Height += ((Res - 1) * 3);
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

        private void AddTopic_Load(object sender, EventArgs e)
        {
            if (dataSetSubjects.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("You must add a subject before you can add a topic.");
                Close();
            }
            for (int i = 0; i < dataSetSubjects.Tables[0].Rows.Count; i++)
            {
                cbxSubject.Items.Add(dataSetSubjects.Tables[0].Rows[i][1].ToString());
                cbxSubject.SelectedIndex = i;
            }
            if (Mode == 'e')
            {
                cbxSubject.SelectedIndex = cbxSubject.FindStringExact(dataSetTopics.Tables[0].Rows[DataIndex][8].ToString());
                cbxSubject.Enabled = false;
            }
        }
    }
}
