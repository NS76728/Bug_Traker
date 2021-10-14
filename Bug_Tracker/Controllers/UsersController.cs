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
        
        public IActionResult ViewUser(int id,string username,string password)
        {
            if(id ==0 || username==null || password==null)
            {
                return RedirectToAction("LoginScreen");
            }
            var user = repo.GetUsers(id,username,password);
            return View(user);
        }
        public IActionResult LoginScreen()
        {
            return View();

        }
        public IActionResult CreateUser()
        {
            //if (user.ID == 0 && user.UserName == null && user.Password == null)
            //{
            //    return RedirectToAction("CreateUser");
            //}
            var prod = new Users();
            return View(prod);
        }
        
        public IActionResult InsertUserToDatabase(Users users )
        {
            if (users.ID == 0 || users.UserName == null || users.Password == null)
            {
                return RedirectToAction("CreateUser");
            }
            repo.InsertUser(users);

            return RedirectToAction("ViewUser", new {id = users.ID, username= users.UserName, password=users.Password });
        }
        
        public IActionResult DeleteUser(Users users)
        {
            repo.Deleteuser(users);

            return RedirectToAction("Index","Home");                                 
        }
        public IActionResult Updateuser(int id)
        {
            var prod = repo.GetUser1(id);

            if (prod == null)
            {
                return View("UserNotFound");
            }

            return View(prod);

        }
        public IActionResult UpdateUserToDatabase(Users users)
        {
            repo.Updateuser(users);

            return RedirectToAction("ViewUser", new { id = users.ID, username = users.UserName, password = users.Password });
        }
        public IActionResult Assignedbugs(int ID)
        {
            var bugs = repo.Assignedbugs(ID);
            return View(bugs);
        }
    }
}
