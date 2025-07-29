namespace Task_Manager.Models;
/// <summary>
/// Represents the Student.
/// </summary>
/// <param name="Id"></param>
/// <param name="FirstName"></param>
/// <param name="LastName"></param>
/// <param name="Email"></param>
/// <param name="Username"></param>
/// <param name="Password"></param>
public record Student(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Username,
    string Password
);

