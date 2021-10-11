using Bug_Tracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Tracker.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersRepo repo;

        public UsersController(IUsersRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index(string username)
        {
            var user = repo.GetUsers(username);

            return View(user);
        }
        
        public IActionResult InsertUserToDatabase(Users users )
        {
            repo.InsertUser(users);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteUser(Users users)
        {
            repo.Deleteuser(users);

            return RedirectToAction("LoginScreen");
        }
        public IActionResult Updateuser(string username)
        {
            var prod = repo.GetUsers(username);

            if (prod == null)
            {
                return View("UserNotFound");
            }

            return View(prod);
        }
        public IActionResult UpdateUserToDatabase(Users users)
        {
            repo.UpdateUser(users);

            return RedirectToAction("Index");
        }
    }
}
