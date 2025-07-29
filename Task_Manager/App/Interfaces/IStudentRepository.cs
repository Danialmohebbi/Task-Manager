using System.Collections.Generic;
using Task_Manager.Models;

namespace Task_Manager.App.Interfaces;
/// <summary>
/// Defines CRUD Opreations for Student entities.
/// </summary>
public interface IStudentRepository
{
    /// <summary>
    /// Add a student to the repository.
    /// </summary>
    /// <param name="student"></param>
    void Add(Student student);
    
    /// <summary>
    /// Get a Student by their ID from the repository.
    /// </summary>
    /// <param name="student_id"></param>
    /// <returns></returns>
    Student? GetById(int student_id);
    /// <summary>
    /// Get all Student from the repository.
    /// </summary>
    /// <returns></returns>
    IEnumerable<Student> GetAll();
    
    /// <summary>
    /// Update an existing Student in the repository.
    /// </summary>
    /// <param name="student"></param>
    void Update(Student student);
    /// <summary>
    /// Delete a Student in the repository.
    /// </summary>
    /// <param name="student_id"></param>
    //DELETE
    void Delete(int student_id);
    
}