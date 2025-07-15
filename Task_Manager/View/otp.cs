using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task_Manager.App.Services;
using Task_Manager.Data.Repositories;
using Task_Manager.View;

namespace Task_Manager
{
    public partial class otp : Form
    {
        private StudentService _studentservice;
        private Login _login;
        public otp(Login login, StudentService studentService)
        {
            InitializeComponent();
            _login = login;
            _studentservice = studentService;
            BackColor = System.Drawing.Color.LightBlue;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void getOtp_Click(object sender, EventArgs e)
        {
            string otp = _studentservice.GenerateOtp();
            _studentservice.StoreOtp(Email.Text, otp);
            _studentservice.SendEmail(Email.Text, otp);
        }

        private void verify_Click(object sender, EventArgs e)
        {
            bool success = _studentservice
                .VerifyOtp(
                    Email.Text,inputedOtp.Text
                );
            if ( success )
            {
                new tasks(new TaskService(new TaskRepository()),_studentservice.GetUserByLogin(Email.Text).Id).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect!");
            }
        }
    }
}
