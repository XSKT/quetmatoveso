namespace EncryptXSKT
{
    partial class frmEnCodeFile
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
            this.dlgFile = new System.Windows.Forms.OpenFileDialog();
            this.txtDuongDanFile = new System.Windows.Forms.TextBox();
            this.btnMoFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pbCreateFile = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFile = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtFileMaHoa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblduongdan = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dlgFile
            // 
            this.dlgFile.FileName = "dlgFile";
            // 
            // txtDuongDanFile
            // 
            this.txtDuongDanFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuongDanFile.Location = new System.Drawing.Point(126, 77);
            this.txtDuongDanFile.Name = "txtDuongDanFile";
            this.txtDuongDanFile.ReadOnly = true;
            this.txtDuongDanFile.Size = new System.Drawing.Size(284, 22);
            this.txtDuongDanFile.TabIndex = 1;
            // 
            // btnMoFile
            // 
            this.btnMoFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoFile.Location = new System.Drawing.Point(431, 76);
            this.btnMoFile.Name = "btnMoFile";
            this.btnMoFile.Size = new System.Drawing.Size(87, 23);
            this.btnMoFile.TabIndex = 2;
            this.btnMoFile.Text = "Chọn File";
            this.btnMoFile.UseVisualStyleBackColor = true;
            this.btnMoFile.Click += new System.EventHandler(this.btnMoFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "File Đầu Vào";
            // 
            // pbCreateFile
            // 
            this.pbCreateFile.Location = new System.Drawing.Point(-1, 295);
            this.pbCreateFile.Margin = new System.Windows.Forms.Padding(0);
            this.pbCreateFile.Maximum = 911110;
            this.pbCreateFile.Name = "pbCreateFile";
            this.pbCreateFile.Size = new System.Drawing.Size(559, 23);
            this.pbCreateFile.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(450, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "MÃ HÓA THEO DẠNG CHUẨN XỔ SỐ KIẾN THIẾT";
            // 
            // btnFile
            // 
            this.btnFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile.Location = new System.Drawing.Point(142, 181);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(77, 23);
            this.btnFile.TabIndex = 2;
            this.btnFile.Text = "Tạo File ";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(313, 181);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(66, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Thoát ";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // txtFileMaHoa
            // 
            this.txtFileMaHoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileMaHoa.Location = new System.Drawing.Point(126, 127);
            this.txtFileMaHoa.Name = "txtFileMaHoa";
            this.txtFileMaHoa.Size = new System.Drawing.Size(125, 22);
            this.txtFileMaHoa.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tên File Mã Hóa";
            // 
            // lblduongdan
            // 
            this.lblduongdan.AutoSize = true;
            this.lblduongdan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblduongdan.ForeColor = System.Drawing.Color.Maroon;
            this.lblduongdan.Location = new System.Drawing.Point(123, 108);
            this.lblduongdan.Name = "lblduongdan";
            this.lblduongdan.Size = new System.Drawing.Size(0, 16);
            this.lblduongdan.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(456, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = ">>>>>>";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // frmEnCodeFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(550, 317);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblduongdan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbCreateFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.btnMoFile);
            this.Controls.Add(this.txtFileMaHoa);
            this.Controls.Add(this.txtDuongDanFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmEnCodeFile";
            this.Text = "Mã Hóa File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dlgFile;
        private System.Windows.Forms.TextBox txtDuongDanFile;
        private System.Windows.Forms.Button btnMoFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pbCreateFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtFileMaHoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblduongdan;
        private System.Windows.Forms.Label label4;
    }
}

