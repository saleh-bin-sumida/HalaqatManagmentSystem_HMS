using InstitutionManagmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using RepositoryWithUOW.Core.Interfaces;



public class HalaqatController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public HalaqatController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: Halaqa
    public async Task<IActionResult> Index()
    {
        var halaqat = await _unitOfWork.Halaqat.GetAllAsync(["Teacher"]);
        return View(halaqat);
    }

    // GET: Halaqa/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var halaqa = await _unitOfWork.Halaqat.Find(x => x.Id == id, ["Teacher","Students"]);

        if (halaqa == null)
        {
            return NotFound();
        }

        return View(halaqa);
    }

    // GET: Halaqa/Create
    public async Task<IActionResult> Create()
    {
        var teachers = await _unitOfWork.Teachers.GetAllAsync();

        // Create a SelectList for the dropdown in the view
        ViewBag.Teachers = new SelectList(teachers, "Id", "FistName");
        return View();
    }

    // POST: Halaqa/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Halaqa halaqa)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _unitOfWork.Halaqat.Add(halaqa);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Add error message to ModelState
                ModelState.AddModelError(string.Empty, "This teacher is already linked to another halaqa.");
            }
        }

        // Repopulate the ViewBag.Teachers in case of error
        ViewBag.Teachers = new SelectList(await _unitOfWork.Teachers.GetAllAsync(), "Id", "FistName");
        return View(halaqa);
    }


    // GET: Halaqa/Edit/5
    //public async Task<IActionResult> Edit(int id)
    //{
    //    var halaqa = await _unitOfWork.Halaqat.Find(x => x.Id == id);
    //    if (halaqa == null)
    //    {
    //        return NotFound();
    //    }
    //    return View(halaqa);
    //}

    //// POST: Halaqa/Edit/5
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Edit(int id, Halaqa halaqa)
    //{
    //    if (id != halaqa.Id)
    //    {
    //        return NotFound();
    //    }

    //    if (ModelState.IsValid)
    //    {
    //        _unitOfWork.Halaqat.Update(halaqa);
    //         _unitOfWork.Complete();
    //        return RedirectToAction(nameof(Index));
    //    }
    //    return View(halaqa);
    //}
    public async Task<IActionResult> Edit(int id)
    {
        // Retrieve the halaqa entity by id
        var halaqa = await _unitOfWork.Halaqat.Find(x => x.Id == id);
        if (halaqa == null)
        {
            return NotFound();
        }

        // Populate the teachers dropdown
        ViewBag.Teachers = new SelectList(await _unitOfWork.Teachers.GetAllAsync(), "Id", "FistName", halaqa.TeacherId);

        return View(halaqa);
    }

    // POST: Halaqa/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Halaqa halaqa)
    {
        if (id != halaqa.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                // Update the Halaqa entity
                _unitOfWork.Halaqat.Update(halaqa);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log or handle the error
                ModelState.AddModelError(string.Empty, "An error occurred while updating the Halaqa. Please try again.");
            }
        }

        // Repopulate the teachers dropdown if there is a validation error
        ViewBag.Teachers = new SelectList(await _unitOfWork.Teachers.GetAllAsync(), "Id", "FistName", halaqa.TeacherId);
        return View(halaqa);
    }

    // GET: Halaqa/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var halaqa = await _unitOfWork.Halaqat.Find(x => x.Id == id);
        if (halaqa != null)
        {
            _unitOfWork.Halaqat.Delete(halaqa.Id);
            _unitOfWork.Complete();
        }
        return RedirectToAction(nameof(Index));
    }



    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _unitOfWork.Dispose();
        }
        base.Dispose(disposing);
    }
}
