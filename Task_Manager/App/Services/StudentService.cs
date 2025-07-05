using System.Net;
using System.Net.Mail;
using Task_Manager.App.Interfaces;
using Task_Manager.Models;

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

    private Student? GetUserByLogin(string login)
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
    
    
    public string GenerateOTP() => new Random()
                                    .Next(100000, 999999)
                                    .ToString(); 
    

    public void StoreOTP(string login, string otp)
    {
        _otpStore[login] = (otp, DateTime.Now.AddSeconds(60)); 
    }

    public bool VerifyOTP(string login, string inputOtp)
    {
        if (_otpStore.TryGetValue(login, out var data))
        {
            return data.otp == inputOtp && DateTime.Now <= data.expiryDate;
        }

        return false;
    }

    public bool SendEmail(string login, string otp)
    {
        var student = GetUserByLogin(login);
        if (student == null)
            return false;

        string toEmail = student.Email;
        string fromEmail = "daniyalmohebbi@yahoo.com";
        string password = "fprxmgqdcklfbzlq"; 
        string smtpHost = "smtp.mail.yahoo.com";
        int smtpPort = 587;
 
        using var client = new SmtpClient(smtpHost, smtpPort)
        {
            Credentials = new NetworkCredential(fromEmail, password),
            EnableSsl = true
        };

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
