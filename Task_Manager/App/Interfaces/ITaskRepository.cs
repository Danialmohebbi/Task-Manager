using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task_Manager.App.Interfaces;
using Task_Manager.Models;
/// <summary>
/// Defines CRUD Opreations for TaskItem Entities.
/// </summary>
public interface ITaskRepository
{
    /// <summary>
    /// Add a TaskItem to the repository.
    /// </summary>
    /// <param name="task"></param>
    void Add(TaskItem task);

    /// <summary>
    /// Get a TaskItem by using its ID from the repository.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    TaskItem GetById(int id);
    
    /// <summary>
    /// Get all the TaskItems in the repository.
    /// </summary>
    /// <returns>TaskItem</returns>
    IEnumerable<TaskItem> GetAll();
    
    /// <summary>
    /// Get the TaskItems of a student using their ID from the repository.
    /// </summary>
    /// <param name="studentId"></param>
    /// <returns>IEnumerable<TaskItem></returns>
    IEnumerable<TaskItem> GetByStudentId(int studentId);

    /// <summary>
    /// Update an existing TaskItem in the repository.
    /// </summary>
    /// <param name="task"></param>
    void Update(TaskItem task);

    /// <summary>
    /// Delete an existing TaskItem using its ID.
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
}