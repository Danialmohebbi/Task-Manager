namespace Task_Manager
{
    partial class Login
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
            Username_Input = new TextBox();
            Password_Input = new TextBox();
            Register = new LinkLabel();
            enter = new Button();
            getOtp = new LinkLabel();
            SuspendLayout();
            // 
            // Username_Input
            // 
            Username_Input.Location = new Point(86, 100);
            Username_Input.Name = "Username_Input";
            Username_Input.PlaceholderText = "Username/Email";
            Username_Input.Size = new Size(200, 23);
            Username_Input.TabIndex = 0;
            // 
            // Password_Input
            // 
            Password_Input.Location = new Point(86, 139);
            Password_Input.Name = "Password_Input";
            Password_Input.PasswordChar = '*';
            Password_Input.PlaceholderText = "Password";
            Password_Input.Size = new Size(164, 23);
            Password_Input.TabIndex = 1;
            // 
            // Register
            // 
            Register.AutoSize = true;
            Register.Location = new Point(86, 218);
            Register.Name = "Register";
            Register.Size = new Size(90, 15);
            Register.TabIndex = 2;
            Register.TabStop = true;
            Register.Text = "Register_Button";
            Register.LinkClicked += register_LinkClicked;
            // 
            // enter
            // 
            enter.Location = new Point(86, 182);
            enter.Name = "enter";
            enter.Size = new Size(75, 23);
            enter.TabIndex = 3;
            enter.Text = "enter";
            enter.UseVisualStyleBackColor = true;
            enter.Click += login_Click;
            // 
            // getOtp
            // 
            getOtp.AutoSize = true;
            getOtp.Location = new Point(86, 244);
            getOtp.Name = "getOtp";
            getOtp.Size = new Size(49, 15);
            getOtp.TabIndex = 4;
            getOtp.TabStop = true;
            getOtp.Text = "Get otp ";
            getOtp.LinkClicked += GetOtp_LinkClicked;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(361, 346);
            Controls.Add(getOtp);
            Controls.Add(enter);
            Controls.Add(Register);
            Controls.Add(Password_Input);
            Controls.Add(Username_Input);
            Name = "Login";
            Text = "Login Page";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Username_Input;
        private TextBox Password_Input;
        private Button login;
        private LinkLabel Register;
        private Button enter;
        private LinkLabel getOtp;
    }
}