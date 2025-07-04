using System;
using System.Collections.Generic;
using Npgsql;
using Task_Manager.App.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.Data.Repositories;

public class StudentRepository : IStudentRepository
{
    private bool StudentExists(int id, NpgsqlConnection conn)
    {
        using var checkCmd = new NpgsqlCommand(
            "SELECT COUNT(*) FROM students WHERE student_id = @id"
            , conn);
        
        checkCmd.Parameters.AddWithValue("@id", id);
        
        var existingStudentCount = (long)checkCmd.ExecuteScalar();
        
        return existingStudentCount > 0; 
    }
    
    public void Add(Student student)
    {
        using var conn = Database.Connect();

        if (StudentExists(student.Id, conn))
        {
            Console.WriteLine("Student already exists!");
            return;
        }

        string query;
        var cmd = new NpgsqlCommand();
        cmd.Connection = conn;

        if (student.Id > 0)
        {
            
            query = @"
            INSERT INTO students(student_id, first_name, last_name, email, username, password_hash)
            VALUES (@Id, @FirstName, @LastName, @Email, @Username, @PasswordHash)
            ";
            cmd.Parameters.AddWithValue("@Id", student.Id);
        }
        else
        {
            
            query = @"
            INSERT INTO students(first_name, last_name, email, username, password_hash)
            VALUES (@FirstName, @LastName, @Email, @Username, @PasswordHash)
            ";
        }

        cmd.CommandText = query;

        cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
        cmd.Parameters.AddWithValue("@LastName", student.LastName);
        cmd.Parameters.AddWithValue("@Email", student.Email);
        cmd.Parameters.AddWithValue("@Username", student.Username);
        cmd.Parameters.AddWithValue("@PasswordHash", student.Password);

        cmd.ExecuteNonQuery();

        
        if (student.Id > 0)
        {
            using var resetSeq = new NpgsqlCommand(
                "SELECT setval('students_student_id_seq', (SELECT MAX(student_id) FROM students))",
                conn);
            resetSeq.ExecuteNonQuery();
        }
    }


    public Student? GetById(int student_id)
    {
        using var conn = Database.Connect();

        if (!StudentExists(student_id, conn))
        {
            Console.WriteLine("Student does not exist!");
            return null;
        }
        
        using var cmd = new NpgsqlCommand(
            @"SELECT * FROM students WHERE student_id = @id"
            , conn);   
        cmd.Parameters.AddWithValue("@id", student_id);
        using var reader = cmd.ExecuteReader();
        reader.Read();
        return new Student(
            Id: reader.GetInt32(reader.GetOrdinal("student_id")),
            FirstName: reader.GetString(reader.GetOrdinal("first_name")),
            LastName: reader.GetString(reader.GetOrdinal("last_name")),
            Email: reader.GetString(reader.GetOrdinal("email")),
            Username: reader.GetString(reader.GetOrdinal("username")),
            Password: reader.GetString(reader.GetOrdinal("password_hash"))
        );
    }

    public IEnumerable<Student> GetAll()
    {
        using var conn = Database.Connect();
        using var cmd = new NpgsqlCommand("SELECT * FROM students ORDER BY student_id", conn);
        using var reader = cmd.ExecuteReader();

        var students = new List<Student>();

        while (reader.Read())
        {
            var student = new Student(
                reader.GetInt32(reader.GetOrdinal("student_id")),
                reader.GetString(reader.GetOrdinal("first_name")),
                reader.GetString(reader.GetOrdinal("last_name")),
                reader.GetString(reader.GetOrdinal("email")),
                reader.GetString(reader.GetOrdinal("username")),
                reader.GetString(reader.GetOrdinal("password_hash"))
            );

            students.Add(student);
        }

        return students;
    }


    public void Update(Student student)
    {
        using var conn = Database.Connect();

        if (!StudentExists(student.Id, conn))
        {
            Console.WriteLine("Student does not exist!");
            return;
        }

        using var cmd = new NpgsqlCommand(@"
            UPDATE students
            SET first_name = @FirstName,
                last_name = @LastName,
                email = @Email,
                username = @Username,
                password_hash = @PasswordHash
            WHERE student_id = @Id;
        ", conn);

        cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
        cmd.Parameters.AddWithValue("@LastName", student.LastName);
        cmd.Parameters.AddWithValue("@Email", student.Email);
        cmd.Parameters.AddWithValue("@Username", student.Username);
        cmd.Parameters.AddWithValue("@PasswordHash", student.Password);
        cmd.Parameters.AddWithValue("@Id", student.Id);

        cmd.ExecuteNonQuery();
    }


    public void Delete(int student_id)
    {
        using var conn = Database.Connect();

        if (!StudentExists(student_id, conn))
        {
            Console.WriteLine("Student does not exists!");
            return;
        }
        
        using var cmd = new NpgsqlCommand(@"
                DELETE FROM students WHERE student_id = @id"
            , conn);
        
        cmd.Parameters.AddWithValue("@id", student_id);
        
        cmd.ExecuteNonQuery();
    }
}