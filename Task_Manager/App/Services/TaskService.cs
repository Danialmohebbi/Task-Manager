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
        var NotCompletedTasks = FilterByCompleted(tasks,false,false);
        var query = (from t in NotCompletedTasks 
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

    
    
    public IEnumerable<TaskItem> FilterByCreatedDate(IEnumerable<TaskItem> tasks, DateTime LowerBound,bool reverse = false)
    {
        var query = (from t in tasks 
            where t.CreatedAt >= LowerBound  select t).ToList();
        
        if (reverse)
            query.Reverse();
        return query;
    }
    
    public IEnumerable<TaskItem> FilterByTag(IEnumerable<TaskItem> tasks, String Tag,bool reverse = false)
    {
        var query = (from t in tasks 
                                where t.Category == Tag  
                                select t).ToList();
        
        if (reverse)
            query.Reverse();
        return query;
    }
}