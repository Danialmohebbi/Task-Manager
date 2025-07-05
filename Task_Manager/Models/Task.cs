using System;

namespace Task_Manager.Models;

public record class Task(
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
