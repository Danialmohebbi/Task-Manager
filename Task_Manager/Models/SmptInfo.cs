namespace Task_Manager.Models;
/// <summary>
/// Represents the Smpt Info needed to send emails.
/// </summary>
public struct SmptInfo
{
    public String FromEmail { get; set; }
    public String Password { get; set; }
    public String SmptHost { get; set; }
    public int SmptPort { get; set; }
    
}