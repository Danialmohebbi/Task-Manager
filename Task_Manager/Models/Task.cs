namespace Task_Manager.Models;

public record class TaskItem(
    int Id,
    int StudentId,
    string Title,
    string Description,
    DateTime DueDate,
    bool Completed,
    int? Priority,             
    string? Category,
    string? Recurrence,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? CompletedAt       
);
