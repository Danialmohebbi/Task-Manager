namespace Task_Manager.Models;

public struct SmptInfo
{
    public String FromEmail { get; set; }
    public String Password { get; set; }
    public String SmptHost { get; set; }
    public int SmptPort { get; set; }
    
}