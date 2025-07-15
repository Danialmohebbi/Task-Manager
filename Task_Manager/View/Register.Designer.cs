namespace Task_Manager
{
    partial class Register
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
            FirstName = new TextBox();
            LastName = new TextBox();
            Email = new TextBox();
            Username = new TextBox();
            Password = new TextBox();
            Register_Button = new Button();
            SuspendLayout();
            // 
            // FirstName
            // 
            FirstName.Location = new Point(250, 107);
            FirstName.Name = "FirstName";
            FirstName.PlaceholderText = "First Name";
            FirstName.Size = new Size(222, 23);
            FirstName.TabIndex = 0;
            // 
            // LastName
            // 
            LastName.Location = new Point(250, 145);
            LastName.Name = "LastName";
            LastName.PlaceholderText = "Last Name";
            LastName.Size = new Size(222, 23);
            LastName.TabIndex = 1;
            // 
            // Email
            // 
            Email.Location = new Point(250, 183);
            Email.Name = "Email";
            Email.PlaceholderText = "Email";
            Email.Size = new Size(222, 23);
            Email.TabIndex = 2;
            // 
            // Username
            // 
            Username.Location = new Point(250, 222);
            Username.Name = "Username";
            Username.PlaceholderText = "Username";
            Username.Size = new Size(222, 23);
            Username.TabIndex = 3;
            // 
            // Password
            // 
            Password.Location = new Point(250, 263);
            Password.Name = "Password";
            Password.PlaceholderText = "Password";
            Password.Size = new Size(222, 23);
            Password.TabIndex = 4;
            // 
            // Register_Button
            // 
            Register_Button.Location = new Point(309, 301);
            Register_Button.Name = "Register_Button";
            Register_Button.Size = new Size(75, 23);
            Register_Button.TabIndex = 5;
            Register_Button.Text = "Register_Button";
            Register_Button.UseVisualStyleBackColor = true;
            Register_Button.Click += Register_Click;
            // 
            // Register_Button
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Register_Button);
            Controls.Add(Password);
            Controls.Add(Username);
            Controls.Add(Email);
            Controls.Add(LastName);
            Controls.Add(FirstName);
            Name = "Register_Button";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox FirstName;
        private TextBox LastName;
        private TextBox Email;
        private TextBox Username;
        private TextBox Password;
        private Button Register_Button;
    }
}