using Task_Manager.App.Interfaces;
using Task_Manager.Models;
using Task = Task_Manager.Models.TaskItem;

namespace Task_Manager.App.Services;
/// <summary>
/// Handles Logic for viewing,adding,removing,editing tasks
/// </summary>
public class TaskService
{
    private readonly ITaskRepository _repo;
    
    public TaskService(ITaskRepository repo)
    {
        _repo = repo;
    }

    /// <summary>
    /// View the tasks in the repository related to a student/
    /// </summary>
    /// <param name="studentId"></param>
    /// <returns></returns>
    public IEnumerable<TaskItem> ViewTasks(int studentId) => _repo.GetByStudentId(studentId);
    /// <summary>
    /// Check if a task exists.
    /// </summary>
    /// <param name="taskId"></param>
    /// <param name="studentId"></param>
    /// <returns></returns>
    public bool TaskExists(int taskId, int studentId)
    {
        return (from t in ViewTasks(studentId)
                where t.Id == taskId
                select t
            ).Any();
    }
    /// <summary>
    /// Handle the logic for adding a task to the repository.
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    public bool AddTask(Task task)
    {
        if (TaskExists(task.Id, task.StudentId))
        {
            return false;
        }
        _repo.Add(task);
        return true;
    }
    /// <summary>
    /// Mark a task in the repository as completed.
    /// </summary>
    /// <param name="taskId"></param>
    /// <returns></returns>
    public bool MarkTaskDone(int taskId)
    {
        var task = _repo.GetById(taskId);

        DateTime temp = DateTime.Now;
        
        _repo.Update(task with
        {
            Completed = true,
            UpdatedAt = temp,
            CompletedAt = temp
        });
        return true;
    }
    /// <summary>
    /// Edit a task in the repository.
    /// </summary>
    /// <param name="updatedTask"></param>
    /// <returns></returns>
    public bool EditTask(Task updatedTask)
    {
        var existing = _repo.GetById(updatedTask.Id);
        if (existing == null) return false;

        _repo.Update(updatedTask);
        return true;
    }


    /// <summary>
    /// Delete a task in the repository given its task_id and the student_id
    /// </summary>
    /// <param name="taskId"></param>
    /// <param name="studentId"></param>
    /// <returns></returns>
    public bool DeleteTask(int taskId, int studentId)
    {
        if (!TaskExists(taskId, studentId))
        {
            return false;
        }
        _repo.Delete(taskId);
        return true;
    }


}