using Task_Manager.Models;

namespace Task_Manager.View
{
    partial class tasks
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
            delete = new Button();
            toDeleteTaskId = new TextBox();
            priorityFilter = new ComboBox();
            completedFilter = new ComboBox();
            recurrenceFilter = new ComboBox();
            overdueFilter = new DateTimePicker();
            keywordFilter = new TextBox();
            tagFilter = new TextBox();
            earliestDueDateCheck = new CheckBox();
            sortCompletedDate = new CheckBox();
            priorityLabel = new Label();
            completedLabel = new Label();
            recurrenceLabel = new Label();
            tagLabel = new Label();
            keywordLabel = new Label();
            overdueLabel = new Label();
            SuspendLayout();
            // 
            // delete
            // 
            delete.Location = new Point(42, 403);
            delete.Name = "delete";
            delete.Size = new Size(112, 48);
            delete.TabIndex = 1;
            delete.Text = "delete";
            delete.UseVisualStyleBackColor = true;
            delete.ForeColor = Color.Black;
            delete.BackColor = ColorTranslator.FromHtml("#456882");
            delete.Font = new Font("Segoe UI", 13F);
            delete.Click += DeleteButton_Click;
            // 
            // toDeleteTaskId
            // 
            toDeleteTaskId.Location = new Point(42, 374);
            toDeleteTaskId.Name = "toDeleteTaskId";
            toDeleteTaskId.PlaceholderText = "Task id";
            toDeleteTaskId.Size = new Size(120, 23);
            toDeleteTaskId.TabIndex = 2;
            // 
            // priorityFilter
            // 
            priorityFilter.FormattingEnabled = true;
            priorityFilter.Items.AddRange(new object[] { "Low", "Medium", "High", "None" });
            priorityFilter.Location = new Point(126, 12);
            priorityFilter.Name = "priorityFilter";
            priorityFilter.Size = new Size(154, 23);
            priorityFilter.TabIndex = 3;
            priorityFilter.SelectedIndexChanged += Filter_SelectedIndexChanged;
            // 
            // completedFilter
            // 
            completedFilter.FormattingEnabled = true;
            completedFilter.Items.AddRange(new object[] { "False", "True", "None" });
            completedFilter.Location = new Point(126, 53);
            completedFilter.Name = "completedFilter";
            completedFilter.Size = new Size(154, 23);
            completedFilter.TabIndex = 4;
            completedFilter.SelectedIndexChanged += Filter_SelectedIndexChanged;
            // 
            // recurrenceFilter
            // 
            recurrenceFilter.FormattingEnabled = true;
            recurrenceFilter.Items.AddRange(new object[] { "Daily", "Weekly", "Monthly", "Yearly", "None" });
            recurrenceFilter.Location = new Point(126, 98);
            recurrenceFilter.Name = "recurrenceFilter";
            recurrenceFilter.Size = new Size(154, 23);
            recurrenceFilter.TabIndex = 5;
            recurrenceFilter.SelectedIndexChanged += Filter_SelectedIndexChanged;
            // 
            // overdueFilter
            // 
            overdueFilter.Checked = false;
            overdueFilter.Location = new Point(11, 345);
            overdueFilter.Name = "overdueFilter";
            overdueFilter.ShowCheckBox = true;
            overdueFilter.Size = new Size(200, 23);
            overdueFilter.TabIndex = 6;
            overdueFilter.ValueChanged += Filter_SelectedIndexChanged;
            // 
            // keywordFilter
            // 
            keywordFilter.Location = new Point(126, 178);
            keywordFilter.Name = "keywordFilter";
            keywordFilter.PlaceholderText = "word to search";
            keywordFilter.Size = new Size(154, 23);
            keywordFilter.TabIndex = 7;
            keywordFilter.TextChanged += Filter_SelectedIndexChanged;
            // 
            // tagFilter
            // 
            tagFilter.Location = new Point(126, 138);
            tagFilter.Name = "tagFilter";
            tagFilter.PlaceholderText = "tag";
            tagFilter.Size = new Size(154, 23);
            tagFilter.TabIndex = 8;
            tagFilter.TextChanged += Filter_SelectedIndexChanged;
            // 
            // earliestDueDateCheck
            // 
            earliestDueDateCheck.AutoSize = true;
            earliestDueDateCheck.Font = new Font("Segoe UI", 13F);
            earliestDueDateCheck.Location = new Point(11, 260);
            earliestDueDateCheck.Name = "earliestDueDateCheck";
            earliestDueDateCheck.Size = new Size(222, 29);
            earliestDueDateCheck.TabIndex = 9;
            earliestDueDateCheck.Text = "Sort Tasks by Due Dates";
            earliestDueDateCheck.UseVisualStyleBackColor = true;
            earliestDueDateCheck.CheckedChanged += Filter_SelectedIndexChanged;
            // 
            // sortCompletedDate
            // 
            sortCompletedDate.AutoSize = true;
            sortCompletedDate.Font = new Font("Segoe UI", 13F);
            sortCompletedDate.Location = new Point(12, 225);
            sortCompletedDate.Name = "sortCompletedDate";
            sortCompletedDate.Size = new Size(278, 29);
            sortCompletedDate.TabIndex = 10;
            sortCompletedDate.Text = "Sort Tasks by Completed Dates";
            sortCompletedDate.UseVisualStyleBackColor = true;
            sortCompletedDate.CheckedChanged += Filter_SelectedIndexChanged;
            // 
            // priorityLabel
            // 
            priorityLabel.AutoSize = true;
            priorityLabel.Font = new Font("Segoe UI", 13F);
            priorityLabel.Location = new Point(12, 9);
            priorityLabel.Name = "priorityLabel";
            priorityLabel.Size = new Size(68, 25);
            priorityLabel.TabIndex = 11;
            priorityLabel.Text = "Priority";
            // 
            // completedLabel
            // 
            completedLabel.AutoSize = true;
            completedLabel.Font = new Font("Segoe UI", 13F);
            completedLabel.Location = new Point(-1, 53);
            completedLabel.Name = "completedLabel";
            completedLabel.Size = new Size(100, 25);
            completedLabel.TabIndex = 12;
            completedLabel.Text = "Completed";
            // 
            // recurrenceLabel
            // 
            recurrenceLabel.AutoSize = true;
            recurrenceLabel.Font = new Font("Segoe UI", 13F);
            recurrenceLabel.Location = new Point(-1, 95);
            recurrenceLabel.Name = "recurrenceLabel";
            recurrenceLabel.Size = new Size(97, 25);
            recurrenceLabel.TabIndex = 13;
            recurrenceLabel.Text = "Recurrence";
            // 
            // tagLabel
            // 
            tagLabel.AutoSize = true;
            tagLabel.Font = new Font("Segoe UI", 13F);
            tagLabel.Location = new Point(27, 138);
            tagLabel.Name = "tagLabel";
            tagLabel.Size = new Size(39, 25);
            tagLabel.TabIndex = 14;
            tagLabel.Text = "Tag";
            // 
            // keywordLabel
            // 
            keywordLabel.AutoSize = true;
            keywordLabel.Font = new Font("Segoe UI", 13F);
            keywordLabel.Location = new Point(11, 178);
            keywordLabel.Name = "keywordLabel";
            keywordLabel.Size = new Size(81, 25);
            keywordLabel.TabIndex = 15;
            keywordLabel.Text = "Keyword";
            // 
            // overdueLabel
            // 
            overdueLabel.AutoSize = true;
            overdueLabel.Font = new Font("Segoe UI", 13F);
            overdueLabel.Location = new Point(11, 292);
            overdueLabel.Name = "overdueLabel";
            overdueLabel.Size = new Size(237, 50);
            overdueLabel.TabIndex = 16;
            overdueLabel.Text = "Select a date, to check tasks \nthat will be overdue by then.";
            // 
            // tasks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(overdueLabel);
            Controls.Add(keywordLabel);
            Controls.Add(tagLabel);
            Controls.Add(recurrenceLabel);
            Controls.Add(completedLabel);
            Controls.Add(priorityLabel);
            Controls.Add(sortCompletedDate);
            Controls.Add(earliestDueDateCheck);
            Controls.Add(tagFilter);
            Controls.Add(keywordFilter);
            Controls.Add(overdueFilter);
            Controls.Add(recurrenceFilter);
            Controls.Add(completedFilter);
            Controls.Add(priorityFilter);
            Controls.Add(toDeleteTaskId);
            Controls.Add(delete);
            Name = "tasks";
            Text = "Task Manager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button delete;
        private TextBox toDeleteTaskId;
        private ComboBox priorityFilter;
        private ComboBox completedFilter;
        private ComboBox recurrenceFilter;
        private DateTimePicker overdueFilter;
        private TextBox keywordFilter;
        private TextBox tagFilter;
        private CheckBox earliestDueDateCheck;
        private CheckBox sortCompletedDate;
        private Label priorityLabel;
        private Label completedLabel;
        private Label recurrenceLabel;
        private Label tagLabel;
        private Label keywordLabel;
        private Label overdueLabel;
    }
}