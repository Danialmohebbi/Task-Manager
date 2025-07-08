using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;
using Task_Manager.App.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.App.Services;

public class StudentService
{
    private readonly IStudentRepository _repo;

    private readonly Dictionary<string, (string otp, DateTime expiryDate)> _otpStore = new();

    public StudentService(IStudentRepository repo)
    {
        _repo = repo;
    }


    public bool Register(Student student)
    {
        if (UserExists(student.Email) || UserExists(student.Username))
            return false;

        _repo.Add(student);
        return true;
    }
    


    public bool UserExists(string login)
    {
        return (from s in _repo.GetAll()
            where s.Email.Equals(login, StringComparison.OrdinalIgnoreCase) ||
                  s.Username.Equals(login, StringComparison.OrdinalIgnoreCase)
            select s).Any();
    }

    public Student? GetUserByLogin(string login)
    {
        return (from s in _repo.GetAll()
            where s.Email.Equals(login, StringComparison.OrdinalIgnoreCase) ||
                  s.Username.Equals(login, StringComparison.OrdinalIgnoreCase)
            select s).FirstOrDefault();
    }

    public bool Login(string login, string password)
    {
        var student = GetUserByLogin(login);
        return student != null && student.Password == password;
    }
    
    
    public string GenerateOtp() => new Random()
        .Next(100000, 999999)
        .ToString(); 
    

    public void StoreOtp(string login, string otp)
    {
        _otpStore[login] = (otp, DateTime.Now.AddSeconds(60)); 
    }

    public bool VerifyOtp(string login, string inputOtp)
    {
        if (_otpStore.TryGetValue(login, out var data))
        {
            return data.otp == inputOtp && DateTime.Now <= data.expiryDate;
        }

        return false;
    }

    static SmptInfo GetInfo()
    {
        string curDir = AppContext.BaseDirectory;
        string root = Path.GetFullPath(Path.Combine(curDir, "..", "..", ".."));
        string path = Path.Combine(root, "JsonInput", "smpt.json");
        string output = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<SmptInfo>(output);
    }

    public bool SendEmail(string login, string otp)
    {
        var student = GetUserByLogin(login);
        if (student == null)
            return false;
        SmptInfo smpt = GetInfo();
        string toEmail = student.Email;
        string fromEmail = smpt.FromEmail;
        string password = smpt.Password; 
        string smtpHost = smpt.SmptHost;
        int smtpPort = smpt.SmptPort;
 
        using var client = new SmtpClient(smtpHost, smtpPort);
        client.Credentials = new NetworkCredential(fromEmail, password);
        client.EnableSsl = true;

        var message = new MailMessage(fromEmail, toEmail)
        {
            Subject = "Your OTP Code",
            Body = $"Your OTP code is: {otp}"
        };

        try
        {
            client.Send(message);
            return true;
        }
        catch
        {
            return false;
        }
    }

}