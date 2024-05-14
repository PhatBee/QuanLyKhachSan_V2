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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxNganHang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxLoaiQR = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.lblNganHang = new System.Windows.Forms.Label();
            this.lblSoTaiKhoan = new System.Windows.Forms.Label();
            this.lblTenTaiKhoan = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTaoQR = new System.Windows.Forms.Button();
            this.tbxSDT = new System.Windows.Forms.TextBox();
            this.tbxCCCD = new System.Windows.Forms.TextBox();
            this.tbxLoaiPhong = new System.Windows.Forms.TextBox();
            this.datiVao = new System.Windows.Forms.DateTimePicker();
            this.tbxSoPhong = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbxGiaPhong = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.datiRa = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.tbxTenKH = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbxHoaDon = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.lblTongTienPhong = new System.Windows.Forms.Label();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(603, 123);
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
            this.label1.Location = new System.Drawing.Point(679, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã QR Chuyển Khoản";
            // 
            // cbxNganHang
            // 
            this.cbxNganHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNganHang.FormattingEnabled = true;
            this.cbxNganHang.Location = new System.Drawing.Point(488, 36);
            this.cbxNganHang.Name = "cbxNganHang";
            this.cbxNganHang.Size = new System.Drawing.Size(121, 28);
            this.cbxNganHang.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(443, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chọn ngân hàng chuyển khoản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(726, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại QR";
            // 
            // cbxLoaiQR
            // 
            this.cbxLoaiQR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLoaiQR.FormattingEnabled = true;
            this.cbxLoaiQR.Items.AddRange(new object[] {
            "compact",
            "compact2",
            "qr_only",
            "print"});
            this.cbxLoaiQR.Location = new System.Drawing.Point(700, 36);
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
            this.panel1.Location = new System.Drawing.Point(578, 481);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 193);
            this.panel1.TabIndex = 6;
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
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Location = new System.Drawing.Point(137, 121);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(21, 20);
            this.lblSoTien.TabIndex = 8;
            this.lblSoTien.Text = "...";
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
            // lblSoTaiKhoan
            // 
            this.lblSoTaiKhoan.AutoSize = true;
            this.lblSoTaiKhoan.Location = new System.Drawing.Point(137, 46);
            this.lblSoTaiKhoan.Name = "lblSoTaiKhoan";
            this.lblSoTaiKhoan.Size = new System.Drawing.Size(21, 20);
            this.lblSoTaiKhoan.TabIndex = 6;
            this.lblSoTaiKhoan.Text = "...";
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
            // btnTaoQR
            // 
            this.btnTaoQR.Location = new System.Drawing.Point(885, 38);
            this.btnTaoQR.Name = "btnTaoQR";
            this.btnTaoQR.Size = new System.Drawing.Size(142, 32);
            this.btnTaoQR.TabIndex = 7;
            this.btnTaoQR.Text = "Tạo mã QR";
            this.btnTaoQR.UseVisualStyleBackColor = true;
            this.btnTaoQR.Click += new System.EventHandler(this.btnTaoQR_Click);
            // 
            // tbxSDT
            // 
            this.tbxSDT.Enabled = false;
            this.tbxSDT.Location = new System.Drawing.Point(207, 546);
            this.tbxSDT.Name = "tbxSDT";
            this.tbxSDT.Size = new System.Drawing.Size(137, 26);
            this.tbxSDT.TabIndex = 31;
            // 
            // tbxCCCD
            // 
            this.tbxCCCD.Enabled = false;
            this.tbxCCCD.Location = new System.Drawing.Point(207, 481);
            this.tbxCCCD.Name = "tbxCCCD";
            this.tbxCCCD.Size = new System.Drawing.Size(152, 26);
            this.tbxCCCD.TabIndex = 30;
            // 
            // tbxLoaiPhong
            // 
            this.tbxLoaiPhong.Enabled = false;
            this.tbxLoaiPhong.Location = new System.Drawing.Point(207, 351);
            this.tbxLoaiPhong.Name = "tbxLoaiPhong";
            this.tbxLoaiPhong.Size = new System.Drawing.Size(152, 26);
            this.tbxLoaiPhong.TabIndex = 28;
            // 
            // datiVao
            // 
            this.datiVao.Enabled = false;
            this.datiVao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datiVao.Location = new System.Drawing.Point(207, 221);
            this.datiVao.Name = "datiVao";
            this.datiVao.Size = new System.Drawing.Size(152, 26);
            this.datiVao.TabIndex = 26;
            // 
            // tbxSoPhong
            // 
            this.tbxSoPhong.Enabled = false;
            this.tbxSoPhong.Location = new System.Drawing.Point(207, 91);
            this.tbxSoPhong.Name = "tbxSoPhong";
            this.tbxSoPhong.Size = new System.Drawing.Size(152, 26);
            this.tbxSoPhong.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 546);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Số điện thoại:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 481);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Căn cước công dân:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 351);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 20);
            this.label12.TabIndex = 20;
            this.label12.Text = "Loại phòng:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(23, 221);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 20);
            this.label14.TabIndex = 18;
            this.label14.Text = "Ngày vào:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(23, 91);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 20);
            this.label16.TabIndex = 16;
            this.label16.Text = "Tên phòng:";
            // 
            // tbxGiaPhong
            // 
            this.tbxGiaPhong.Enabled = false;
            this.tbxGiaPhong.Location = new System.Drawing.Point(207, 156);
            this.tbxGiaPhong.Name = "tbxGiaPhong";
            this.tbxGiaPhong.Size = new System.Drawing.Size(152, 26);
            this.tbxGiaPhong.TabIndex = 33;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 156);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 20);
            this.label15.TabIndex = 32;
            this.label15.Text = "Giá phòng:";
            // 
            // datiRa
            // 
            this.datiRa.Enabled = false;
            this.datiRa.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datiRa.Location = new System.Drawing.Point(207, 286);
            this.datiRa.Name = "datiRa";
            this.datiRa.Size = new System.Drawing.Size(152, 26);
            this.datiRa.TabIndex = 35;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 286);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 20);
            this.label13.TabIndex = 34;
            this.label13.Text = "Ngày ra:";
            // 
            // tbxTenKH
            // 
            this.tbxTenKH.Enabled = false;
            this.tbxTenKH.Location = new System.Drawing.Point(207, 416);
            this.tbxTenKH.Name = "tbxTenKH";
            this.tbxTenKH.Size = new System.Drawing.Size(201, 26);
            this.tbxTenKH.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 416);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 20);
            this.label11.TabIndex = 36;
            this.label11.Text = "Tên khách hàng:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(23, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 20);
            this.label17.TabIndex = 38;
            this.label17.Text = "Mã hoá đơn:";
            // 
            // tbxHoaDon
            // 
            this.tbxHoaDon.Enabled = false;
            this.tbxHoaDon.Location = new System.Drawing.Point(207, 26);
            this.tbxHoaDon.Name = "tbxHoaDon";
            this.tbxHoaDon.Size = new System.Drawing.Size(152, 26);
            this.tbxHoaDon.TabIndex = 39;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersHeight = 30;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 680);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.Size = new System.Drawing.Size(1067, 239);
            this.dataGridView1.TabIndex = 40;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.AutoSize = true;
            this.btnXacNhan.Location = new System.Drawing.Point(516, 925);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(87, 30);
            this.btnXacNhan.TabIndex = 41;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.button1_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(24, 611);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(149, 20);
            this.label18.TabIndex = 42;
            this.label18.Text = "Tổng tiền phòng: ";
            // 
            // lblTongTienPhong
            // 
            this.lblTongTienPhong.AutoSize = true;
            this.lblTongTienPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienPhong.Location = new System.Drawing.Point(203, 611);
            this.lblTongTienPhong.Name = "lblTongTienPhong";
            this.lblTongTienPhong.Size = new System.Drawing.Size(14, 20);
            this.lblTongTienPhong.TabIndex = 43;
            this.lblTongTienPhong.Text = ".";
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.AutoSize = true;
            this.btnInHoaDon.Location = new System.Drawing.Point(13, 922);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(116, 30);
            this.btnInHoaDon.TabIndex = 44;
            this.btnInHoaDon.Text = "In Hoá Đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = true;
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);
            // 
            // ThanhToanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 964);
            this.Controls.Add(this.btnInHoaDon);
            this.Controls.Add(this.lblTongTienPhong);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tbxHoaDon);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tbxTenKH);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.datiRa);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbxGiaPhong);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbxSDT);
            this.Controls.Add(this.tbxCCCD);
            this.Controls.Add(this.tbxLoaiPhong);
            this.Controls.Add(this.datiVao);
            this.Controls.Add(this.tbxSoPhong);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label16);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.TextBox tbxSDT;
        private System.Windows.Forms.TextBox tbxCCCD;
        private System.Windows.Forms.TextBox tbxLoaiPhong;
        private System.Windows.Forms.DateTimePicker datiVao;
        private System.Windows.Forms.TextBox tbxSoPhong;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbxGiaPhong;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker datiRa;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbxTenKH;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbxHoaDon;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblTongTienPhong;
        private System.Windows.Forms.Button btnInHoaDon;
    }
}