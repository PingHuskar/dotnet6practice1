using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    public class FriendController : Controller
    {
        public IActionResult Index()
        {
            var data = _context.Friends.OrderBy(f=>f.FriendName).ToList();

            return View(data);
        }
        public IActionResult New()
        {
            return View();
        }
        public IActionResult Update(int id)
        {
            var fid = _context.Friends.Find(id);
            if (fid == null)
            {
                return NotFound();
            }
            return View(fid);
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
        public ActionResult New(Friend friend)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Friends.Add(newFriend);
            //    _context.SaveChanges();
            //    return Ok(newFriend);
            //}
            //else
            //{
            //    return BadRequest();
            //}
            if (ModelState.IsValid)
            {
                var existing = _context.Friends.Find(friend.FriendID);
                if (existing != null)
                {
                    return BadRequest();
                }

                _context.Friends.Add(friend);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        //[HttpPost]
        //public ActionResult Update(int id, Friend selectFriend)
        //{
        //    var PendingUpdatefriend = _context.Friends.Find(id);
        //    PendingUpdatefriend.Place = selectFriend.Place;
        //    _context.Friends.Update(PendingUpdatefriend);
        //    _context.SaveChanges();
        //    return Ok(selectFriend);
        //}
        [HttpPost]
        public ActionResult Update(Friend friend)
        {

            if (ModelState.IsValid)
            {

                _context.Friends.Update(friend);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var PendingDeleteFriend = _context.Friends.Find(id);
            if (PendingDeleteFriend == null)
            {
                return NotFound();
            }
            _context.Friends.Remove(PendingDeleteFriend);
            _context.SaveChanges();
            //return Ok("Delete Success");
            return Json(new { Success = true ,message=""});
        }
    }
}
