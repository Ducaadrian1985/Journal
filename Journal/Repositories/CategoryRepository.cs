using Journal.Data;
using Journal.Models;

namespace Journal.Repositories
{
    public class CategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<Category> GetAllCategories()
        {
            return _db.Categories.ToList();
        }

        public void AddCategory(Category obj)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
        }

        public Category?  GetCategoryById(int id)
        {
            return _db.Categories.Find(id);
        }
        public void UpdateCategory(Category obj)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
        }
        public void DeleteCategory(Category obj)
        {
            
            _db.Categories.Remove(obj);
            _db.SaveChanges();
        }
    }
}
