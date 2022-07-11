using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryController()
        {

        }
        public ActionResult<string> Index()
        {
             return View();
        }
        public ActionResult<string> Edit()
        {
            return View("Index");
        }
        public ActionResult<string> Create(int id,string test)
        {
            //return id;
            return Json(new { name = "Biw", Age = 30 });
            //return View();
        }
    }
}
