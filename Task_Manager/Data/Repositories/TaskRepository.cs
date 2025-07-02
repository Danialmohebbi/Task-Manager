using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Manager.App.Interfaces;

namespace Task_Manager.Data.Repositories;

public class TaskRepository : ITaskRepository
{
    public void Add(Task task)
    {
        throw new NotImplementedException();
    }

    public Task GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Task> GetAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Task> GetByStudentId(int studentId)
    {
        throw new NotImplementedException();
    }

    public void Update(Task task)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}