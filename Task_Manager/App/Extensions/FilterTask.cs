using Task_Manager.Models;

namespace Task_Manager.App.Extensions;

public  static class FilterTask
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
            where t.Completed == completed  select t).ToList();
        
        if (reverse)
            query.Reverse();
        return query;
    }
    
    public static IEnumerable<TaskItem> FilterEarlistDueDates(this IEnumerable<TaskItem> tasks,bool reverse = false) {

        var query = (from t in tasks
                     orderby t.DueDate
                     select t).ToList();

        if (reverse)
            query.Reverse();
        return query;

    }

    public static IEnumerable<TaskItem> SortCompletedDate(this IEnumerable<TaskItem> tasks, bool reverse = false)
    {

        var query = (from t in tasks
                     orderby t.DueDate
                     select t).ToList();

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
        var query = (from t in tasks 
            where t.DueDate < currentDate select t).ToList();


        if (reverse) 
            query.Reverse();
        return query;
    }


    
    
    public static IEnumerable<TaskItem> FilterByCreatedDate(this IEnumerable<TaskItem> tasks, DateTime lowerBound,bool reverse = false)
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