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

        var categoriesEntry =repository.GetCategoryById(id.Value);
        if (categoriesEntry == null)
        {
            return NotFound();
        }

        return View(categoriesEntry);
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

        var categoryEntry = repository.GetCategoryById(id.Value);
        if (categoryEntry == null)
        {
            return NotFound();
        }

        return View(categoryEntry);
    }

    [HttpPost]
    public IActionResult Delete(Category obj)
    {
        repository.DeleteCategory(obj);
        

        return RedirectToAction("Index");
    }
}