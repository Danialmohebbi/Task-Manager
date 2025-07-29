namespace Task_Manager.View
{
    partial class ChangePassword
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
            emailText = new TextBox();
            passwordChangeText = new TextBox();
            changePassButton = new Button();
            SuspendLayout();
            // 
            // emailText
            // 
            emailText.Location = new Point(268, 138);
            emailText.Name = "emailText";
            emailText.PlaceholderText = "Email";
            emailText.Size = new Size(172, 23);
            emailText.TabIndex = 0;
            // 
            // passwordChangeText
            // 
            passwordChangeText.Location = new Point(268, 179);
            passwordChangeText.Name = "passwordChangeText";
            passwordChangeText.PlaceholderText = "New Password";
            passwordChangeText.Size = new Size(172, 23);
            passwordChangeText.TabIndex = 1;
            // 
            // changePassButton
            // 
            changePassButton.Location = new Point(268, 233);
            changePassButton.Name = "changePassButton";
            changePassButton.Size = new Size(141, 23);
            changePassButton.TabIndex = 2;
            changePassButton.Text = "Change password";
            changePassButton.UseVisualStyleBackColor = true;
            changePassButton.Click += changePassowrd;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(changePassButton);
            Controls.Add(passwordChangeText);
            Controls.Add(emailText);
            Name = "ChangePassword";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox emailText;
        private TextBox passwordChangeText;
        private Button changePassButton;
    }
}