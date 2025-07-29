using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task_Manager.App.Extensions;
using Task_Manager.App.Services;
using Task_Manager.Data.Repositories;
using Task_Manager.View;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Task_Manager
{

    public partial class Login : Form
    {
        private StudentService _studentService;
        public Login()
        {
            InitializeComponent();
            StudentRepository studentRepository = new StudentRepository();
            _studentService = new(studentRepository);
            BackColor = System.Drawing.Color.LightBlue;
            StartPosition = FormStartPosition.CenterScreen;
        }




        private void login_Click(object sender, EventArgs e)
        {
            string username = Username_Input.Text;
            string password = Password_Input.Text;

            if (_studentService.Login(username, password.MyHash()))
            {
                new tasks(new TaskService(new TaskRepository()), _studentService.GetUserByLogin(username).Id).Show();
                Hide();
            }
            else
            {
                MessageBox.Show("username/email or password is incorrect!");
            }
        }

        private void register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register registerForm = new Register(this, _studentService);
            registerForm.Show();
            Hide();
        }

        private void GetOtp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            otp otp = new otp(this, _studentService);
            otp.Show();
            Hide();
        }

    }
}
