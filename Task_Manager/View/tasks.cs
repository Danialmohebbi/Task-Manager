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
using Task_Manager.Models;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Task_Manager.View
{
    public partial class tasks : Form
    {
        TaskService _taskService;
        int _studentId;
        IEnumerable<TaskItem> _tasks;
        DataGridView _dataGridView;
        public tasks(TaskService taskService, int studentId)
        {
            BackColor = ColorTranslator.FromHtml("#1B3C53");
            ForeColor = ColorTranslator.FromHtml("#F9F3EF");
            WindowState = FormWindowState.Maximized;
            MaximizeBox = false;
            InitializeComponent();

            _taskService = taskService;
            _studentId = studentId;
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            _dataGridView = new DataGridView
            {
                Location = new Point(300, 0),
                Size = new Size(ClientSize.Width - 300, ClientSize.Height),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                ScrollBars = ScrollBars.Both,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = true,
                BackgroundColor = ColorTranslator.FromHtml("#D2C1B6")
            };

            _dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(
                "Segoe UI",
                11,        
                FontStyle.Bold
            );

            _dataGridView.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F9F3EF");
            _dataGridView.RowsDefaultCellStyle.ForeColor = Color.Black;



            _tasks = _taskService.ViewTasks(_studentId);

            _dataGridView.DataBindingComplete += (s, e) =>
            {
                _dataGridView.Columns["ID"].ReadOnly = true;
                _dataGridView.Columns["Created At"].ReadOnly = true;
                _dataGridView.Columns["Updated At"].ReadOnly = true;

            };
            _tasks = _taskService.ViewTasks(_studentId);
            Update();

            _dataGridView.KeyDown += DataGridView_KeyDown;

            this.Controls.Add(_dataGridView);
        }
        private void Update()
        {

            DataTable table = CreateTaskTable();

            foreach (var task in _tasks)
            {
                AddRow(table, task);
            }

            _dataGridView.DataSource = table;
        }


        private DataTable CreateTaskTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Completed", typeof(bool));
            table.Columns.Add("Priority", typeof(Models.Priority));
            table.Columns.Add("Tag", typeof(string));
            table.Columns.Add("Recurrence", typeof(Models.Recurrence));
            table.Columns.Add("Created At", typeof(DateTime));
            table.Columns.Add("Updated At", typeof(DateTime));
            table.Columns.Add("Completed At", typeof(DateTime));
            table.Columns.Add("Due Date At", typeof(DateTime));


            return table;
        }

        private void AddRow(DataTable table, Models.TaskItem task)
        {
            table.Rows.Add(
                task.Id,
                task.Title,
                task.Description,
                task.Completed,
                task.Priority,
                task.Category,
                task.Recurrence,
                task.CreatedAt,
                task.UpdatedAt,
                task.CompletedAt,
                task.DueDate
            );
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int taskId = int.Parse(toDeleteTaskId.Text);
            _taskService.DeleteTask(taskId, _studentId);
            _tasks = _taskService.ViewTasks(_studentId);
            Update();
        }


        private void SaveTaskFromRow(DataGridViewRow row)
        {
            if (row.IsNewRow) return;

            string title = row.Cells["Title"].Value?.ToString()?.Trim();
            var dueDateObj = row.Cells["Due Date At"].Value;

            if (string.IsNullOrEmpty(title) || dueDateObj == null || dueDateObj == DBNull.Value || !DateTime.TryParse(dueDateObj.ToString(), out _))
            {
                MessageBox.Show("Invalid data. Title and Due Date are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = row.Cells["ID"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["ID"].Value) : 0;
            var taskItem = new TaskItem(
                id,
                _studentId,
                title,
                row.Cells["Description"].Value?.ToString() ?? "",
                Convert.ToDateTime(row.Cells["Due Date At"].Value),
                row.Cells["Completed"].Value != DBNull.Value && Convert.ToBoolean(row.Cells["Completed"].Value),
                row.Cells["Priority"].Value != DBNull.Value
                    ? (Priority?)Enum.ToObject(typeof(Priority), row.Cells["Priority"].Value)
                    : null,
                row.Cells["Tag"].Value?.ToString(),
                row.Cells["Recurrence"].Value != DBNull.Value
                    ? (Recurrence?)Enum.ToObject(typeof(Recurrence), row.Cells["Recurrence"].Value)
                    : null,
                row.Cells["Created At"].Value != DBNull.Value
                    ? Convert.ToDateTime(row.Cells["Created At"].Value)
                    : DateTime.Now,
                DateTime.Now,
                (row.Cells["Completed"].Value != DBNull.Value && Convert.ToBoolean(row.Cells["Completed"].Value)) &&
                (row.Cells["Completed At"].Value == DBNull.Value || row.Cells["Completed At"].Value == null)
                    ? DateTime.Now
                    : row.Cells["Completed At"].Value != DBNull.Value
                        ? (DateTime?)Convert.ToDateTime(row.Cells["Completed At"].Value)
                        : null

            );


            if (id == 0)
                _taskService.AddTask(taskItem);
            else
                _taskService.EditTask(taskItem);
            _tasks = _taskService.ViewTasks(_studentId);
            BeginInvoke(new MethodInvoker(Update));
        }


        private void DataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && _dataGridView.CurrentRow != null)
            {
                e.Handled = true;
                _dataGridView.EndEdit();

                SaveTaskFromRow(_dataGridView.CurrentRow);
            }
        }

        private void Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? chosenPriority = priorityFilter.SelectedItem?.ToString();
            string? chosenCompeletions = completedFilter.SelectedItem?.ToString();
            string? chosenRecurrence = recurrenceFilter.SelectedItem?.ToString();
            DateTime selectedDate = overdueFilter.Value.Date;
            string? keyword = keywordFilter.Text;
            string? tag = tagFilter.Text;
            bool sortByDueDate = earliestDueDateCheck.Checked;
            bool sortByCompletedDate = sortCompletedDate.Checked;

            IEnumerable<TaskItem> tasks = _taskService.ViewTasks(_studentId);

            if (!string.IsNullOrEmpty(chosenPriority) && Enum.TryParse<Priority>(chosenPriority, out var selectedPriority))
                tasks = tasks.FilterByPriority(selectedPriority);

            if (!string.IsNullOrEmpty(chosenCompeletions) && bool.TryParse(chosenCompeletions, out var selectedCompeletions))
                tasks = tasks.FilterByCompleted(selectedCompeletions);

            if (!string.IsNullOrEmpty(chosenRecurrence) && Enum.TryParse<Recurrence>(chosenRecurrence, out var selectedRecurrence))
                tasks = tasks.FilterByRecurrence(selectedRecurrence);

            if (overdueFilter.Checked)
                tasks = tasks.FilterOverdueTasks(selectedDate);

            if (sortByDueDate)
                tasks = tasks.FilterEarlistDueDates();

            if (sortByCompletedDate)
                tasks = tasks.SortCompletedDate();
            if (keyword != "")
                tasks = tasks.FilterByKeyword(keyword);
            if (tag != "")
                tasks = tasks.FilterByTag(tag);

            _tasks = tasks;
            Update();
        }


    }
}

