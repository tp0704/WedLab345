using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WedLab345.Models;
using WedLab345.ViewModels;

namespace WedLab345.Controllers
{
    public class CoursesController : Controller
    {
        private readonly Models.ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Courses
        [Authorize]
        [HttpPost]
        public ActionResult Create(CourseViewModel viewModel)
        {
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place
            };
            _dbContext.Coures.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}