namespace QuanLyKhachSan
{
    partial class ThanhToanForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxNganHang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxLoaiQR = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTenTaiKhoan = new System.Windows.Forms.Label();
            this.lblSoTaiKhoan = new System.Windows.Forms.Label();
            this.lblNganHang = new System.Windows.Forms.Label();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.btnTaoQR = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(382, 97);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 350);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(459, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã QR Chuyển Khoản";
            // 
            // cbxNganHang
            // 
            this.cbxNganHang.FormattingEnabled = true;
            this.cbxNganHang.Location = new System.Drawing.Point(58, 39);
            this.cbxNganHang.Name = "cbxNganHang";
            this.cbxNganHang.Size = new System.Drawing.Size(121, 28);
            this.cbxNganHang.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chọn ngân hàng chuyển khoản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại QR";
            // 
            // cbxLoaiQR
            // 
            this.cbxLoaiQR.FormattingEnabled = true;
            this.cbxLoaiQR.Items.AddRange(new object[] {
            "compact",
            "compact2",
            "qr_only",
            "print"});
            this.cbxLoaiQR.Location = new System.Drawing.Point(58, 130);
            this.cbxLoaiQR.Name = "cbxLoaiQR";
            this.cbxLoaiQR.Size = new System.Drawing.Size(121, 28);
            this.cbxLoaiQR.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tên tài khoản: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Số tài khoản:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblNoiDung);
            this.panel1.Controls.Add(this.lblSoTien);
            this.panel1.Controls.Add(this.lblNganHang);
            this.panel1.Controls.Add(this.lblSoTaiKhoan);
            this.panel1.Controls.Add(this.lblTenTaiKhoan);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(342, 473);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 193);
            this.panel1.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Ngân hàng:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "Số tiền:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Nội dung:";
            // 
            // lblTenTaiKhoan
            // 
            this.lblTenTaiKhoan.AutoSize = true;
            this.lblTenTaiKhoan.Location = new System.Drawing.Point(137, 9);
            this.lblTenTaiKhoan.Name = "lblTenTaiKhoan";
            this.lblTenTaiKhoan.Size = new System.Drawing.Size(21, 20);
            this.lblTenTaiKhoan.TabIndex = 5;
            this.lblTenTaiKhoan.Text = "...";
            // 
            // lblSoTaiKhoan
            // 
            this.lblSoTaiKhoan.AutoSize = true;
            this.lblSoTaiKhoan.Location = new System.Drawing.Point(137, 46);
            this.lblSoTaiKhoan.Name = "lblSoTaiKhoan";
            this.lblSoTaiKhoan.Size = new System.Drawing.Size(21, 20);
            this.lblSoTaiKhoan.TabIndex = 6;
            this.lblSoTaiKhoan.Text = "...";
            // 
            // lblNganHang
            // 
            this.lblNganHang.AutoSize = true;
            this.lblNganHang.Location = new System.Drawing.Point(137, 84);
            this.lblNganHang.Name = "lblNganHang";
            this.lblNganHang.Size = new System.Drawing.Size(21, 20);
            this.lblNganHang.TabIndex = 7;
            this.lblNganHang.Text = "...";
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Location = new System.Drawing.Point(137, 121);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(21, 20);
            this.lblSoTien.TabIndex = 8;
            this.lblSoTien.Text = "...";
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Location = new System.Drawing.Point(137, 157);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(21, 20);
            this.lblNoiDung.TabIndex = 9;
            this.lblNoiDung.Text = "...";
            // 
            // btnTaoQR
            // 
            this.btnTaoQR.Location = new System.Drawing.Point(48, 196);
            this.btnTaoQR.Name = "btnTaoQR";
            this.btnTaoQR.Size = new System.Drawing.Size(142, 32);
            this.btnTaoQR.TabIndex = 7;
            this.btnTaoQR.Text = "Tạo mã QR";
            this.btnTaoQR.UseVisualStyleBackColor = true;
            this.btnTaoQR.Click += new System.EventHandler(this.btnTaoQR_Click);
            // 
            // ThanhToanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 712);
            this.Controls.Add(this.btnTaoQR);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbxLoaiQR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxNganHang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ThanhToanForm";
            this.Text = "ThanhToanForm";
            this.Load += new System.EventHandler(this.ThanhToanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxNganHang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxLoaiQR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.Label lblNganHang;
        private System.Windows.Forms.Label lblSoTaiKhoan;
        private System.Windows.Forms.Label lblTenTaiKhoan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTaoQR;
    }
}