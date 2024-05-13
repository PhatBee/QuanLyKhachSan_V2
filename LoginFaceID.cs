
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class LoginFaceID : Form
    {

        private string maNV;
        private FaceRec faceRec = new FaceRec();
        private Timer timer;
        private bool loginSuccess = false;
         MYDB mydb = new MYDB();

        public LoginFaceID()
        {
            InitializeComponent();
            label1.Text = "Nhân Viên";
            faceRec.openCamera(pictureBox1);
            faceRec.isTrained = true;
            // Khởi tạo timer và cấu hình thời gian cập nhật
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 100; // Cập nhật mỗi 500ms
            timer.Start();
        }


        // Hàm xử lý sự kiện cập nhật tên người dùng
        private int timerTickCount = 0;
        private const int TimerDelayInSeconds = 2; // Delay for 3 seconds


        private void Timer_Tick(object sender, EventArgs e)
        {
            timerTickCount++;
            maNV = faceRec.NamePerson;
            label1.Text = maNV;
            //person name là cái mã bệnh nhân của t, m thay bằng mã nhân viên hay gì đó


            if (timerTickCount >= TimerDelayInSeconds * 10 && !loginSuccess && timer.Enabled)
            {
                if (!string.IsNullOrEmpty(maNV) && maNV != "Nhân viên")
                {

                    //khúc này là tạo bệnh nhân để xài cái hàm trong class patient
                    /*Patient patient = new Patient();
                    patient = patient.checkPatient(personName); // trong class patient code hàm checkpatient xem co tồn tại id đó trong database không, nếu có thì t hiển thị thông tin bệnh nhân
                    if (patient != null)
                    {
                        // Đóng camera trước khi đóng form
                        // Tạm dừng timer trước khi đóng form
                        faceRec.closeCamera();
                        timer.Stop();
                        loginSuccess = true;
                        faceRec.isTrained = false;

                        InfoPatient infoPatientForm = new InfoPatient(patient)
                        {
                            StartPosition = FormStartPosition.CenterScreen
                        };
                        infoPatientForm.Show();
                        // Đóng form hiện tại
                        this.Dispose();
                    }*/
                    if(checkNhanVien(maNV) == true)
                    {
                        faceRec.closeCamera();
                        timer.Stop();
                        loginSuccess = true;
                        faceRec.isTrained = false;
                        checkInNhanVien(maNV);
                        // Đóng form hiện tại
                        this.Dispose();
                    }
                }
            }
        }
        public bool checkNhanVien(string maNV)
        {
           SqlDataAdapter adapter = new SqlDataAdapter("Select * from NhanVien Where MaNV = '"+maNV+"'",mydb.getConnection);
           DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public void checkInNhanVien(string maNV)
        {
            try
            {
                DateTime tmp = new DateTime(2024, 05, 11);
                DateTime.TryParse(tmp.ToString(), out DateTime ngay);

                SqlCommand cmd = new SqlCommand("SELECT * FROM PhanCong Where MaNV = @manv AND Ngay = @ngay", mydb.getConnection);
                cmd.Parameters.Add("@manv", SqlDbType.VarChar).Value = Globals.GlobalUserID;
                cmd.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    SqlCommand command = new SqlCommand("UPDATE PhanCong Set TgVaoLam = @tgbd Where MaNV = @manv AND Ngay = @ngay", mydb.getConnection);
                    command.Parameters.Add("@tgbd", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@manv", SqlDbType.VarChar).Value = Globals.GlobalUserID;
                    command.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
                    mydb.openConection();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Check in thành công!", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                mydb.closeConection();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoginFaceID_Load(object sender, EventArgs e)
        {

        }

        private void LoginFaceID_FormClosed(object sender, FormClosedEventArgs e)
        {
            faceRec.closeCamera();
        }

        private void LoginFaceID_FormClosing(object sender, FormClosingEventArgs e)
        {
            faceRec.closeCamera();
        }
    }
}