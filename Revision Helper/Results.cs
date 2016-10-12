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
            lblSpeed.Text = "Speed: " + spq + " S/Q";
            AssignBackColours(accuracy, spq, total);
        }

        private void AssignBackColours(int accuracy, double spq, int total)
        {
            double skill = CalculateSkill(accuracy, spq);
            lblAccuracy.BackColor = GetAcccuracyColour(accuracy);
            lblSpeed.BackColor = GetSpeedColour(spq);
            lblSkill.BackColor = GetSkillColour(skill);
            lblSkill.Text = "Rank: " + GetSkillText(skill);
        }

        private double CalculateSkill(int accuracy, double spq)
        {
            if (accuracy == 0 || spq == 0)
            {
                return 0;
            }
            double skill;
            if (spq < 5)
            {
                skill = (accuracy / 5) * 2;
            }
            else if (spq > 18)
            {
                skill = (accuracy / 18) * 2;
            }
            else
            {
                skill = (accuracy / spq) * 2;
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
            else if (accuracy < 90)
            {
                return Color.Yellow;
            }
            else if (accuracy < 95)
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
            else if (spq > 13.3)
            {
                return Color.Tomato;
            }
            else if (spq > 11.6)
            {
                return Color.DarkOrange;
            }
            else if (spq > 10.2)
            {
                return Color.Orange;
            }
            else if (spq > 8.9)
            {
                return Color.Gold;
            }
            else if (spq > 7.8)
            {
                return Color.Yellow;
            }
            else if (spq > 5.9)
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
            else if (skill < 8.7)
            {
                return Color.Tomato;
            }
            else if (skill < 11.6)
            {
                return Color.DarkOrange;
            }
            else if (skill < 14.9)
            {
                return Color.Orange;
            }
            else if (skill < 18.9)
            {
                return Color.Gold;
            }
            else if (skill < 23.1)
            {
                return Color.Yellow;
            }
            else if (skill < 32.2)
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
            else if (skill < 8.7)
            {
                return "Disappointment";
            }
            else if (skill < 11.6)
            {
                return "Shoddy";
            }
            else if (skill < 14.9)
            {
                return "Adept";
            }
            else if (skill < 18.9)
            {
                return "Commendable";
            }
            else if (skill < 23.1)
            {
                return "Skillful";
            }
            else if (skill < 32.2)
            {
                return "Professional";
            }
            else
            {
                return "Sensational";
            }
        }
    }
}
