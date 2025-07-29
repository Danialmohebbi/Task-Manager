namespace Task_Manager
{
    partial class otp
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
            Email = new TextBox();
            GetOtp = new Button();
            inputedOtp = new TextBox();
            verify = new Button();
            SuspendLayout();
            // 
            // Email
            // 
            Email.Location = new Point(69, 90);
            Email.Name = "Email";
            Email.PlaceholderText = "Email";
            Email.Size = new Size(199, 23);
            Email.TabIndex = 0;
            // 
            // GetOtp
            // 
            GetOtp.Location = new Point(123, 132);
            GetOtp.Name = "GetOtp";
            GetOtp.Size = new Size(75, 23);
            GetOtp.TabIndex = 1;
            GetOtp.Text = "GetOtp";
            GetOtp.UseVisualStyleBackColor = true;
            GetOtp.Click += getOtp_Click;
            // 
            // inputedOtp
            // 
            inputedOtp.Location = new Point(110, 184);
            inputedOtp.Name = "inputedOtp";
            inputedOtp.Size = new Size(99, 23);
            inputedOtp.TabIndex = 3;
            // 
            // verify
            // 
            verify.Location = new Point(123, 213);
            verify.Name = "verify";
            verify.Size = new Size(75, 23);
            verify.TabIndex = 4;
            verify.Text = "Verify";
            verify.UseVisualStyleBackColor = true;
            verify.Click += verify_Click;
            // 
            // otp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 337);
            Controls.Add(verify);
            Controls.Add(inputedOtp);
            Controls.Add(GetOtp);
            Controls.Add(Email);
            Name = "OTP";
            Text = "OTP Page";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Email;
        private Button GetOtp;
        private TextBox inputedOtp;
        private Button verify;
    }
}