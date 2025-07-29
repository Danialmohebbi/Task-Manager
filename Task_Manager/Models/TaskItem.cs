namespace Task_Manager.Models;
/// <summary>
/// Represents a Task.
/// </summary>
/// <param name="Id"></param>
/// <param name="StudentId"></param>
/// <param name="Title"></param>
/// <param name="Description"></param>
/// <param name="DueDate"></param>
/// <param name="Completed"></param>
/// <param name="Priority"></param>
/// <param name="Category"></param>
/// <param name="Recurrence"></param>
/// <param name="CreatedAt"></param>
/// <param name="UpdatedAt"></param>
/// <param name="CompletedAt"></param>
public record TaskItem(
    int Id,
    int StudentId,
    string Title,
    string? Description,
    DateTime DueDate,
    bool Completed,
    Priority? Priority,             
    string? Category,
    Recurrence? Recurrence,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? CompletedAt       
);
