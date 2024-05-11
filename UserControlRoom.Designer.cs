namespace QuanLyKhachSan
{
    partial class UserControlRoom
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSoPhong = new System.Windows.Forms.Label();
            this.lblLoaiPhong = new System.Windows.Forms.Label();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.btnDat = new System.Windows.Forms.Button();
            this.btnTra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSoPhong
            // 
            this.lblSoPhong.Location = new System.Drawing.Point(0, 12);
            this.lblSoPhong.Name = "lblSoPhong";
            this.lblSoPhong.Size = new System.Drawing.Size(150, 23);
            this.lblSoPhong.TabIndex = 1;
            this.lblSoPhong.Text = "SoPhong";
            this.lblSoPhong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSoPhong.Click += new System.EventHandler(this.UserControlRoom_Click);
            // 
            // lblLoaiPhong
            // 
            this.lblLoaiPhong.Location = new System.Drawing.Point(0, 47);
            this.lblLoaiPhong.Name = "lblLoaiPhong";
            this.lblLoaiPhong.Size = new System.Drawing.Size(150, 23);
            this.lblLoaiPhong.TabIndex = 2;
            this.lblLoaiPhong.Text = "Loại Phòng:";
            this.lblLoaiPhong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLoaiPhong.Click += new System.EventHandler(this.UserControlRoom_Click);
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.Location = new System.Drawing.Point(0, 81);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(150, 23);
            this.lblTinhTrang.TabIndex = 3;
            this.lblTinhTrang.Text = "Tình trạng:";
            this.lblTinhTrang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTinhTrang.Click += new System.EventHandler(this.UserControlRoom_Click);
            // 
            // btnDat
            // 
            this.btnDat.Location = new System.Drawing.Point(13, 117);
            this.btnDat.Name = "btnDat";
            this.btnDat.Size = new System.Drawing.Size(52, 23);
            this.btnDat.TabIndex = 4;
            this.btnDat.Text = "Đặt";
            this.btnDat.UseVisualStyleBackColor = true;
            this.btnDat.Click += new System.EventHandler(this.btnDat_Click);
            // 
            // btnTra
            // 
            this.btnTra.Location = new System.Drawing.Point(82, 117);
            this.btnTra.Name = "btnTra";
            this.btnTra.Size = new System.Drawing.Size(52, 23);
            this.btnTra.TabIndex = 5;
            this.btnTra.Text = "Trả";
            this.btnTra.UseVisualStyleBackColor = true;
            this.btnTra.Click += new System.EventHandler(this.btnTra_Click);
            // 
            // UserControlRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnTra);
            this.Controls.Add(this.btnDat);
            this.Controls.Add(this.lblTinhTrang);
            this.Controls.Add(this.lblLoaiPhong);
            this.Controls.Add(this.lblSoPhong);
            this.Name = "UserControlRoom";
            this.Load += new System.EventHandler(this.UserControlRoom_Load);
            this.Click += new System.EventHandler(this.UserControlRoom_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSoPhong;
        private System.Windows.Forms.Label lblLoaiPhong;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.Button btnDat;
        private System.Windows.Forms.Button btnTra;
    }
}
