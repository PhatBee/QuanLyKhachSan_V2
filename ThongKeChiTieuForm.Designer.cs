namespace QuanLyKhachSan
{
    partial class ThongKeChiTieuForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabDoanhThu = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datiDen = new System.Windows.Forms.DateTimePicker();
            this.datiTu = new System.Windows.Forms.DateTimePicker();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridViewDoanhThu = new System.Windows.Forms.DataGridView();
            this.tabPhong = new System.Windows.Forms.TabPage();
            this.chartPhong = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.dataGridViewPhong = new System.Windows.Forms.DataGridView();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.rdoThang = new System.Windows.Forms.RadioButton();
            this.rdoNgay = new System.Windows.Forms.RadioButton();
            this.btnXacNhanDoanhThu = new System.Windows.Forms.Button();
            this.tabNhanVien = new System.Windows.Forms.TabPage();
            this.datiNgayNV = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewNhanVien = new System.Windows.Forms.DataGridView();
            this.chartNhanVien = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnXacNhanNhanVien = new System.Windows.Forms.Button();
            this.tab.SuspendLayout();
            this.tabDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDoanhThu)).BeginInit();
            this.tabPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhong)).BeginInit();
            this.tabNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabDoanhThu);
            this.tab.Controls.Add(this.tabPhong);
            this.tab.Controls.Add(this.tabNhanVien);
            this.tab.Location = new System.Drawing.Point(1, 1);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1258, 627);
            this.tab.TabIndex = 0;
            // 
            // tabDoanhThu
            // 
            this.tabDoanhThu.Controls.Add(this.btnXacNhanDoanhThu);
            this.tabDoanhThu.Controls.Add(this.label2);
            this.tabDoanhThu.Controls.Add(this.label1);
            this.tabDoanhThu.Controls.Add(this.datiDen);
            this.tabDoanhThu.Controls.Add(this.datiTu);
            this.tabDoanhThu.Controls.Add(this.chartDoanhThu);
            this.tabDoanhThu.Controls.Add(this.dataGridViewDoanhThu);
            this.tabDoanhThu.Location = new System.Drawing.Point(4, 29);
            this.tabDoanhThu.Name = "tabDoanhThu";
            this.tabDoanhThu.Padding = new System.Windows.Forms.Padding(3);
            this.tabDoanhThu.Size = new System.Drawing.Size(1250, 594);
            this.tabDoanhThu.TabIndex = 0;
            this.tabDoanhThu.Text = "Doanh Thu";
            this.tabDoanhThu.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Đến:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Từ:";
            // 
            // datiDen
            // 
            this.datiDen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datiDen.Location = new System.Drawing.Point(71, 69);
            this.datiDen.Name = "datiDen";
            this.datiDen.Size = new System.Drawing.Size(200, 26);
            this.datiDen.TabIndex = 20;
            // 
            // datiTu
            // 
            this.datiTu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datiTu.Location = new System.Drawing.Point(71, 12);
            this.datiTu.Name = "datiTu";
            this.datiTu.Size = new System.Drawing.Size(200, 26);
            this.datiTu.TabIndex = 19;
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(575, 68);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDoanhThu.Series.Add(series1);
            this.chartDoanhThu.Size = new System.Drawing.Size(660, 458);
            this.chartDoanhThu.TabIndex = 18;
            this.chartDoanhThu.Text = "chart2";
            // 
            // dataGridViewDoanhThu
            // 
            this.dataGridViewDoanhThu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDoanhThu.Location = new System.Drawing.Point(16, 116);
            this.dataGridViewDoanhThu.Name = "dataGridViewDoanhThu";
            this.dataGridViewDoanhThu.Size = new System.Drawing.Size(527, 378);
            this.dataGridViewDoanhThu.TabIndex = 17;
            this.dataGridViewDoanhThu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewDoanhThu_CellFormatting);
            // 
            // tabPhong
            // 
            this.tabPhong.Controls.Add(this.chartPhong);
            this.tabPhong.Controls.Add(this.btnXacNhan);
            this.tabPhong.Controls.Add(this.dataGridViewPhong);
            this.tabPhong.Controls.Add(this.dateTimePicker2);
            this.tabPhong.Controls.Add(this.dateTimePicker1);
            this.tabPhong.Controls.Add(this.rdoThang);
            this.tabPhong.Controls.Add(this.rdoNgay);
            this.tabPhong.Location = new System.Drawing.Point(4, 29);
            this.tabPhong.Name = "tabPhong";
            this.tabPhong.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhong.Size = new System.Drawing.Size(1250, 594);
            this.tabPhong.TabIndex = 1;
            this.tabPhong.Text = "Phòng";
            this.tabPhong.UseVisualStyleBackColor = true;
            // 
            // chartPhong
            // 
            chartArea2.Name = "ChartArea1";
            this.chartPhong.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartPhong.Legends.Add(legend2);
            this.chartPhong.Location = new System.Drawing.Point(575, 103);
            this.chartPhong.Name = "chartPhong";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartPhong.Series.Add(series2);
            this.chartPhong.Size = new System.Drawing.Size(660, 458);
            this.chartPhong.TabIndex = 16;
            this.chartPhong.Text = "chart1";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.AutoSize = true;
            this.btnXacNhan.Location = new System.Drawing.Point(331, 62);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(87, 30);
            this.btnXacNhan.TabIndex = 15;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // dataGridViewPhong
            // 
            this.dataGridViewPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPhong.Location = new System.Drawing.Point(16, 136);
            this.dataGridViewPhong.Name = "dataGridViewPhong";
            this.dataGridViewPhong.Size = new System.Drawing.Size(527, 378);
            this.dataGridViewPhong.TabIndex = 14;
            this.dataGridViewPhong.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewPhong_CellFormatting);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(150, 85);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(134, 26);
            this.dateTimePicker2.TabIndex = 13;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(150, 33);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(134, 26);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // rdoThang
            // 
            this.rdoThang.AutoSize = true;
            this.rdoThang.Location = new System.Drawing.Point(16, 88);
            this.rdoThang.Name = "rdoThang";
            this.rdoThang.Size = new System.Drawing.Size(112, 24);
            this.rdoThang.TabIndex = 11;
            this.rdoThang.Text = "Theo Tháng";
            this.rdoThang.UseVisualStyleBackColor = true;
            this.rdoThang.CheckedChanged += new System.EventHandler(this.rdoThang_CheckedChanged);
            // 
            // rdoNgay
            // 
            this.rdoNgay.AutoSize = true;
            this.rdoNgay.Checked = true;
            this.rdoNgay.Location = new System.Drawing.Point(16, 33);
            this.rdoNgay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoNgay.Name = "rdoNgay";
            this.rdoNgay.Size = new System.Drawing.Size(101, 24);
            this.rdoNgay.TabIndex = 10;
            this.rdoNgay.TabStop = true;
            this.rdoNgay.Text = "Theo ngày";
            this.rdoNgay.UseVisualStyleBackColor = true;
            this.rdoNgay.CheckedChanged += new System.EventHandler(this.rdoNgay_CheckedChanged);
            // 
            // btnXacNhanDoanhThu
            // 
            this.btnXacNhanDoanhThu.AutoSize = true;
            this.btnXacNhanDoanhThu.Location = new System.Drawing.Point(302, 39);
            this.btnXacNhanDoanhThu.Name = "btnXacNhanDoanhThu";
            this.btnXacNhanDoanhThu.Size = new System.Drawing.Size(87, 30);
            this.btnXacNhanDoanhThu.TabIndex = 23;
            this.btnXacNhanDoanhThu.Text = "Xác nhận";
            this.btnXacNhanDoanhThu.UseVisualStyleBackColor = true;
            this.btnXacNhanDoanhThu.Click += new System.EventHandler(this.btnXacNhanDoanhThu_Click);
            // 
            // tabNhanVien
            // 
            this.tabNhanVien.Controls.Add(this.btnXacNhanNhanVien);
            this.tabNhanVien.Controls.Add(this.chartNhanVien);
            this.tabNhanVien.Controls.Add(this.dataGridViewNhanVien);
            this.tabNhanVien.Controls.Add(this.datiNgayNV);
            this.tabNhanVien.Location = new System.Drawing.Point(4, 29);
            this.tabNhanVien.Name = "tabNhanVien";
            this.tabNhanVien.Padding = new System.Windows.Forms.Padding(3);
            this.tabNhanVien.Size = new System.Drawing.Size(1250, 594);
            this.tabNhanVien.TabIndex = 2;
            this.tabNhanVien.Text = "Nhân Viên";
            this.tabNhanVien.UseVisualStyleBackColor = true;
            // 
            // datiNgayNV
            // 
            this.datiNgayNV.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datiNgayNV.Location = new System.Drawing.Point(54, 47);
            this.datiNgayNV.Name = "datiNgayNV";
            this.datiNgayNV.Size = new System.Drawing.Size(134, 26);
            this.datiNgayNV.TabIndex = 13;
            // 
            // dataGridViewNhanVien
            // 
            this.dataGridViewNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNhanVien.Location = new System.Drawing.Point(24, 104);
            this.dataGridViewNhanVien.Name = "dataGridViewNhanVien";
            this.dataGridViewNhanVien.Size = new System.Drawing.Size(527, 378);
            this.dataGridViewNhanVien.TabIndex = 15;
            // 
            // chartNhanVien
            // 
            chartArea3.Name = "ChartArea1";
            this.chartNhanVien.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartNhanVien.Legends.Add(legend3);
            this.chartNhanVien.Location = new System.Drawing.Point(590, 67);
            this.chartNhanVien.Name = "chartNhanVien";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartNhanVien.Series.Add(series3);
            this.chartNhanVien.Size = new System.Drawing.Size(660, 458);
            this.chartNhanVien.TabIndex = 17;
            this.chartNhanVien.Text = "chart1";
            // 
            // btnXacNhanNhanVien
            // 
            this.btnXacNhanNhanVien.AutoSize = true;
            this.btnXacNhanNhanVien.Location = new System.Drawing.Point(229, 47);
            this.btnXacNhanNhanVien.Name = "btnXacNhanNhanVien";
            this.btnXacNhanNhanVien.Size = new System.Drawing.Size(87, 30);
            this.btnXacNhanNhanVien.TabIndex = 18;
            this.btnXacNhanNhanVien.Text = "Xác nhận";
            this.btnXacNhanNhanVien.UseVisualStyleBackColor = true;
            this.btnXacNhanNhanVien.Click += new System.EventHandler(this.btnXacNhanNhanVien_Click);
            // 
            // ThongKeChiTieuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 691);
            this.Controls.Add(this.tab);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ThongKeChiTieuForm";
            this.Text = "ThongKeChiTieuForm";
            this.Load += new System.EventHandler(this.ThongKeChiTieuForm_Load);
            this.tab.ResumeLayout(false);
            this.tabDoanhThu.ResumeLayout(false);
            this.tabDoanhThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDoanhThu)).EndInit();
            this.tabPhong.ResumeLayout(false);
            this.tabPhong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhong)).EndInit();
            this.tabNhanVien.ResumeLayout(false);
            this.tabNhanVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabDoanhThu;
        private System.Windows.Forms.TabPage tabPhong;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPhong;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.DataGridView dataGridViewPhong;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton rdoThang;
        private System.Windows.Forms.RadioButton rdoNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datiDen;
        private System.Windows.Forms.DateTimePicker datiTu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.DataGridView dataGridViewDoanhThu;
        private System.Windows.Forms.Button btnXacNhanDoanhThu;
        private System.Windows.Forms.TabPage tabNhanVien;
        private System.Windows.Forms.Button btnXacNhanNhanVien;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNhanVien;
        private System.Windows.Forms.DataGridView dataGridViewNhanVien;
        private System.Windows.Forms.DateTimePicker datiNgayNV;
    }
}