using Journal.Data;
using Journal.Models;

namespace Journal.Repositories
{
    public class TagRepository

    {
        private readonly ApplicationDbContext _db;
        public TagRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<Tag> GetAllTags()
        {
            return _db.Tags.ToList();
        }
    }
}
