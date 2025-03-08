using Journal.Models;
using Journal.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Journal.Controllers;

public class JournalEntryArchivesController : Controller
{
    private readonly JournalEntryArchiveRepository _repository;
    private readonly JournalEntryRepository _journalEntryRepository;
    
    public JournalEntryArchivesController(JournalEntryArchiveRepository repository, JournalEntryRepository journalEntryRepository)
    {
        _repository = repository;
        _journalEntryRepository = journalEntryRepository;
    }
    
    public IActionResult Index()
    {
        var objJournalEntryList = _repository.GetArchiveEntries();
        return View(objJournalEntryList);
    }
    
    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id is null or 0)
        {
            return NotFound();
        }

        var journalEntryArchive = _repository.GetJournalEntryArchiveById(id.Value);
        if (journalEntryArchive == null)
        {
            return NotFound();
        }

        return View(journalEntryArchive);
    }
    
    [HttpPost]
    public IActionResult Delete(JournalEntryArchive obj)
    {
        var journalEntryArchive = _repository.GetJournalEntryArchiveById(obj.Id);
        if (journalEntryArchive == null)
        {
            return NotFound();
        }

        var journalEntry = journalEntryArchive.JournalEntry;
        journalEntry.IsArchived = false;
        journalEntry.JournalEntryArchive = null;
        journalEntry.JournalEntryArchiveId = null;
        
        _journalEntryRepository.UpdateJournalEntry(journalEntry);
        
        return RedirectToAction("Index");
    }
}