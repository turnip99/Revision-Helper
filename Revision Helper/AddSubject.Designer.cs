namespace Revision_Helper
{
    partial class AddSubject
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
            this.lbxSubjects = new System.Windows.Forms.ListBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblSubject = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbxSubjects
            // 
            this.lbxSubjects.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxSubjects.FormattingEnabled = true;
            this.lbxSubjects.ItemHeight = 21;
            this.lbxSubjects.Location = new System.Drawing.Point(12, 184);
            this.lbxSubjects.Name = "lbxSubjects";
            this.lbxSubjects.Size = new System.Drawing.Size(491, 235);
            this.lbxSubjects.TabIndex = 0;
            // 
            // txtSubject
            // 
            this.txtSubject.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubject.Location = new System.Drawing.Point(12, 77);
            this.txtSubject.MaxLength = 30;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(491, 29);
            this.txtSubject.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(144, 116);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(238, 55);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add Subject!";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(12, 47);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(89, 27);
            this.lblSubject.TabIndex = 4;
            this.lblSubject.Text = "Subject:";
            // 
            // AddSubject
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 429);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.lbxSubjects);
            this.Name = "AddSubject";
            this.Text = "Add A Subject!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxSubjects;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblSubject;
    }
}