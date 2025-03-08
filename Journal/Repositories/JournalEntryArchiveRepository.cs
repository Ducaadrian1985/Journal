using Journal.Data;
using Journal.Models;
using Microsoft.EntityFrameworkCore;

namespace Journal.Repositories;

public class JournalEntryArchiveRepository
{
    private readonly ApplicationDbContext _context;
    public JournalEntryArchiveRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<JournalEntryArchive> GetArchiveEntries()
    {
        return _context.JournalEntryArchives
            .Include(entity => entity.JournalEntry)
            .ThenInclude(entity => entity.Tag)
            .Include(entity => entity.JournalEntry)
            .ThenInclude(entity => entity.Category)
            .ToList();
    }
    
    public JournalEntryArchive? GetJournalEntryArchiveById(int id)
    {
        return _context.JournalEntryArchives
            .Include(entity => entity.JournalEntry)
            .ThenInclude(entity => entity.Tag)
            .Include(entity => entity.JournalEntry)
            .ThenInclude(entity => entity.Category)
            .FirstOrDefault(entity => entity.Id == id);
    }

    public void CreateArchive(JournalEntryArchive journalEntryArchive)
    {
        _context.JournalEntryArchives.Add(journalEntryArchive);
        _context.SaveChanges();
    }

    public void DeleteArchive(JournalEntryArchive journalEntryArchive)
    {
        _context.JournalEntryArchives.Remove(journalEntryArchive);
        _context.SaveChanges();
    }
}