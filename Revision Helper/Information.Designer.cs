namespace Revision_Helper
{
    partial class Information
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Information));
            this.lbxTopics = new System.Windows.Forms.ListBox();
            this.lblTopic = new System.Windows.Forms.Label();
            this.txtText1 = new System.Windows.Forms.TextBox();
            this.txtText2 = new System.Windows.Forms.TextBox();
            this.PicImage = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxTopics
            // 
            this.lbxTopics.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxTopics.FormattingEnabled = true;
            this.lbxTopics.ItemHeight = 19;
            this.lbxTopics.Location = new System.Drawing.Point(12, 12);
            this.lbxTopics.Name = "lbxTopics";
            this.lbxTopics.Size = new System.Drawing.Size(637, 992);
            this.lbxTopics.TabIndex = 2;
            this.lbxTopics.SelectedValueChanged += new System.EventHandler(this.lbxTopics_SelectedValueChanged);
            // 
            // lblTopic
            // 
            this.lblTopic.AutoSize = true;
            this.lblTopic.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopic.Location = new System.Drawing.Point(655, 9);
            this.lblTopic.Name = "lblTopic";
            this.lblTopic.Size = new System.Drawing.Size(75, 22);
            this.lblTopic.TabIndex = 3;
            this.lblTopic.Text = "lblTopic";
            // 
            // txtText1
            // 
            this.txtText1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText1.Location = new System.Drawing.Point(659, 38);
            this.txtText1.Multiline = true;
            this.txtText1.Name = "txtText1";
            this.txtText1.ReadOnly = true;
            this.txtText1.Size = new System.Drawing.Size(704, 574);
            this.txtText1.TabIndex = 4;
            // 
            // txtText2
            // 
            this.txtText2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText2.Location = new System.Drawing.Point(659, 618);
            this.txtText2.Multiline = true;
            this.txtText2.Name = "txtText2";
            this.txtText2.ReadOnly = true;
            this.txtText2.Size = new System.Drawing.Size(1237, 388);
            this.txtText2.TabIndex = 5;
            // 
            // PicImage
            // 
            this.PicImage.Location = new System.Drawing.Point(1369, 38);
            this.PicImage.Name = "PicImage";
            this.PicImage.Size = new System.Drawing.Size(527, 574);
            this.PicImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicImage.TabIndex = 6;
            this.PicImage.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Firebrick;
            this.btnDelete.Location = new System.Drawing.Point(1750, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(145, 24);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "DELETE TOPIC";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.Teal;
            this.btnEdit.Location = new System.Drawing.Point(1600, 9);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(145, 24);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "EDIT TOPIC";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1908, 1021);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.PicImage);
            this.Controls.Add(this.txtText2);
            this.Controls.Add(this.txtText1);
            this.Controls.Add(this.lblTopic);
            this.Controls.Add(this.lbxTopics);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Information";
            this.Text = "Information!";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxTopics;
        private System.Windows.Forms.Label lblTopic;
        private System.Windows.Forms.TextBox txtText1;
        private System.Windows.Forms.TextBox txtText2;
        private System.Windows.Forms.PictureBox PicImage;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
    }
}