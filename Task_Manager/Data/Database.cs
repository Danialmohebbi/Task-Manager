namespace Task_Manager.Data;
using Npgsql;
public class Database
{
    private static string ConnectionString = "";
    
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
}