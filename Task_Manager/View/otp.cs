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
    /// <summary>
    /// Represents the OTP form for students.
    /// Handles the logic for otp.
    /// </summary>
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
        
        /// <summary>
        /// Handle the logic for sending the OTP.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getOtp_Click(object sender, EventArgs e)
        {
            string otp = _studentservice.GenerateOtp();
            _studentservice.StoreOtp(Email.Text, otp);
            _studentservice.SendEmail(Email.Text, otp);
        }
        /// <summary>
        /// Handles the logic for verification of the inputted OTP.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verify_Click(object sender, EventArgs e)
        {
            bool success = _studentservice
                .VerifyOtp(
                    Email.Text, inputedOtp.Text
                );
            if (success)
            {
                Close();
                new ChangePassword(_login, new StudentService(new StudentRepository())).Show();
            }
            else
            {
                MessageBox.Show("Incorrect!");
            }
        }

        private void Email_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
