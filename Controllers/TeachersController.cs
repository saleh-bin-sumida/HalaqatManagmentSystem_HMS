using InstitutionManagmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using RepositoryWithUOW.Core.Interfaces; 



public class TeachersController(IUnitOfWork _unitOfWork) : Controller
{


    // GET: Teacher
    public async Task<IActionResult> Index()
    {
        var teachers = await _unitOfWork.Teachers.GetAllAsync(["Halaqa"]);
        return View(teachers);
    }

    // GET: Teacher/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var teacher = await _unitOfWork.Teachers.Find(x => x.Id == id, ["Halaqa"]);
        if (teacher == null)
        {
            return NotFound();
        }
        return View(teacher);
    }

    // GET: Teacher/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Teacher/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Teacher teacher)
    {
        if (ModelState.IsValid)
        {
            await _unitOfWork.Teachers.Add(teacher);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
        return View(teacher);
    }

    // GET: Teacher/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var teacher = await _unitOfWork.Teachers.Find(x => x.Id == id);
        if (teacher == null)
        {
            return NotFound();
        }
        return View(teacher);
    }

    // POST: Teacher/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Teacher teacher)
    {
        if (id != teacher.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            _unitOfWork.Teachers.Update(teacher);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
        return View(teacher);
    }

    // GET: Teacher/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var teacher = await _unitOfWork.Teachers.Find(x => x.Id == id);
        if (teacher == null)
        {
            return NotFound();
        }

        _unitOfWork.Teachers.Delete(teacher.Id);
        _unitOfWork.Complete();
        TempData["DeleteMessage"] = "Teacher deleted successfully.";
        return RedirectToAction(nameof(Index));
    }

  
}

