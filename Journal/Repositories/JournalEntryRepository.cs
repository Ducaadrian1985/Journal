using Journal.Data;
using Journal.Models;
using Microsoft.EntityFrameworkCore;

namespace Journal.Repositories
{
    public class JournalEntryRepository
    {
        private readonly ApplicationDbContext _db;
        public JournalEntryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<JournalEntry> GetAllJournalEntriesWithCategoriesAndTags()
        {
            return _db.JournalEntries.Include(entity => entity.Category).Include(entity => entity.Tag).ToList();
        }
        public List<JournalEntry> GetAllJournalEntries()
        {
            return _db.JournalEntries.ToList();
        }
        public void AddJournalEntry(JournalEntry obj)
        {
            _db.JournalEntries.Add(obj);
            _db.SaveChanges();
        }
        public JournalEntry? GetJournalEntryById(int id)
        {
            return _db.JournalEntries.Find(id);
        }
        public void UpdateJournalEntry(JournalEntry obj)
        {
            _db.JournalEntries.Update(obj);
            _db.SaveChanges();
        }
        public void DeleteJournalEntry(JournalEntry obj)
        {

            _db.JournalEntries.Remove(obj);
            _db.SaveChanges();
        }
    }
}
