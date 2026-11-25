using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.Service.impl;

public class StudentServiceImpl : StudentService
{
    private readonly MongoDbContext  _dbContext;

    public StudentServiceImpl(MongoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<(bool isSuccess, string message)> addStudent(Student student)
    {
        await _dbContext.Students.InsertOneAsync(student);
        return (true, "Student added successfully");
    }
}