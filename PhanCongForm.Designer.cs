﻿namespace QuanLyKhachSan
{
    partial class PhanCongForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpBatDau = new System.Windows.Forms.DateTimePicker();
            this.panelChuky = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxCa = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblThoiGianCa = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXemDanhSach = new System.Windows.Forms.Button();
            this.btnLuu2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelChuky.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ngày bắt đầu:";
            // 
            // dtpBatDau
            // 
            this.dtpBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBatDau.Location = new System.Drawing.Point(122, 15);
            this.dtpBatDau.Name = "dtpBatDau";
            this.dtpBatDau.Size = new System.Drawing.Size(132, 26);
            this.dtpBatDau.TabIndex = 6;
            // 
            // panelChuky
            // 
            this.panelChuky.AutoSize = true;
            this.panelChuky.Controls.Add(this.label1);
            this.panelChuky.Controls.Add(this.dtpBatDau);
            this.panelChuky.Location = new System.Drawing.Point(225, 93);
            this.panelChuky.Name = "panelChuky";
            this.panelChuky.Size = new System.Drawing.Size(257, 100);
            this.panelChuky.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Thời gian phân công";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(579, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ca làm việc:";
            // 
            // cbxCa
            // 
            this.cbxCa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCa.FormattingEnabled = true;
            this.cbxCa.Location = new System.Drawing.Point(703, 110);
            this.cbxCa.Name = "cbxCa";
            this.cbxCa.Size = new System.Drawing.Size(74, 28);
            this.cbxCa.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(579, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Thời gian ca:";
            // 
            // lblThoiGianCa
            // 
            this.lblThoiGianCa.AutoSize = true;
            this.lblThoiGianCa.Location = new System.Drawing.Point(699, 154);
            this.lblThoiGianCa.Name = "lblThoiGianCa";
            this.lblThoiGianCa.Size = new System.Drawing.Size(21, 20);
            this.lblThoiGianCa.TabIndex = 14;
            this.lblThoiGianCa.Text = "...";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 205);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(661, 462);
            this.dataGridView1.TabIndex = 15;
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.AutoSize = true;
            this.btnPhanCong.Location = new System.Drawing.Point(682, 695);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Size = new System.Drawing.Size(95, 30);
            this.btnPhanCong.TabIndex = 18;
            this.btnPhanCong.Text = "Phân công";
            this.btnPhanCong.UseVisualStyleBackColor = true;
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.AutoSize = true;
            this.btnLuu.Location = new System.Drawing.Point(565, 695);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(90, 30);
            this.btnLuu.TabIndex = 19;
            this.btnLuu.Text = "Lưu (Cũ)";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXemDanhSach
            // 
            this.btnXemDanhSach.AutoSize = true;
            this.btnXemDanhSach.Location = new System.Drawing.Point(904, 127);
            this.btnXemDanhSach.Name = "btnXemDanhSach";
            this.btnXemDanhSach.Size = new System.Drawing.Size(161, 47);
            this.btnXemDanhSach.TabIndex = 20;
            this.btnXemDanhSach.Text = "Xem danh sách trực";
            this.btnXemDanhSach.UseVisualStyleBackColor = true;
            // 
            // btnLuu2
            // 
            this.btnLuu2.AutoSize = true;
            this.btnLuu2.Location = new System.Drawing.Point(451, 695);
            this.btnLuu2.Name = "btnLuu2";
            this.btnLuu2.Size = new System.Drawing.Size(90, 30);
            this.btnLuu2.TabIndex = 22;
            this.btnLuu2.Text = "Lưu";
            this.btnLuu2.UseVisualStyleBackColor = true;
            this.btnLuu2.Click += new System.EventHandler(this.btnLuu2_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(719, 205);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(617, 462);
            this.dataGridView2.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Aptos", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(0, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1342, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "BẢNG PHÂN CÔNG";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1362, 54);
            this.panel2.TabIndex = 4;
            // 
            // PhanCongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 806);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnLuu2);
            this.Controls.Add(this.btnXemDanhSach);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnPhanCong);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblThoiGianCa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxCa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelChuky);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PhanCongForm";
            this.Text = "PhanCongForm";
            this.Load += new System.EventHandler(this.PhanCongForm_Load);
            this.panelChuky.ResumeLayout(false);
            this.panelChuky.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpBatDau;
        private System.Windows.Forms.Panel panelChuky;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxCa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblThoiGianCa;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXemDanhSach;
        private System.Windows.Forms.Button btnLuu2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
    }
}