using System;

namespace Task_Manager.Data;
using Npgsql;
public class Database
{
    private static string ConnectionString = 
            "Host=studentdb.cfmui6es8ks2.eu-north-1.rds.amazonaws.com;Port=5432;Username=postgres;Password=WEEK71234;Database=postgres;SSL Mode=Require;Trust Server Certificate=true"
        ;
    
    public static NpgsqlConnection Connect()
    {
        var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();
        return conn;
    }

    public static void Initialize()
    {
        using var conn = Connect();
        using var studentTable = new NpgsqlCommand(
            @"CREATE TABLE IF NOT EXISTS students (
                        student_id SERIAL PRIMARY KEY,
                        first_name VARCHAR(50) NOT NULL,
                        last_name VARCHAR(50),
                        email VARCHAR(100) UNIQUE NOT NULL CHECK (email ~* '^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$'),
                        username VARCHAR(100) UNIQUE NOT NULL,
                        password_hash VARCHAR(255) NOT NULL);"
            ,conn);
        studentTable.ExecuteNonQuery();

        using var tasksTable = new NpgsqlCommand(@"
                    CREATE TABLE IF NOT EXISTS tasks (
                        task_id SERIAL PRIMARY KEY,
                        student_id INT NOT NULL,
                        title VARCHAR(100) NOT NULL,
                        description TEXT,
                        due_date TIMESTAMP NOT NULL,                       
                        completed BOOLEAN DEFAULT FALSE,
                        priority INT,                                    
                        category VARCHAR(100),
                        recurrence VARCHAR(50),
                        created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
                        updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
                        completed_at TIMESTAMP,
                        FOREIGN KEY (student_id) REFERENCES students(student_id) ON DELETE CASCADE
                    );", conn); 
        
        tasksTable.ExecuteNonQuery();

    }

    public static void ShowStudents()
    {
        using var conn = Connect();
        
        using var cmd = new NpgsqlCommand("SELECT * FROM students ORDER BY student_id", conn);
        using var reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["student_id"]}, {reader["first_name"]}, {reader["last_name"]}," +
                $" {reader["email"]}, {reader["username"]}, {reader["password_hash"]}" +
                $""
                );
        }
    }
    
    public static void ShowTasks()
    {
        using var conn = Connect();

        using var cmd = new NpgsqlCommand("SELECT * FROM tasks ORDER BY task_id", conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["task_id"]}, {reader["student_id"]}, {reader["title"]}, " +
                $"{reader["description"]}, {reader["due_date"]}, {reader["completed"]}, " +
                $"{reader["priority"]}, {reader["category"]}, {reader["recurrence"]}, " +
                $"{reader["created_at"]}, {reader["updated_at"]}, {reader["completed_at"]}"
            );
        }
    }

}