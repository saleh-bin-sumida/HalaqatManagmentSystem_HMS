using InstitutionManagmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepositoryWithUOW.Core.Interfaces;

public class StudentsController(IUnitOfWork _unitOfWork) : Controller
{
    // GET: /Students
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var students = await _unitOfWork.Students.GetAllAsync(["Halaqa"]);
        return View(students);
    }

    // GET: /Students/Details/5
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var student = await _unitOfWork.Students.Find(x => x.Id == id, ["Halaqa"]);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    // GET: /Students/Create
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var halaqat = await _unitOfWork.Halaqat.GetAllAsync();

        ViewBag.Halaqat = new SelectList(halaqat, "Id", "Name");

        return View();
    }

    // POST: /Students/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Student student)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _unitOfWork.Students.Add(student);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Add error message to ModelState
                ModelState.AddModelError(string.Empty, "error occcured");
            }
        }

        // Repopulate the ViewBag.Teachers in case of error
        ViewBag.Halaqat = new SelectList(await _unitOfWork.Teachers.GetAllAsync(), "Id", "Name");
        return View(student);
    }

    // GET: /Students/Edit/5
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var student = await _unitOfWork.Students.Find(x => x.Id == id, ["Halaqa"]);
        if (student == null)
        {
            return NotFound();
        }
        ViewBag.Halaqat = new SelectList(await _unitOfWork.Halaqat.GetAllAsync(), "Id", "Name");

        return View(student);
    }

    // POST: /Students/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Student student)
    {
        if (id != student.Id)
        {
            return BadRequest();
        }
   

        if (ModelState.IsValid)
        {
            try
            {
                // Update the Halaqa entity
                await _unitOfWork.Students.Update(student);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log or handle the error
                ModelState.AddModelError(string.Empty, "error occured");
            }
        }
        ViewBag.Halaqat = new SelectList(await _unitOfWork.Teachers.GetAllAsync(), "Id", "Name");

        return View(student);
    }

    // GET: /Students/Delete/5
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _unitOfWork.Students.Find(x => x.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        await _unitOfWork.Students.Delete(id);
        return RedirectToAction(nameof(Index));
    }


}
