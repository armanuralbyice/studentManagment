using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagement.Models;
using StudentManagement.Service;

namespace StudentManagement.Controllers;

public class StudentController : Controller
{
    private readonly StudentService studentService;
    private readonly DepartmentService departmentService;

    public StudentController(StudentService studentService, DepartmentService departmentService)
    {
        this.studentService = studentService;
        this.departmentService = departmentService;
    }

    public async Task LoadDepartmentData(string? selectedDepartmentId = null)
    {
        var departments = await departmentService.getAll();
        ViewBag.Departments = new SelectList(departments, "Id", "Name", selectedDepartmentId);
    }
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await LoadDepartmentData();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Student student)
    {
        var (isSuccess, message) = await studentService.addStudent(student);
        if (!isSuccess)
        {
            ViewBag.ErrorMessage = message;
            await LoadDepartmentData(student.DepartmentId);
            return View(student);
        }
        TempData["successMessage"] = message;
        return RedirectToAction(nameof(Create));
    }
}