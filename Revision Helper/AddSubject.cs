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
    public partial class AddSubject : Form
    {
        DatabaseConnection objConnectSubjects;
        string conString;
        DataSet dataSetSubjects;
        public AddSubject()
        {
            InitializeComponent();
            BackColor = new ColourRandomisor().colour;
            ActiveControl = txtSubject;
            try
            {
                objConnectSubjects = new DatabaseConnection();
                conString = Settings.Default.RevisionDatabaseConnectionString;
                objConnectSubjects.connectionString = conString;

                objConnectSubjects.SQL = Settings.Default.SqlSelectFromtblSubjects;
                UpdateList();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void UpdateList()
        {
            dataSetSubjects = objConnectSubjects.GetConnection;
            lbxSubjects.Items.Clear();
            for (int i = 0; i < dataSetSubjects.Tables[0].Rows.Count; i++)
            {
                lbxSubjects.Items.Add(dataSetSubjects.Tables[0].Rows[i][1]);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtSubject.Text == "")
            {
                MessageBox.Show("You must enter a subject name.");
                return;
            }
            DataRow row = dataSetSubjects.Tables[0].NewRow();
            row[1] = txtSubject.Text;
            dataSetSubjects.Tables[0].Rows.Add(row);
            UpdateDatabase();
            UpdateList();
            MessageBox.Show("'" + txtSubject.Text + "' Successfully Added!");
            txtSubject.Clear();
            ActiveControl = txtSubject;
        }

        private void UpdateDatabase()
        {
                try
                {
                objConnectSubjects.UpdateDatabase(dataSetSubjects);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                    return;
                }
        }
    }
}
