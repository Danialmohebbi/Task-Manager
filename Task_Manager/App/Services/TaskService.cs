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

    
    public IEnumerable<Models.TaskItem> ViewTasks(int student_id) => _repo.GetByStudentId(student_id);

    public bool TaskExists(int task_id, int student_id)
    {
        return (from t in ViewTasks(student_id)
                where t.Id == task_id
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

    public bool MarkTaskDone(int task_id)
    {
        var task = _repo.GetById(task_id);
        if (task == null)
            return false;

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



    public bool DeleteTask(int task_id, int student_id)
    {
        if (!TaskExists(task_id, student_id))
        {
            return false;
        }
        _repo.Delete(task_id);
        return true;
    }
}