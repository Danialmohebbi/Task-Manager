namespace Task_Manager.App.Interfaces;
using Task_Manager.Models;

public interface ITaskRepository
{
    // CREATE
    void Add(Task task);

    // READ
    Task GetById(int id);
    IEnumerable<Task> GetAll();
    IEnumerable<Task> GetByStudentId(int studentId);

    // UPDATE
    void Update(Task task);

    // DELETE
    void Delete(int id);
}