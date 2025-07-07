using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;
using Task_Manager.App.Interfaces;

namespace Task_Manager.Data.Repositories;
using Task_Manager.Models;

public class TaskRepository : ITaskRepository
{
    
    private bool TaskExists(int id, NpgsqlConnection conn)
    {
        using var checkCmd = new NpgsqlCommand(
            "SELECT COUNT(*) FROM tasks WHERE task_id = @id",
            conn);
    
        checkCmd.Parameters.AddWithValue("@id", id);
    
        var existingTaskCount = (long) checkCmd.ExecuteScalar();
    
        return existingTaskCount > 0;
    }

    public void Add(TaskItem task)
    {
        using var conn = Database.Connect();

        if (TaskExists(task.Id, conn))
        {
            Console.WriteLine("Task already exists!");
            return;
        }

        string query;
        var cmd = new NpgsqlCommand();
        cmd.Connection = conn;

        if (task.Id > 0)
        {
            
            query = @"
            INSERT INTO tasks(task_id, student_id, title, description, due_date, completed, priority, category, recurrence, created_at, updated_at, completed_at)
            VALUES (@StudentId, @Title, @Description, @DueDate, @Completed, @priority, @Category, @recurrence, @CreatedAt, @UpdatedAt, @CompletedAt)
            ";
            cmd.Parameters.AddWithValue("@task_id", task.Id);
        }
        else
        {
            
            query = @"            
            INSERT INTO tasks(student_id, title, description, due_date, completed, priority, category, recurrence, created_at, updated_at, completed_at)
            VALUES (@StudentId, @Title, @Description, @DueDate, @Completed, @priority, @Category, @recurrence, @CreatedAt, @UpdatedAt, @CompletedAt)
            ";
        }

        cmd.CommandText = query;
        
        cmd.Parameters.AddWithValue("@StudentId", task.StudentId);
        cmd.Parameters.AddWithValue("@Title", task.Title);
        cmd.Parameters.AddWithValue("@Description", (object?)task.Description ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@DueDate", task.DueDate);
        cmd.Parameters.AddWithValue("@Completed", task.Completed);
        cmd.Parameters.AddWithValue("@priority", task.Priority.HasValue ? (object)(int)task.Priority.Value : DBNull.Value);
        cmd.Parameters.AddWithValue("@recurrence", task.Recurrence.HasValue ? (object)(int)task.Recurrence.Value : DBNull.Value);
        cmd.Parameters.AddWithValue("@Category", (object?)task.Category ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@CreatedAt", task.CreatedAt);
        cmd.Parameters.AddWithValue("@UpdatedAt", task.UpdatedAt);
        cmd.Parameters.AddWithValue("@CompletedAt", (object?)task.CompletedAt ?? DBNull.Value);

        

        cmd.ExecuteNonQuery();

        
        if (task.Id > 0)
        {
            using var resetSeq = new NpgsqlCommand(
                "SELECT setval('tasks_task_id_seq', (SELECT MAX(task_id) FROM tasks))\n",
                conn);
            resetSeq.ExecuteNonQuery();
        }
    }

    public TaskItem? GetById(int taskId)
    {
        using var conn = Database.Connect();

        if (!TaskExists(taskId, conn))
        {
            Console.WriteLine("Task does not exist!");
            return null;
        }

        using var cmd = new NpgsqlCommand(
            @"SELECT * FROM tasks WHERE task_id = @id", conn);
        cmd.Parameters.AddWithValue("@id", taskId);

        using var reader = cmd.ExecuteReader();

        if (!reader.Read())
            return null;
        return new TaskItem(
                Id: reader.GetInt32(reader.GetOrdinal("task_id")),
                StudentId: reader.GetInt32(reader.GetOrdinal("student_id")),
                Title: reader.GetString(reader.GetOrdinal("title")),
                Description: reader.IsDBNull(reader.GetOrdinal("description")) ? null : reader.GetString(reader.GetOrdinal("description")),
                DueDate: reader.GetDateTime(reader.GetOrdinal("due_date")),
                Completed: reader.GetBoolean(reader.GetOrdinal("completed")),
                Priority: reader.IsDBNull(reader.GetOrdinal("priority")) ? null : (Priority?)reader.GetInt32(reader.GetOrdinal("priority")),
                Category: reader.IsDBNull(reader.GetOrdinal("category")) ? null : reader.GetString(reader.GetOrdinal("category")),
                Recurrence: reader.IsDBNull(reader.GetOrdinal("recurrence")) ? null : (Recurrence?)reader.GetInt32(reader.GetOrdinal("recurrence")),
                CreatedAt: reader.GetDateTime(reader.GetOrdinal("created_at")),
                UpdatedAt: reader.GetDateTime(reader.GetOrdinal("updated_at")),
                CompletedAt: reader.IsDBNull(reader.GetOrdinal("completed_at")) ? null : reader.GetDateTime(reader.GetOrdinal("completed_at"))
            );

        
    }


    public IEnumerable<TaskItem> GetAll()
    {
        using var conn = Database.Connect();
        using var cmd = new NpgsqlCommand("SELECT * FROM tasks ORDER BY task_id", conn);
        using var reader = cmd.ExecuteReader();

        var tasks = new List<TaskItem>();

        while (reader.Read())
        {
            var task = new TaskItem(
                Id: reader.GetInt32(reader.GetOrdinal("task_id")),
                StudentId: reader.GetInt32(reader.GetOrdinal("student_id")),
                Title: reader.GetString(reader.GetOrdinal("title")),
                Description: reader.IsDBNull(reader.GetOrdinal("description")) ? null : reader.GetString(reader.GetOrdinal("description")),
                DueDate: reader.GetDateTime(reader.GetOrdinal("due_date")),
                Completed: reader.GetBoolean(reader.GetOrdinal("completed")),
                Priority: reader.IsDBNull(reader.GetOrdinal("priority")) ? null : (Priority?)reader.GetInt32(reader.GetOrdinal("priority")),
                Category: reader.IsDBNull(reader.GetOrdinal("category")) ? null : reader.GetString(reader.GetOrdinal("category")),
                Recurrence: reader.IsDBNull(reader.GetOrdinal("recurrence")) ? null : (Recurrence?)reader.GetInt32(reader.GetOrdinal("recurrence")),
                CreatedAt: reader.GetDateTime(reader.GetOrdinal("created_at")),
                UpdatedAt: reader.GetDateTime(reader.GetOrdinal("updated_at")),
                CompletedAt: reader.IsDBNull(reader.GetOrdinal("completed_at")) ? null : reader.GetDateTime(reader.GetOrdinal("completed_at"))

            );


            tasks.Add(task);
        }

        return tasks;    }

    public IEnumerable<TaskItem> GetByStudentId(int studentId)
    {
        using var conn = Database.Connect();

        using var cmd = new NpgsqlCommand(
            @"SELECT * FROM tasks WHERE student_id = @studentId ORDER BY due_date", conn);
        cmd.Parameters.AddWithValue("@studentId", studentId);

        using var reader = cmd.ExecuteReader();

        var tasks = new List<TaskItem>();

        while (reader.Read())
        {
            tasks.Add(new TaskItem(
                Id: reader.GetInt32(reader.GetOrdinal("task_id")),
                StudentId: reader.GetInt32(reader.GetOrdinal("student_id")),
                Title: reader.GetString(reader.GetOrdinal("title")),
                Description: reader.IsDBNull(reader.GetOrdinal("description")) ? null : reader.GetString(reader.GetOrdinal("description")),
                DueDate: reader.GetDateTime(reader.GetOrdinal("due_date")),
                Completed: reader.GetBoolean(reader.GetOrdinal("completed")),
                Priority: reader.IsDBNull(reader.GetOrdinal("priority")) ? null : (Priority)reader.GetInt32(reader.GetOrdinal("priority")),
                Category: reader.IsDBNull(reader.GetOrdinal("category")) ? null : reader.GetString(reader.GetOrdinal("category")),
                Recurrence: reader.IsDBNull(reader.GetOrdinal("recurrence")) ? null : Enum.Parse<Recurrence>(reader.GetString(reader.GetOrdinal("recurrence"))),
                CreatedAt: reader.GetDateTime(reader.GetOrdinal("created_at")),
                UpdatedAt: reader.GetDateTime(reader.GetOrdinal("updated_at")),
                CompletedAt: reader.IsDBNull(reader.GetOrdinal("completed_at")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("completed_at"))
            ));
        }

        return tasks;
    }


    public void Update(TaskItem task)
    {
        using var conn = Database.Connect();

        if (!TaskExists(task.Id, conn))
        {
            Console.WriteLine("Task does not exist!");
            return;
        }

        using var cmd = new NpgsqlCommand(@"
        UPDATE tasks
        SET student_id = @StudentId,
            title = @Title,
            description = @Description,
            due_date = @DueDate,
            completed = @Completed,
            priority = @Priority,
            category = @Category,
            recurrence = @Recurrence,
            created_at = @CreatedAt,
            updated_at = @UpdatedAt,
            completed_at = @CompletedAt
        WHERE task_id = @Id;
    ", conn);

        cmd.Parameters.AddWithValue("@StudentId", task.StudentId);
        cmd.Parameters.AddWithValue("@Title", task.Title);
        cmd.Parameters.AddWithValue("@Description", (object?)task.Description ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@DueDate", task.DueDate);
        cmd.Parameters.AddWithValue("@Completed", task.Completed);
        cmd.Parameters.AddWithValue("priority", task.Priority.HasValue ? (object)(int)task.Priority.Value : DBNull.Value);
        cmd.Parameters.AddWithValue("recurrence", task.Recurrence.HasValue ? (object)(int)task.Recurrence.Value : DBNull.Value);
        cmd.Parameters.AddWithValue("@Category", (object?)task.Category ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@CreatedAt", task.CreatedAt);
        cmd.Parameters.AddWithValue("@UpdatedAt", task.UpdatedAt);
        cmd.Parameters.AddWithValue("@CompletedAt", (object?)task.CompletedAt ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Id", task.Id);


        cmd.ExecuteNonQuery();
    }


    public void Delete(int task_id)
    {
        using var conn = Database.Connect();

        if (!TaskExists(task_id, conn))
        {
            Console.WriteLine("Task does not exists!");
            return;
        }
        
        using var cmd = new NpgsqlCommand(@"
                DELETE FROM tasks WHERE task_id = @id"
            , conn);
        
        cmd.Parameters.AddWithValue("@id", task_id);
        
        cmd.ExecuteNonQuery();    
    }
}