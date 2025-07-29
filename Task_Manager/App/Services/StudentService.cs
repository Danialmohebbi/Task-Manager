using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
using Task_Manager.App.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.App.Services;
/// <summary>
/// Handles Logic for student registeration, login, otp verification and updating a student
/// </summary>
public class StudentService
{
    private readonly IStudentRepository _repo;

    private readonly Dictionary<string, (string otp, DateTime expiryDate)> _otpStore = new();

    public StudentService(IStudentRepository repo)
    {
        _repo = repo;
    }

    /// <summary>
    /// Handles the logic for registering a student.
    /// </summary>
    /// <param name="student"></param>
    /// <returns></returns>
    public bool Register(Student student)
    {
        if (UserExists(student.Email) || UserExists(student.Username))
            return false;

        _repo.Add(student);
        return true;
    }
    

    /// <summary>
    /// Check if a user already exists
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    public bool UserExists(string login)
    {
        return (from s in _repo.GetAll()
            where s.Email.Equals(login, StringComparison.OrdinalIgnoreCase) ||
                  s.Username.Equals(login, StringComparison.OrdinalIgnoreCase)
            select s).Any();
    }
    /// <summary>
    /// Get the student in the repository using their email or username
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    public Student? GetUserByLogin(string login)
    {
        return (from s in _repo.GetAll()
            where s.Email.Equals(login, StringComparison.OrdinalIgnoreCase) ||
                  s.Username.Equals(login, StringComparison.OrdinalIgnoreCase)
            select s).FirstOrDefault();
    }
    /// <summary>
    /// Handle the logic for logging in
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public bool Login(string login, string password)
    {
        var student = GetUserByLogin(login);
        return student != null && student.Password == password;
    }
    
    /// <summary>
    /// Generates an OTP
    /// </summary>
    /// <returns></returns>
    public string GenerateOtp() => new Random()
        .Next(100000, 999999)
        .ToString(); 
    
    /// <summary>
    /// Stores the OTP with the user who wants to user it
    /// </summary>
    /// <param name="login"></param>
    /// <param name="otp"></param>
    public void StoreOtp(string login, string otp)
    {
        _otpStore[login] = (otp, DateTime.Now.AddSeconds(60)); 
    }
    /// <summary>
    /// Verify the OTP
    /// </summary>
    /// <param name="login"></param>
    /// <param name="inputOtp"></param>
    /// <returns></returns>
    public bool VerifyOtp(string login, string inputOtp)
    {
        if (_otpStore.TryGetValue(login, out var data))
        {
            return data.otp == inputOtp && DateTime.Now <= data.expiryDate;
        }

        return false;
    }
    /// <summary>
    /// Update a student in the repository
    /// </summary>
    /// <param name="student"></param>
    public void Edit(Student student)
    {
        _repo.Update(student);
    }
    /// <summary>
    /// Extract info needed for sending email
    /// </summary>
    /// <returns></returns>
    static SmptInfo GetInfo()
    {
        string curDir = AppContext.BaseDirectory;
        string root = Path.GetFullPath(Path.Combine(curDir, "..", "..", ".."));
        string path = Path.Combine(root, "Config", "smpt.json");
        string output = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<SmptInfo>(output);
    }
    /// <summary>
    /// Handle the email sending logic
    /// </summary>
    /// <param name="login"></param>
    /// <param name="otp"></param>
    /// <returns></returns>
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