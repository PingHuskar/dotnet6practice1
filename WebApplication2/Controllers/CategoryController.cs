using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult<string> Index()
        {
            return View();
        }
        public ActionResult<string> Edit()
        {
            return View("Index");
        }
        //public ActionResult<string> Create(int id, string test)
        //{
        //    //return id;
        //    return Json(new { name = "Biw", Age = 30 });
        //    //return View();
        //}
        public ActionResult<IEnumerable<Category>> GetAll() //IEnumerable => [list or array]
        {
            var categories = _context.Categories.ToList(); //table name
            return categories;
        }

        public ActionResult<Category> Get(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok(category);
        }
        [HttpPost]
        public ActionResult Update(int id, Category category)
        {
            var PendingUpdatecategory = _context.Categories.Find(id);
            PendingUpdatecategory.DisplayOrder = category.DisplayOrder;
            _context.Categories.Update(PendingUpdatecategory);
            _context.SaveChanges();
            return Ok(category);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var PendingDeletecategory = _context.Categories.Find(id);
            if (PendingDeletecategory == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(PendingDeletecategory);
            _context.SaveChanges();
            return Ok("Delete Success");
        }
    }
}
