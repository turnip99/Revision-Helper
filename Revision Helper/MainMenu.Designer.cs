namespace Revision_Helper
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.radBig = new System.Windows.Forms.RadioButton();
            this.radMedium = new System.Windows.Forms.RadioButton();
            this.radSmall = new System.Windows.Forms.RadioButton();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.PaleGreen;
            this.btnInfo.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfo.ForeColor = System.Drawing.Color.DarkRed;
            this.btnInfo.Location = new System.Drawing.Point(33, 271);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(400, 100);
            this.btnInfo.TabIndex = 3;
            this.btnInfo.Text = "Information!";
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.PaleGreen;
            this.btnTest.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.ForeColor = System.Drawing.Color.DarkRed;
            this.btnTest.Location = new System.Drawing.Point(33, 398);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(400, 100);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "Test!";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.DarkRed;
            this.btnAdd.Location = new System.Drawing.Point(33, 144);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(400, 100);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add Topic!";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // radBig
            // 
            this.radBig.AutoSize = true;
            this.radBig.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBig.ForeColor = System.Drawing.Color.PaleGreen;
            this.radBig.Location = new System.Drawing.Point(337, 506);
            this.radBig.Name = "radBig";
            this.radBig.Size = new System.Drawing.Size(84, 19);
            this.radBig.TabIndex = 7;
            this.radBig.TabStop = true;
            this.radBig.Text = "1920 x 1080";
            this.radBig.UseVisualStyleBackColor = true;
            // 
            // radMedium
            // 
            this.radMedium.AutoSize = true;
            this.radMedium.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMedium.ForeColor = System.Drawing.Color.PaleGreen;
            this.radMedium.Location = new System.Drawing.Point(185, 506);
            this.radMedium.Name = "radMedium";
            this.radMedium.Size = new System.Drawing.Size(78, 19);
            this.radMedium.TabIndex = 6;
            this.radMedium.TabStop = true;
            this.radMedium.Text = "1600 x 900";
            this.radMedium.UseVisualStyleBackColor = true;
            // 
            // radSmall
            // 
            this.radSmall.AutoSize = true;
            this.radSmall.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSmall.ForeColor = System.Drawing.Color.PaleGreen;
            this.radSmall.Location = new System.Drawing.Point(33, 506);
            this.radSmall.Name = "radSmall";
            this.radSmall.Size = new System.Drawing.Size(78, 19);
            this.radSmall.TabIndex = 5;
            this.radSmall.TabStop = true;
            this.radSmall.Text = "1366 x 768";
            this.radSmall.UseVisualStyleBackColor = true;
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAddSubject.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSubject.ForeColor = System.Drawing.Color.DarkRed;
            this.btnAddSubject.Location = new System.Drawing.Point(33, 17);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(400, 100);
            this.btnAddSubject.TabIndex = 1;
            this.btnAddSubject.Text = "Add Subject!";
            this.btnAddSubject.UseVisualStyleBackColor = false;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(462, 532);
            this.Controls.Add(this.btnAddSubject);
            this.Controls.Add(this.radSmall);
            this.Controls.Add(this.radMedium);
            this.Controls.Add(this.radBig);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.Text = "Revision Helper!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RadioButton radBig;
        private System.Windows.Forms.RadioButton radMedium;
        private System.Windows.Forms.RadioButton radSmall;
        private System.Windows.Forms.Button btnAddSubject;
    }
}

