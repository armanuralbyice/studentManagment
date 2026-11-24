using MongoDB.Driver;
using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.Service.impl;

public class DepartmentServiceImpl : DepartmentService
{
    private readonly MongoDbContext db;

    public DepartmentServiceImpl(MongoDbContext db)
    {
        this.db = db;
    }

    public async Task<(bool isSuccess, string message)> create(Department department)
    {
        if (string.IsNullOrWhiteSpace(department.Name) || string.IsNullOrWhiteSpace(department.Code))
        {
            return (false, "Department name and Code are required");
        }
        await  db.Departments.InsertOneAsync(department);
        return (true, department.Name + " Department Created");
    }

    public async Task<List<Department>> getAll()
    {
        return await db.Departments.Find(x => true).ToListAsync();
    }
}