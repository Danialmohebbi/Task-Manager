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
using Task_Manager.App.Interfaces;
using Task_Manager.App.Services;
using Task_Manager.Data.Repositories;
using Task_Manager.Models;

namespace Task_Manager.View
{
    /// <summary>
    /// Represents the Changing Password form for students.
    /// Handles Password Change Logic.
    /// </summary>
    public partial class ChangePassword : Form
    {
        StudentService _studentService;
        Login _loginPage;
        public ChangePassword(Login loginPage, StudentService studentService)
        {
            _studentService = studentService;
            _loginPage = loginPage;
            InitializeComponent();
            BackColor = System.Drawing.Color.LightBlue;
            StartPosition = FormStartPosition.CenterScreen;
        }
        
        /// <summary>
        /// Handle Change Password Logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changePassowrd(object sender, EventArgs e)
        {
            StudentBuilder builder = new StudentBuilder();
            string userCred = emailText.Text;
            string newPassword = passwordChangeText.Text;

            var student = _studentService.GetUserByLogin(userCred);
            builder.SetId(student.Id);
            builder.SetPassword(newPassword.MyHash());
            builder.SetEmail(student.Email);
            builder.SetLastName(student.LastName);
            builder.SetFirstName(student.FirstName);
            builder.SetUsername(student.Username);

            _studentService.Edit(builder.GetStudent());
            _loginPage.Show();
            Hide();
        }
    }
}
