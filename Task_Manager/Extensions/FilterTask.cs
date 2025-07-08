using Task_Manager.Models;

namespace Task_Manager.Extensions;

public static class FilterTask
{
        public static IEnumerable<TaskItem> FilterByPriority(this IEnumerable<TaskItem> tasks, Priority? priority,bool reverse = false)
    {
        var query = (from t in tasks 
            where t.Priority == priority && t.Priority.HasValue select t).ToList();
        
        if (reverse)
            query.Reverse();
        return query;
    }
    
    public static IEnumerable<TaskItem> FilterByRecurrence(this IEnumerable<TaskItem> tasks, Recurrence? recurrence,bool reverse = false)
    {
        var query = (from t in tasks 
            where t.Recurrence == recurrence && t.Recurrence.HasValue select t).ToList();
        
        if (reverse)
            query.Reverse();
        return query;
    }
    
    public static IEnumerable<TaskItem> FilterByCompleted(this IEnumerable<TaskItem> tasks, bool completed,bool reverse = false)
    {
        var query = (from t in tasks 
            where t.Completed && completed  select t).ToList();
        
        if (reverse)
            query.Reverse();
        return query;
    }
    
    public static IEnumerable<TaskItem> FilterByDueDateRange(this IEnumerable<TaskItem> tasks, DateTime start, DateTime end, bool reverse = false)
    {
        var query = (from t in tasks 
            where t.DueDate >= start && t.DueDate <= end  select t).ToList();

        if (reverse) 
            query.Reverse();
        return query;
    }
    
    public static IEnumerable<TaskItem> FilterByKeyword(this IEnumerable<TaskItem> tasks, string keyword, bool reverse = false)
    {
        var query = (from t in tasks 
            where !string.IsNullOrEmpty(t.Title) && t.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                || (!string.IsNullOrEmpty(t.Description) && t.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                select t).ToList();

        if (reverse) 
            query.Reverse();
        return query;
    }

    public static IEnumerable<TaskItem> FilterOverdueTasks(this IEnumerable<TaskItem> tasks, DateTime currentDate, bool reverse = false)
    {
        var notCompletedTasks = FilterByCompleted(tasks,false);
        var query = (from t in notCompletedTasks 
            where t.DueDate < currentDate select t).ToList();


        if (reverse) 
            query.Reverse();
        return query;
    }

    public static IEnumerable<TaskItem> FilterByCompletedAtRange(this IEnumerable<TaskItem> tasks, DateTime fromDateTime, DateTime toDateTime, bool reverse = false)
    {
        var query = (from t in tasks where t.CompletedAt.HasValue 
                                           && t.CompletedAt.Value >= fromDateTime 
                                           && t.CompletedAt.Value <= toDateTime 
                                           select t).ToList();

        if (reverse) 
            query.Reverse();
        return query;
    }

    
    
    public static  IEnumerable<TaskItem> FilterByCreatedDate(this IEnumerable<TaskItem> tasks, DateTime lowerBound,bool reverse = false)
    {
        var query = (from t in tasks 
            where t.CreatedAt >= lowerBound  select t).ToList();
        
        if (reverse)
            query.Reverse();
        return query;
    }
    
    public static IEnumerable<TaskItem> FilterByTag(this IEnumerable<TaskItem> tasks, String tag,bool reverse = false)
    {
        var query = (from t in tasks 
                                where t.Category == tag  
                                select t).ToList();
        
        if (reverse)
            query.Reverse();
        return query;
    }
}