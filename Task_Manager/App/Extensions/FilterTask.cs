using Task_Manager.Models;

namespace Task_Manager.App.Extensions;

public  static class FilterTask
{
   /// <summary>
   /// Filters a collection of tasks with respect to a priority.
   /// </summary>
   /// <param name="tasks"></param>
   /// <param name="priority"></param>
   /// <param name="reverse"></param>
   /// <returns></returns>
    public static IEnumerable<TaskItem> FilterByPriority(this IEnumerable<TaskItem> tasks, Priority? priority,bool reverse = false)
    {
        var query = (from t in tasks 
            where t.Priority == priority && t.Priority.HasValue select t).ToList();
        
        if (reverse)
            query.Reverse();
        return query;
    }
    /// <summary>
    /// Filters a collection of tasks with respect to a recurrence.
    /// </summary>
    /// <param name="tasks"></param>
    /// <param name="recurrence"></param>
    /// <param name="reverse"></param>
    /// <returns></returns>
    public static IEnumerable<TaskItem> FilterByRecurrence(this IEnumerable<TaskItem> tasks, Recurrence? recurrence,bool reverse = false)
    {
        var query = (from t in tasks 
            where t.Recurrence == recurrence && t.Recurrence.HasValue select t).ToList();
        
        if (reverse)
            query.Reverse();
        return query;
    }

    /// <summary>
    /// Filters a collection of tasks with respect to completeness.
    /// </summary>
    /// <param name="tasks"></param>
    /// <param name="completed"></param>
    /// <param name="reverse"></param>
    /// <returns></returns>
    public static IEnumerable<TaskItem> FilterByCompleted(this IEnumerable<TaskItem> tasks, bool completed,
        bool reverse = false)
    {
        var query = (from t in tasks
            where t.Completed == completed
            select t).ToList();

        if (reverse)
            query.Reverse();
        return query;
    }

    /// <summary>
    /// Filters a collection of tasks with respect to a keyword.
    /// </summary>
    /// <param name="tasks"></param>
    /// <param name="keyword"></param>
    /// <param name="reverse"></param>
    /// <returns></returns>
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
    /// <summary>
    /// Filters overdue tasks out of a collection of tasks.
    /// </summary>
    /// <param name="tasks"></param>
    /// <param name="currentDate"></param>
    /// <param name="reverse"></param>
    /// <returns></returns>
    public static IEnumerable<TaskItem> FilterOverdueTasks(this IEnumerable<TaskItem> tasks, DateTime currentDate, bool reverse = false)
    {
        var query = (from t in tasks 
            where t.DueDate < currentDate select t).ToList();


        if (reverse) 
            query.Reverse();
        return query;
    }

    
    /// <summary>
    /// Filters a collection of tasks with respect to a tag.
    /// </summary>
    /// <param name="tasks"></param>
    /// <param name="tag"></param>
    /// <param name="reverse"></param>
    /// <returns></returns>
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