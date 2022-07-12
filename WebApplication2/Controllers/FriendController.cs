using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    public class FriendController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly ApplicationDbContext _context;
        public FriendController(ApplicationDbContext context) // public classs ... => public ... 
        {
            _context = context;
        }

        public ActionResult<IEnumerable<Friend>> Get() //IEnumerable => [list or array]
        {
            var fs = _context.Friends.ToList();
            return fs;
        }

        [HttpPost]
        public ActionResult New(Friend newFriend)
        {
            _context.Friends.Add(newFriend);
            _context.SaveChanges();
            return Ok(newFriend);
        }

        [HttpPost]
        public ActionResult Update(int id, Friend selectFriend)
        {
            var PendingUpdatefriend = _context.Friends.Find(id);
            PendingUpdatefriend.Place = selectFriend.Place;
            _context.Friends.Update(PendingUpdatefriend);
            _context.SaveChanges();
            return Ok(selectFriend);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var PendingDeleteFriend = _context.Friends.Find(id);
            if (PendingDeleteFriend == null)
            {
                return NotFound();
            }
            _context.Friends.Remove(PendingDeleteFriend);
            _context.SaveChanges();
            return Ok("Delete Success");
        }
    }
}
