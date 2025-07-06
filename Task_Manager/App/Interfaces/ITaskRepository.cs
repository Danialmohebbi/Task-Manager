using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task_Manager.App.Interfaces;
using Task_Manager.Models;

public interface ITaskRepository
{
    // CREATE
    void Add(TaskItem task);

    // READ
    TaskItem GetById(int id);
    IEnumerable<TaskItem> GetAll();
    IEnumerable<TaskItem> GetByStudentId(int studentId);

    // UPDATE
    void Update(TaskItem task);

    // DELETE
    void Delete(int id);
}