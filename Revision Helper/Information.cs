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
    public partial class Information : Form
    {
        int Res;

        DatabaseConnection objConnectTopics;
        DatabaseConnection objConnectQuestions;
        DatabaseConnection objConnectSubjects;
        string conString;

        DataSet dataSetTopics;
        DataSet dataSetQuestions;
        DataSet dataSetSubjects;

        public Information(int res)
        {
            Res = res;
            InitializeComponent();
            InitialAdjust();
            ActiveControl = lbxTopics;
            BackColor = new ColourRandomisor().colour;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            lblTopic.Text = "";
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
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult delete = MessageBox.Show("Are you sure that you wish to delete the topic '" + lbxTopics.SelectedItem.ToString() + "'?", "Delete?", MessageBoxButtons.YesNo);
            if (delete == DialogResult.Yes)
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                for (int i = 0; i < dataSetTopics.Tables[0].Rows.Count; i++)
                {
                    if (dataSetTopics.Tables[0].Rows[i][1].ToString() == lbxTopics.SelectedItem.ToString())
                    {
                        dataSetTopics.Tables[0].Rows[i].Delete();
                    }
                }
                for (int i = 0; i < dataSetQuestions.Tables[0].Rows.Count; i++)
                {
                    if (dataSetQuestions.Tables[0].Rows[i][1].ToString() == lbxTopics.SelectedItem.ToString())
                    {
                        dataSetQuestions.Tables[0].Rows[i].Delete();
                    }
                }
                objConnectTopics.UpdateDatabase(dataSetTopics);
                objConnectQuestions.UpdateDatabase(dataSetQuestions);
                lbxTopics.Items.RemoveAt(lbxTopics.SelectedIndex);
                lblTopic.Text = "";
                txtText1.Clear();
                txtText2.Clear();
                PicImage.Image = null;
            }
        }

        private void lbxTopics_SelectedValueChanged(object sender, EventArgs e)
        {
            SelectedItemChanged();
        }

        private void SelectedItemChanged()
        {
            if (lbxTopics.SelectedIndex > -1)
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                lblTopic.Text = dataSetTopics.Tables[0].Rows[GetCurrentIndex()][1].ToString();
                txtText1.Text = dataSetTopics.Tables[0].Rows[GetCurrentIndex()][2].ToString();
                txtText2.Text = dataSetTopics.Tables[0].Rows[GetCurrentIndex()][3].ToString();
                PicImage.Image = Base64StringToImage(dataSetTopics.Tables[0].Rows[GetCurrentIndex()][4].ToString());
            }
            ActiveControl = lbxTopics;
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddTopic addTopic = new AddTopic(Res, 'e', GetCurrentIndex());
            addTopic.ShowDialog();
            dataSetTopics = objConnectTopics.GetConnection;
            SelectedItemChanged();
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
            btnDelete.Height += ((Res - 1) * 3);
            btnEdit.Height += ((Res - 1) * 3);
            btnDelete.Location = new Point(btnDelete.Location.X, btnDelete.Location.Y-((Res-1)*2));
            btnEdit.Location = new Point(btnEdit.Location.X, btnEdit.Location.Y - ((Res-1) * 2));
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

        private int GetCurrentIndex()
        {
            for (int i = 0; i < dataSetTopics.Tables[0].Rows.Count; i++)
            {
                if (dataSetTopics.Tables[0].Rows[i][1].ToString() == lbxTopics.SelectedItem.ToString())
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
