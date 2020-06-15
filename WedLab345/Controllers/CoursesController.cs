using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WedLab345.Models;
using WedLab345.ViewModels;

namespace WedLab345.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Courses
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }
               [Authorize]
               [HttpPost]
               [ValidateAntiForgeryToken]
               public ActionResult Create(CourseViewModel viewModel)
               {
                   if (!ModelState.IsValid)
                   {
                       viewModel.Categories = _dbContext.Categories.ToList();
                       return View("Create", viewModel);
                   }
                   var Course = new Course
                   {
                       //Categories = _dbContext.Categories.ToList()
                       LecturerId = User.Identity.GetUserId(),
                       DateTime = viewModel.GetDateTime(),
                       CategoryId = viewModel.Category,
                       Place = viewModel.Place
                   };
                   _dbContext.Courses.Add(Course);
                   _dbContext.SaveChanges();
                   //  return View(viewModel);
                   return RedirectToAction("Index", "Home");
               }
    }
}
