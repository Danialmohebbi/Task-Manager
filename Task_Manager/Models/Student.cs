using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task_Manager.Models;

public record class Student(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Username,
    string Password
);

