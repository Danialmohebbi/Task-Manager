using Task_Manager.App.Interfaces;

namespace Task_Manager.App.Services;

public class TaskService
{
    private readonly ITaskRepository _repo;

    public TaskService(ITaskRepository repo)
    {
        _repo = repo;
    }

}