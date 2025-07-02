using System;
using System.Collections.Generic;
using Task_Manager.App.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.Data.Repositories;

public class StudentRepository : IStudentRepository
{
    public void Add(Student student)
    {
        throw new NotImplementedException();
    }

    public Student? GetById(int student_id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Student> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Update(Student student)
    {
        throw new NotImplementedException();
    }

    public void Delete(int student_id)
    {
        throw new NotImplementedException();
    }
}