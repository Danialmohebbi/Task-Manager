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


    public IEnumerable<TaskItem> FilterByPriority(IEnumerable<TaskItem> tasks, Priority? priority,bool reverse = false)
    {
        var query = (from t in tasks 
            where t.Priority == priority && t.Priority.HasValue select t).ToList();
        
        if (reverse)
            query.Reverse();
        return query;
    }
    
    public IEnumerable<TaskItem> FilterByRecurrence(IEnumerable<TaskItem> tasks, Recurrence? recurrence,bool reverse = false)
    {
        var query = (from t in tasks 
            where t.Recurrence == recurrence && t.Recurrence.HasValue select t).ToList();
        
        if (reverse)
            query.Reverse();
        return query;
    }
    
    public IEnumerable<TaskItem> FilterByCompleted(IEnumerable<TaskItem> tasks, bool completed,bool reverse = false)
    {
        var query = (from t in tasks 
            where t.Completed && completed  select t).ToList();
        
        if (reverse)
            query.Reverse();
        return query;
    }
    
    public IEnumerable<TaskItem> FilterByDueDateRange(IEnumerable<TaskItem> tasks, DateTime start, DateTime end, bool reverse = false)
    {
        var query = (from t in tasks 
            where t.DueDate >= start && t.DueDate <= end  select t).ToList();

        if (reverse) 
            query.Reverse();
        return query;
    }
    
    public IEnumerable<TaskItem> FilterByKeyword(IEnumerable<TaskItem> tasks, string keyword, bool reverse = false)
    {
        var query = (from t in tasks 
            where !string.IsNullOrEmpty(t.Title) && t.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                || (!string.IsNullOrEmpty(t.Description) && t.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                select t).ToList();

        if (reverse) 
            query.Reverse();
        return query;
    }

    public IEnumerable<TaskItem> FilterOverdueTasks(IEnumerable<TaskItem> tasks, DateTime currentDate, bool reverse = false)
    {
        var notCompletedTasks = FilterByCompleted(tasks,false);
        var query = (from t in notCompletedTasks 
            where t.DueDate < currentDate select t).ToList();


        if (reverse) 
            query.Reverse();
        return query;
    }

    public IEnumerable<TaskItem> FilterByCompletedAtRange(IEnumerable<TaskItem> tasks, DateTime fromDateTime, DateTime toDateTime, bool reverse = false)
    {
        var query = (from t in tasks where t.CompletedAt.HasValue 
                                           && t.CompletedAt.Value >= fromDateTime 
                                           && t.CompletedAt.Value <= toDateTime 
                                           select t).ToList();

        if (reverse) 
            query.Reverse();
        return query;
    }

    
    
    public IEnumerable<TaskItem> FilterByCreatedDate(IEnumerable<TaskItem> tasks, DateTime lowerBound,bool reverse = false)
    {
        var query = (from t in tasks 
            where t.CreatedAt >= lowerBound  select t).ToList();
        
        if (reverse)
            query.Reverse();
        return query;
    }
    
    public IEnumerable<TaskItem> FilterByTag(IEnumerable<TaskItem> tasks, String tag,bool reverse = false)
    {
        var query = (from t in tasks 
                                where t.Category == tag  
                                select t).ToList();
        
        if (reverse)
            query.Reverse();
        return query;
    }
}