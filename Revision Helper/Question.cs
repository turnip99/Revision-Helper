using System;
using System.Windows.Forms;
using System.Drawing;

namespace Revision_Helper
{
    class Question
    {
        public TextBox[] text = new TextBox[5];
        public Label[] label = new Label[5];
        public Button delete = new Button();
        public Question(int Res, int spawnPosition, AddTopic form)
        {
            for (int i = 0; i < 5; i++)
            {
                text[i] = new TextBox();
                label[i] = new Label();
                form.Controls.Add(text[i]);
                form.Controls.Add(label[i]);
                text[i].Font = new Font("Times New Roman", 11);
                label[i].Font = new Font("Times New Roman", 11);
                delete.Font = new Font("Times New Roman", 11);
                text[i].Size = new Size(800, 40);
                text[i].MaxLength = 75;
            }
            form.Controls.Add(delete);
            delete.Click += new EventHandler(delete_Changed);
            label[0].Text = "Question:";
            label[1].Text = "Answer:";
            label[2].Text = "Incorrect:";
            label[3].Text = "Incorrect:";
            label[4].Text = "Incorrect:";
            delete.Text = "Keep";
            text[0].Size = new Size(1700, 40);
            delete.Size = new Size(100, 40);
            text[0].MaxLength = 150;
            label[0].Location = new Point(15, spawnPosition);
            text[0].Location = new Point(95, spawnPosition);
            label[1].Location = new Point(15, spawnPosition + 50);
            label[2].Location = new Point(915, spawnPosition + 50);
            label[3].Location = new Point(15, spawnPosition + 100);
            label[4].Location = new Point(915, spawnPosition + 100);
            text[1].Location = new Point(95, spawnPosition + 50);
            text[2].Location = new Point(995, spawnPosition + 50);
            text[3].Location = new Point(95, spawnPosition + 100);
            text[4].Location = new Point(995, spawnPosition + 100);
            delete.Location = new Point(1800, spawnPosition);
            delete.BackColor = Color.Green;
            foreach (Label cont in label)
            {
                    Shift(Res, cont);
            }
            foreach (TextBox cont in text)
            {
                    Shift(Res, cont);
            }
                Shift(Res, delete);
        }
        private void delete_Changed(object sender, EventArgs e)
        {
            if (delete.Text == "Delete")
            {
                delete.BackColor = Color.Green;
                delete.Text = "Keep";
            }
            else
            {
                delete.BackColor = Color.DarkOrange;
                delete.Text = "Delete";
            }
        }

        private void Shift(int Res, Control cont)
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
