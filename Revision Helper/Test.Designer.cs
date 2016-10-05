namespace Revision_Helper
{
    partial class Test
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Test));
            this.tmrSpeed = new System.Windows.Forms.Timer(this.components);
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnA1 = new System.Windows.Forms.Button();
            this.btnA3 = new System.Windows.Forms.Button();
            this.btnA4 = new System.Windows.Forms.Button();
            this.btnA2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tmrSpeed
            // 
            this.tmrSpeed.Interval = 20;
            this.tmrSpeed.Tick += new System.EventHandler(this.tmrSpeed_Tick);
            // 
            // txtQuestion
            // 
            this.txtQuestion.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtQuestion.Enabled = false;
            this.txtQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuestion.Location = new System.Drawing.Point(12, 19);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.ReadOnly = true;
            this.txtQuestion.Size = new System.Drawing.Size(1327, 281);
            this.txtQuestion.TabIndex = 0;
            this.txtQuestion.Text = "txtQuestion";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Times New Roman", 114.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(1345, 60);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(577, 172);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "185/200";
            // 
            // btnA1
            // 
            this.btnA1.BackColor = System.Drawing.Color.Tomato;
            this.btnA1.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnA1.Location = new System.Drawing.Point(10, 303);
            this.btnA1.Name = "btnA1";
            this.btnA1.Size = new System.Drawing.Size(952, 355);
            this.btnA1.TabIndex = 2;
            this.btnA1.Text = "btnA1";
            this.btnA1.UseVisualStyleBackColor = false;
            this.btnA1.Click += new System.EventHandler(this.btn_Selected);
            // 
            // btnA3
            // 
            this.btnA3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnA3.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnA3.Location = new System.Drawing.Point(10, 657);
            this.btnA3.Name = "btnA3";
            this.btnA3.Size = new System.Drawing.Size(952, 355);
            this.btnA3.TabIndex = 4;
            this.btnA3.Text = "btnA3";
            this.btnA3.UseVisualStyleBackColor = false;
            this.btnA3.Click += new System.EventHandler(this.btn_Selected);
            // 
            // btnA4
            // 
            this.btnA4.BackColor = System.Drawing.Color.MediumPurple;
            this.btnA4.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnA4.Location = new System.Drawing.Point(961, 657);
            this.btnA4.Name = "btnA4";
            this.btnA4.Size = new System.Drawing.Size(952, 355);
            this.btnA4.TabIndex = 5;
            this.btnA4.Text = "btnA4";
            this.btnA4.UseVisualStyleBackColor = false;
            this.btnA4.Click += new System.EventHandler(this.btn_Selected);
            // 
            // btnA2
            // 
            this.btnA2.BackColor = System.Drawing.Color.Khaki;
            this.btnA2.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnA2.Location = new System.Drawing.Point(961, 303);
            this.btnA2.Name = "btnA2";
            this.btnA2.Size = new System.Drawing.Size(952, 355);
            this.btnA2.TabIndex = 3;
            this.btnA2.Text = "btnA2";
            this.btnA2.UseVisualStyleBackColor = false;
            this.btnA2.Click += new System.EventHandler(this.btn_Selected);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1908, 1045);
            this.Controls.Add(this.btnA4);
            this.Controls.Add(this.btnA2);
            this.Controls.Add(this.btnA3);
            this.Controls.Add(this.btnA1);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.lblCount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Test";
            this.Text = "Test";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Test_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrSpeed;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnA1;
        private System.Windows.Forms.Button btnA3;
        private System.Windows.Forms.Button btnA4;
        private System.Windows.Forms.Button btnA2;
    }
}