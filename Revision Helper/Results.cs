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
            AssignBackColours(accuracy, spq, total);
        }

        private void AssignBackColours(int accuracy, double spq, int total)
        {
            double skill = CalculateSkill(accuracy, spq, total);
            lblAccuracy.BackColor = GetAcccuracyColour(accuracy);
            lblSpeed.BackColor = GetSpeedColour(spq);
            lblSkill.BackColor = GetSkillColour(skill);
            lblSkill.Text = "Rank: " + GetSkillText(skill);
        }

        private double CalculateSkill(int accuracy, double spq, int total)
        {
            if (accuracy == 0 || spq == 0)
            {
                return 0;
            }
            double skill;
            if (spq > 1.2)
            {
                skill = (accuracy / spq) * 2;
            }
            else
            {
                skill = (accuracy / 1.2) * 2;
            }

            skill -= 10;
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
            if (spq > 5 || spq == 0)
            {
                return Color.Red;
            }
            else if (spq > 4.3)
            {
                return Color.Tomato;
            }
            else if (spq > 3.6)
            {
                return Color.DarkOrange;
            }
            else if (spq > 3)
            {
                return Color.Orange;
            }
            else if (spq > 2.5)
            {
                return Color.Gold;
            }
            else if (spq > 1.9)
            {
                return Color.Yellow;
            }
            else if (spq > 1.5)
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
            if (skill < 16)
            {
                return Color.Red;
            }
            else if (skill < 27)
            {
                return Color.Tomato;
            }
            else if (skill < 37)
            {
                return Color.DarkOrange;
            }
            else if (skill < 51)
            {
                return Color.Orange;
            }
            else if (skill < 67)
            {
                return Color.Gold;
            }
            else if (skill < 97)
            {
                return Color.Yellow;
            }
            else if (skill < 132)
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
            if (skill < 16)
            {
                return "Abysmal";
            }
            else if (skill < 27)
            {
                return "Disappointment";
            }
            else if (skill < 37)
            {
                return "Shoddy";
            }
            else if (skill < 51)
            {
                return "Adept";
            }
            else if (skill < 67)
            {
                return "Commendable";
            }
            else if (skill < 97)
            {
                return "Skillful";
            }
            else if (skill < 132)
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
