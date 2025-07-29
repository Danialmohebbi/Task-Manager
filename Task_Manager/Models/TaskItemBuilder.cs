namespace Task_Manager.Models;
/// <summary>
/// Defines methods to incrementally build a TaskItem object.
/// </summary>
public interface ITaskItemBuilder
{
    void SetId(int id);
    void SetStudentId(int studentId);
    void SetPriority(Priority? priority);
    void SetCategory(string category);
    void SetRecurrence(Recurrence? recurrence);
    void SetTitle(string title);
    void SetDescription(string? description);
    void SetCompleted(bool completed);
    void SetCompletedDate(DateTime? completedDate);
    void SetCreatedDate(DateTime createdDate);
    void SetUpdatedDate(DateTime updatedDate);
    void SetDueDate(DateTime dueDate);
    
    TaskItem GetTaskItem();
}

/// <summary>
/// Implements the ITaskItembuilder interface to build a TaskItem Object with validation.
/// </summary>
public class TaskItemBuilder : ITaskItemBuilder
{
    int _id;
    int _studentId;
    Priority? _priority;
    string? _category;
    string _title;
    string? _description;
    DateTime? _completedDate;
    DateTime _createdDate;
    DateTime _updatedDate;
    DateTime _dueDate;
    bool _completed;
    Recurrence? _recurrence;
    
    public void SetId(int id) => _id = id;
    public void SetStudentId(int studentId) => _studentId = studentId;
    public void SetPriority(Priority? priority) => _priority = priority;
    public void SetCategory(string category) => _category = category;
    public void SetTitle(string title) => _title = title;
    public void SetDescription(string? description) => _description = description;
    public void SetCompleted(bool completed) => _completed = completed;
    public void SetCompletedDate(DateTime? completedDate) => _completedDate = completedDate;
    public void SetCreatedDate(DateTime createdDate) => _createdDate = createdDate;
    public void SetUpdatedDate(DateTime updatedDate) => _updatedDate = updatedDate;
    public void SetDueDate(DateTime dueDate) => _dueDate = dueDate;
    public void SetRecurrence(Recurrence? recurrence) => _recurrence = recurrence;

    public TaskItem GetTaskItem() => new
        TaskItem(
            _id,
            _studentId,
            _title,
            _description,
            _dueDate,
            _completed,
            _priority,
            _category,
            _recurrence,
            _createdDate,
            _updatedDate,
            _completedDate
        );
}