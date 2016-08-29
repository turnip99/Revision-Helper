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
    public partial class Results : Form
    {
        public Results(int correct, int incorrect, int speed)
        {
            InitializeComponent();
            int total;
            int accuracy;
            int skill;
            total = correct + incorrect;
            accuracy = correct * 100 / total;
            lblTotal.Text = "Test Length: " + total;
            lblCorrect.Text = "Correct: " + correct;
            lblIncorrect.Text = "Incorrect: " + incorrect;
            lblAccuracy.Text = "Accuracy: " + accuracy + "%";
            double spq = speed;
            spq = Math.Round((spq /= 33), 2);
            lblSpeed.Text = "Speed: " + spq + " SPQ";
        }
    }
}
