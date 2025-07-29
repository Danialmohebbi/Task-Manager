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
    /// <summary>
    /// Represents the Register Form.
    /// </summary>
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
        
        /// <summary>
        /// Handle the logic for registering.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
