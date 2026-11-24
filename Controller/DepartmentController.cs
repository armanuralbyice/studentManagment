using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.Service;

namespace StudentManagement.Controllers;

public class DepartmentController : Controller
{
    private readonly DepartmentService _departmentService;

    public DepartmentController(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Department department)
    {
        var (isSuccess, message) = await _departmentService.create(department);

        if (!isSuccess)
        {
            ViewBag.ErrorMessage = message;
            return View(department);
        }

        TempData["SuccessMessage"] = message;
        return RedirectToAction(nameof(Create));
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var departments = await _departmentService.getAll();
        return View(departments);
    }
}