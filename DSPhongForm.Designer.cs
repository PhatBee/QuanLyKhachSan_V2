namespace QuanLyKhachSan
{
    partial class DSPhongForm
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
            this.flpPhong = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuanLyPhong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flpPhong
            // 
            this.flpPhong.Location = new System.Drawing.Point(0, 2);
            this.flpPhong.Name = "flpPhong";
            this.flpPhong.Size = new System.Drawing.Size(1327, 747);
            this.flpPhong.TabIndex = 4;
            // 
            // btnQuanLyPhong
            // 
            this.btnQuanLyPhong.AutoSize = true;
            this.btnQuanLyPhong.Location = new System.Drawing.Point(0, 756);
            this.btnQuanLyPhong.Name = "btnQuanLyPhong";
            this.btnQuanLyPhong.Size = new System.Drawing.Size(123, 30);
            this.btnQuanLyPhong.TabIndex = 5;
            this.btnQuanLyPhong.Text = "Quản lý phòng";
            this.btnQuanLyPhong.UseVisualStyleBackColor = true;
            this.btnQuanLyPhong.Click += new System.EventHandler(this.btnQuanLyPhong_Click);
            // 
            // DSPhongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 790);
            this.Controls.Add(this.btnQuanLyPhong);
            this.Controls.Add(this.flpPhong);
            this.Font = new System.Drawing.Font("Aptos Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DSPhongForm";
            this.Text = "DSPhongForm";
            this.Load += new System.EventHandler(this.DSPhongForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flpPhong;
        private System.Windows.Forms.Button btnQuanLyPhong;
    }
}