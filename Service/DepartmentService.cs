using StudentManagement.Models;

namespace StudentManagement.Service;

public interface DepartmentService
{
    Task<(bool isSuccess, string message)> create(Department department);
    Task<List<Department>> getAll();
}