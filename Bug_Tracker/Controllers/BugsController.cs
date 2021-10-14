using Bug_Tracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bug_Tracker.Controllers
{
    public class BugsController : Controller
    {
        private readonly IBugsRepo repo;

        public BugsController(IBugsRepo repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var bugs = repo.GetAllBugs();
            return View(bugs);
        }
        public IActionResult ViewBug(int id)
        {
            var bug = repo.GetBug(id);

            return View(bug);
        }
        public IActionResult UpdateBug(int id)
        {
            var prod = repo.GetBug(id);

            if (prod == null)
            {
                return View("BugNotFound");
            }

            return View(prod);
        }

        public IActionResult UpdateBugToDatabase(Bugs bugs)
        {
            repo.UpdateBug(bugs);

            return RedirectToAction("Index");
        }
        public IActionResult InsertBugToDatabase(Bugs bugToInsert)
        {
            if (bugToInsert.ID == 0 ||  bugToInsert.Project ==null || bugToInsert.Description == null || bugToInsert.Type == null || bugToInsert.Status == null || bugToInsert.Date == 0 || bugToInsert.AssignedUserID == 0) 
            {
                return RedirectToAction("InsertBug");
            }
            repo.InsertBug(bugToInsert);

            return RedirectToAction("Index");
        }
        public IActionResult InsertBug(Bugs bugToInsert)
        {
            var prod = new Bugs();
            if (prod == null)
            {
                return View(prod);
            }
            return View(prod);

        }
        public IActionResult DeleteBug(Bugs bug)
        {
            repo.DeleteBug(bug);

            return RedirectToAction("Index");
        }
        public IActionResult Search(string searchString)
        {
            var searchResults = repo.SearchBug(searchString);
            return View(searchResults);
        }



        //public IActionResult UploadButtonClick(IFormFile files, Bugs bugs)
        //{
        //    if (files != null)
        //    {
        //        if (files.Length > 0)
        //        {


        //            var fileName = Path.GetFileName(files.FileName);

        //            var uniqueFileName = Convert.ToString(Guid.NewGuid());


        //            var fileExtension = Path.GetExtension(fileName);


        //            var newFileName = String.Concat(uniqueFileName, fileExtension);


        //            var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")).Root + $@"{newFileName}";

        //            using (FileStream fs = System.IO.File.Create(filepath))
        //            {
        //                files.CopyTo(fs);
        //                fs.Flush();
        //            }

        //            bugs.Image = "/images/" + newFileName;

        //            repo.InsertImage(bugs);

        //        }
        //    }

        //    return RedirectToAction("Index");
        //}









    }
}
