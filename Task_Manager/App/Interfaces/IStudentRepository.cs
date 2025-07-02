using Task_Manager.Models;

namespace Task_Manager.App.Interfaces;

//Follow CRUD
public interface IStudentRepository
{
    //CREATE
    void Add(Student student);
    
    //READ (SELECT)
    Student? GetById(int student_id);
    IEnumerable<Student> GetAll();
    
    //Update
    void Update(Student student);
    
    //DELETE
    void Delete(int student_id);
    
}