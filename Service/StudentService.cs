using StudentManagement.Models;

namespace StudentManagement.Service;

public interface StudentService
{
    Task<(bool isSuccess, string message)> addStudent(Student student);
}