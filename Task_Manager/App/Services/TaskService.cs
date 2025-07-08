using Task_Manager.App.Interfaces;
using Task_Manager.Models;
using Task = Task_Manager.Models.TaskItem;

namespace Task_Manager.App.Services;

public class TaskService
{
    private readonly ITaskRepository _repo;

    public TaskService(ITaskRepository repo)
    {
        _repo = repo;
    }

    
    public IEnumerable<TaskItem> ViewTasks(int studentId) => _repo.GetByStudentId(studentId);

    public bool TaskExists(int taskId, int studentId)
    {
        return (from t in ViewTasks(studentId)
                where t.Id == taskId
                select t
            ).Any();
    }
    public bool AddTask(Task task)
    {
        if (TaskExists(task.Id, task.StudentId))
        {
            return false;
        }
        _repo.Add(task);
        return true;
    }

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
    
    public bool EditTask(Task updatedTask)
    {
        var existing = _repo.GetById(updatedTask.Id);
        if (existing == null) return false;

        _repo.Update(updatedTask);
        return true;
    }



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