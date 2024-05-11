namespace QuanLyKhachSan
{
    partial class DiemDanhForm
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
            this.ptbCheckOut = new System.Windows.Forms.PictureBox();
            this.ptbCheckIn = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblThongBao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCheckOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCheckIn)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbCheckOut
            // 
            this.ptbCheckOut.Image = global::QuanLyKhachSan.Properties.Resources.checkout;
            this.ptbCheckOut.Location = new System.Drawing.Point(545, 373);
            this.ptbCheckOut.Name = "ptbCheckOut";
            this.ptbCheckOut.Size = new System.Drawing.Size(94, 98);
            this.ptbCheckOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbCheckOut.TabIndex = 1;
            this.ptbCheckOut.TabStop = false;
            // 
            // ptbCheckIn
            // 
            this.ptbCheckIn.Image = global::QuanLyKhachSan.Properties.Resources.checkin;
            this.ptbCheckIn.Location = new System.Drawing.Point(280, 373);
            this.ptbCheckIn.Name = "ptbCheckIn";
            this.ptbCheckIn.Size = new System.Drawing.Size(110, 108);
            this.ptbCheckIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbCheckIn.TabIndex = 0;
            this.ptbCheckIn.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(287, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Check In";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(543, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Check Out";
            // 
            // lblThongBao
            // 
            this.lblThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.Location = new System.Drawing.Point(3, 144);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(950, 23);
            this.lblThongBao.TabIndex = 5;
            this.lblThongBao.Text = "label1";
            this.lblThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DiemDanhForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 628);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ptbCheckOut);
            this.Controls.Add(this.ptbCheckIn);
            this.Name = "DiemDanhForm";
            this.Text = "DiemDanhForm";
            this.Load += new System.EventHandler(this.DiemDanhForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbCheckOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCheckIn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbCheckIn;
        private System.Windows.Forms.PictureBox ptbCheckOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblThongBao;
    }
}