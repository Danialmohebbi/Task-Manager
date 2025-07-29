namespace Task_Manager.Models;

/// <summary>
/// Defines methods to incrementally build a Student object.
/// </summary>
public interface IStudentBuilder
{
    void SetId(int id);
    void SetFirstName(string firstName);
    void SetLastName(string lastName);
    void SetEmail(string email);
    void SetUsername(string username);
    void SetPassword(string password);
    
    Student GetStudent();
}

/// <summary>
/// Implements the IStudentBuilder interface to build a Student Object with validation.
/// </summary>
public class StudentBuilder : IStudentBuilder
{
    private int _id;
    private string _firstName;
    private string _lastName;
    private string _email;
    private string _username;
    private string _password;
    
    public void SetId(int id) => _id = id;
    public void SetFirstName(string firstName) => _firstName = firstName;
    public void SetLastName(string lastName) => _lastName = lastName;
    public void SetEmail(string email) => _email = email;
    public void SetUsername(string username) => _username = username;
    public void SetPassword(string password) => _password = password;

    public Student GetStudent()
    {
        if (string.IsNullOrWhiteSpace(_username))
            throw new InvalidOperationException("Username cannot be empty");
        if (string.IsNullOrWhiteSpace(_password))
            throw new InvalidOperationException("Password cannot be empty");
        if (string.IsNullOrWhiteSpace(_email))
            throw new InvalidOperationException("Email cannot be empty");
        if (string.IsNullOrWhiteSpace(_firstName))
            throw new InvalidOperationException("First name cannot be empty");
        if (string.IsNullOrWhiteSpace(_lastName))
            throw new InvalidOperationException("Last name cannot be empty");
        
        return new 
            Student(
                _id,
                _firstName, 
                _lastName, 
                _email, 
                _username, 
                _password
                );
    }
}