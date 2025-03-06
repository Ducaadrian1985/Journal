using Journal.Data;
using Journal.Models;
using Journal.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Journal.Controllers;

public class JournalEntriesController(JournalEntryRepository repository, CategoryRepository categoryRepository, TagRepository tagRepository) : Controller
{
    public IActionResult Index()
    {
        var objJournalEntryList = repository.GetAllJournalEntriesWithCategoriesAndTags();
        return View(objJournalEntryList);
    }

    public IActionResult Create()
    {
        var categoryItems = new List<SelectListItem>();

        var categoryList =categoryRepository.GetAllCategories();

        foreach (var category in categoryList)
        {
            var listItem = new SelectListItem { Text = category.Name , Value = category.Id.ToString() };

            categoryItems.Add(listItem);

        }
        var tagItems = new List<SelectListItem>();

        var tagList = tagRepository.GetAllTags();

        foreach (var tag in tagList)
        {
            var listItem = new SelectListItem { Text = tag.Name, Value = tag.Id.ToString() };

            tagItems.Add(listItem);

        }

        ViewBag.CategoryItems = categoryItems;
        ViewBag.TagItems = tagItems;
        return View(new JournalEntry { Created = DateTime.Now});
    }

    [HttpPost]
    public IActionResult Create(JournalEntry obj)
    {
        if (obj is { Title.Length: < 3 })
        {
            ModelState.AddModelError("Title", "Title must be at least 3 characters long!");
        }

        if (!ModelState.IsValid)
        {
            return View(obj);
        }
        //obj.Created = DateTime.Now;
        repository.AddJournalEntry(obj);
        
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id is null or 0)
        {
            return NotFound();
        }

        var journalEntry = repository.GetJournalEntryById(id.Value);
        if (journalEntry == null)
        {
            return NotFound();
        }

        var categoryItems = new List<SelectListItem>();
        var categoryList = categoryRepository.GetAllCategories();

        foreach (var category in categoryList)
        {
            var listItem = new SelectListItem { Text = category.Name, Value = category.Id.ToString() };

            categoryItems.Add(listItem);

        }
        var tagItems = new List<SelectListItem>();

        var tagList = tagRepository.GetAllTags();

        foreach (var tag in tagList)
        {
            var listItem = new SelectListItem { Text = tag.Name, Value = tag.Id.ToString() };

            tagItems.Add(listItem);

        }


        ViewBag.CategoryItems = categoryItems;
        ViewBag.TagItems = tagItems;
        return View(journalEntry);
    }

    [HttpPost]
    public IActionResult Edit(JournalEntry obj)
    {
        if (obj is { Title.Length: < 3 })
        {
            ModelState.AddModelError("Title", "Title must be at least 3 characters long!");
        }

        if (!ModelState.IsValid)
        {
            return View(obj);
        }

        //obj.Created = DateTime.Now;
        repository.UpdateJournalEntry(obj);
       
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id is null or 0)
        {
            return NotFound();
        }

        var journalEntry = repository.GetJournalEntryById(id.Value);
        if (journalEntry == null)
        {
            return NotFound();
        }

        return View(journalEntry);
    }

    [HttpPost]
    public IActionResult Delete(JournalEntry obj)
    {
        repository.DeleteJournalEntry(obj);
        

        return RedirectToAction("Index");
    }
}