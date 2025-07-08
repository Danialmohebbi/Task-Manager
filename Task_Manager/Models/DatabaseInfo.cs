namespace Task_Manager.Models;

public struct DatabaseInfo
{
    public String Host { get; set; }
    public int Port { get; set; }
    public String Username { get; set; }
    public String Password { get; set; }
    public String Database { get; set; }
    public String SSL { get; set; }
    public Boolean ServerCertification { get; set; }
}