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
        UserDbcontext dbcontext=new UserDbcontext();

        // GET: Users
        public ActionResult Index()
        {
            List<Users> users = dbcontext.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public ActionResult GetUserById(int id)
        {
            Users user = dbcontext.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(Users newUser)
        {
            if (ModelState.IsValid)
            {
                dbcontext.Users.Add(newUser);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newUser);
        }
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            Users user = dbcontext.Users.Find(id);
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
                dbcontext.Entry(updatedUser).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(updatedUser);
        }
        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            Users user = dbcontext.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("DeleteUser")]
        public ActionResult ConfirmDeleteUser(int id)
        {
            Users user = dbcontext.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            dbcontext.Users.Remove(user);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}