using Task_Manager.App.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.App.Services;

public class StudentService
{
    private readonly IStudentRepository _repo;

    public StudentService(IStudentRepository repo)
    {
        _repo = repo;
    }
    

    
}