using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using users.Models;

namespace users.Controllers
{
    public class UsersController : Controller
    {
        UserDbcontext _dbcontext = new UserDbcontext();
           


        // GET: Users
        public ActionResult Index()
        {
            List<Users> users = _dbcontext.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public ActionResult GetUserById(int id)
        {
            Users user = _dbcontext.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View( new Users());
        }

        [HttpPost]
        public ActionResult Create(Users newusers)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    UserDbcontext db = new UserDbcontext();
                    db.Users.Add(newusers);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            Users user = _dbcontext.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(Users updatedUser)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Entry(updatedUser).State = EntityState.Modified;
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(updatedUser);
        }
        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            Users user = _dbcontext.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("DeleteUser")]
        public ActionResult ConfirmDeleteUser(int id)
        {
            Users user = _dbcontext.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            _dbcontext.Users.Remove(user);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}