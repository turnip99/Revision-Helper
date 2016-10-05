using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Revision_Helper
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            radBig.Checked = true;
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            AddSubject addSubject = new AddSubject();
            addSubject.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTopic addTopic = new AddTopic(GetRes(), 'a', 0);
            addTopic.ShowDialog();
        }
   

    private void btnInfo_Click(object sender, EventArgs e)
    {
        Information information = new Information(GetRes());
        information.ShowDialog();
    }

    private void btnTest_Click(object sender, EventArgs e)
    {
        TestMenu testMenu = new TestMenu(GetRes());
        testMenu.ShowDialog();
    }

    private int GetRes()
    {
        if (radBig.Checked)
        {
            return 1;
        }
        else if (radMedium.Checked)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
}
}
