namespace Revision_Helper
{
    partial class AddTopic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTopic));
            this.txtTopic = new System.Windows.Forms.TextBox();
            this.lblTopic = new System.Windows.Forms.Label();
            this.lblText1 = new System.Windows.Forms.Label();
            this.lblText2 = new System.Windows.Forms.Label();
            this.txtText2 = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.lblSubject = new System.Windows.Forms.Label();
            this.cbxSubject = new System.Windows.Forms.ComboBox();
            this.txtText1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTopic
            // 
            this.txtTopic.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTopic.Location = new System.Drawing.Point(81, 14);
            this.txtTopic.MaxLength = 55;
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.Size = new System.Drawing.Size(1031, 29);
            this.txtTopic.TabIndex = 0;
            // 
            // lblTopic
            // 
            this.lblTopic.AutoSize = true;
            this.lblTopic.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopic.Location = new System.Drawing.Point(14, 17);
            this.lblTopic.Name = "lblTopic";
            this.lblTopic.Size = new System.Drawing.Size(58, 21);
            this.lblTopic.TabIndex = 1;
            this.lblTopic.Text = "Topic:";
            // 
            // lblText1
            // 
            this.lblText1.AutoSize = true;
            this.lblText1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText1.Location = new System.Drawing.Point(14, 68);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(61, 21);
            this.lblText1.TabIndex = 3;
            this.lblText1.Text = "Text 1:";
            // 
            // lblText2
            // 
            this.lblText2.AutoSize = true;
            this.lblText2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText2.Location = new System.Drawing.Point(968, 66);
            this.lblText2.Name = "lblText2";
            this.lblText2.Size = new System.Drawing.Size(61, 21);
            this.lblText2.TabIndex = 7;
            this.lblText2.Text = "Text 2:";
            // 
            // txtText2
            // 
            this.txtText2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText2.Location = new System.Drawing.Point(1035, 65);
            this.txtText2.MaxLength = 1850;
            this.txtText2.Multiline = true;
            this.txtText2.Name = "txtText2";
            this.txtText2.Size = new System.Drawing.Size(860, 307);
            this.txtText2.TabIndex = 6;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(1756, 13);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(45, 45);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 8;
            this.picImage.TabStop = false;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImage.Location = new System.Drawing.Point(1691, 16);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(59, 21);
            this.lblImage.TabIndex = 9;
            this.lblImage.Text = "Image:";
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadImage.Location = new System.Drawing.Point(1808, 12);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(78, 46);
            this.btnUploadImage.TabIndex = 10;
            this.btnUploadImage.Text = "Upload";
            this.btnUploadImage.UseVisualStyleBackColor = true;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(798, 554);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(279, 52);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add Topic!";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlus.Location = new System.Drawing.Point(18, 550);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(42, 42);
            this.btnPlus.TabIndex = 12;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(1131, 17);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(70, 21);
            this.lblSubject.TabIndex = 14;
            this.lblSubject.Text = "Subject:";
            // 
            // cbxSubject
            // 
            this.cbxSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSubject.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSubject.FormattingEnabled = true;
            this.cbxSubject.Location = new System.Drawing.Point(1211, 14);
            this.cbxSubject.Name = "cbxSubject";
            this.cbxSubject.Size = new System.Drawing.Size(451, 29);
            this.cbxSubject.TabIndex = 15;
            // 
            // txtText1
            // 
            this.txtText1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText1.Location = new System.Drawing.Point(81, 67);
            this.txtText1.MaxLength = 1850;
            this.txtText1.Multiline = true;
            this.txtText1.Name = "txtText1";
            this.txtText1.Size = new System.Drawing.Size(860, 305);
            this.txtText1.TabIndex = 2;
            // 
            // AddTopic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1908, 618);
            this.Controls.Add(this.cbxSubject);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUploadImage);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.lblText2);
            this.Controls.Add(this.txtText2);
            this.Controls.Add(this.lblText1);
            this.Controls.Add(this.txtText1);
            this.Controls.Add(this.lblTopic);
            this.Controls.Add(this.txtTopic);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddTopic";
            this.Text = "Add A Topic!";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AddTopic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTopic;
        private System.Windows.Forms.Label lblTopic;
        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.Label lblText2;
        private System.Windows.Forms.TextBox txtText2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.ComboBox cbxSubject;
        private System.Windows.Forms.TextBox txtText1;
    }
}