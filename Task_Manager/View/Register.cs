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

namespace Task_Manager
{
    public partial class Register : Form
    {
        Login _login;
        StudentService _studentService;
        public Register(Login login, StudentService studentService)
        {
            InitializeComponent();
            _login = login;
            _studentService = studentService;
            BackColor = System.Drawing.Color.LightBlue;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Register_Click(object sender, EventArgs e)
        {
            bool success = _studentService.Register(
                new Models.Student
                (0,
                FirstName.Text,
                LastName.Text,
                Email.Text,
                Username.Text,
                Password.Text.MyHash()
                )) ;
            if (success)
            {
                _login.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("INCORRECT DATA");
            }
            
        }
    }
}
