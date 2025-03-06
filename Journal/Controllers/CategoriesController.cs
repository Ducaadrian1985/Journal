using Journal.Data;
using Journal.Models;
using Journal.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Journal.Controllers;

public class CategoriesController(CategoryRepository repository) : Controller
{
    public IActionResult Index()
    {
        var objJournalEntryList = repository.GetAllCategories();
        return View(objJournalEntryList);
    }

    public IActionResult Create()
    {

        return View();
    }

    [HttpPost]
    public IActionResult Create(Category obj)
    {
        if (obj is { Name.Length: < 3 })
        {
            ModelState.AddModelError("Name", "Name must be at least 3 characters long!");
        }

        if (!ModelState.IsValid)
        {
            return View(obj);
        }
        //obj.Created = DateTime.Now;
        repository.AddCategory(obj);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id is null or 0)
        {
            return NotFound();
        }

        var CategoriesEntry =repository.GetCategoryById(id.Value);
        if (CategoriesEntry == null)
        {
            return NotFound();
        }

        return View(CategoriesEntry);
    }

    [HttpPost]
    public IActionResult Edit(Category obj)
    {
        if (obj is { Name.Length: < 3 })
        {
            ModelState.AddModelError("Name", "Name must be at least 3 characters long!");
        }

        if (!ModelState.IsValid)
        {
            return View(obj);
        }
        //obj.Created = DateTime.Now;
        repository.UpdateCategory(obj);
        
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id is null or 0)
        {
            return NotFound();
        }

        var CategoryEntry = repository.GetCategoryById(id.Value);
        if (CategoryEntry == null)
        {
            return NotFound();
        }

        return View(CategoryEntry);
    }

    [HttpPost]
    public IActionResult Delete(Category obj)
    {
        repository.DeleteCategory(obj);
        

        return RedirectToAction("Index");
    }
}