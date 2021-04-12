using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExamApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ExamApp.Models.Common.Authentication;
using ExamApp.Data;
using ExamApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        //[Authorize(Roles = "GateAdmin, HarbourAndMarine, Mechanical, Admin, TMOffice")]
        public async Task<IActionResult> Index()
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            //var applicationDbContext = _context.Exams.Include(e => e.ClassRoom).Include(e => e.ExamType).Where(m => m.ClassRoomId == classRoomId);
            //ViewData["ClassRoomId"] = classRoomId;
            int i = 0;

            if ((await _userManager.IsInRoleAsync(loggedInUser, "Admin")))
            {
                i = 1;
                var teachers =await _context.Teachers
                    .Include(m=>m.Department)
                    .Include(m=>m.Designation)
                     .Where(m => m.ApplicationUser.InstitutionId == loggedInUser.InstitutionId)
                    .ToListAsync();
                 var students =await _context.Students
                     .Where(m => m.ApplicationUser.InstitutionId == loggedInUser.InstitutionId)
                    .ToListAsync();
                 var classRooms =await _context.ClassRooms
                     .Where(m =>  m.AcademicSession.Status == 1 && m.AcademicSession.InstitutionId== loggedInUser.InstitutionId)
                    .ToListAsync();

                 
                var exams = await _context.Exams
                    .Include(c => c.ClassRoom)
                    .Include(c => c.ClassRoom.Section)
                    .Include(c => c.ClassRoom.Course)
                    .Include(c => c.ClassRoom.Teacher)
                    .Where(m => m.Status == 0 && m.ClassRoom.AcademicSession.Status==1 && m.ClassRoom.AcademicSession.InstitutionId == loggedInUser.InstitutionId).ToListAsync();
                ViewData["Exams"] = exams;
                ViewData["TeacherCount"] = teachers.Count;
                ViewData["StudentCount"] = students.Count;
                ViewData["UpComingExamCount"] = exams.Count;
                ViewData["ClassRoomCount"] = classRooms.Count;
                ViewData["Teachers"] = teachers;

            }
            if ((await _userManager.IsInRoleAsync(loggedInUser, "Teacher")))
            {
                i = 2;
                var teacher = await _context.Teachers.Where(m => m.ApplicationUserId == loggedInUser.Id).FirstOrDefaultAsync();
                var exams = await _context.Exams
                   .Include(c => c.ClassRoom)
                   .Include(c => c.ClassRoom.Course)
                   .Include(c => c.ClassRoom.Teacher)
                   .Where(m => m.ClassRoom.TeacherId == teacher.Id && m.ClassRoom.AcademicSession.Status == 1 && m.ClassRoom.AcademicSession.InstitutionId == loggedInUser.InstitutionId).ToListAsync();

                 var classRooms = await _context.ClassRooms
                   .Include(c => c.Course)
                   .Include(c => c.Teacher)
                   .Where(m => m.TeacherId == teacher.Id && m.AcademicSession.Status == 1 && m.AcademicSession.InstitutionId == loggedInUser.InstitutionId).ToListAsync();

                ViewData["Exams"] = exams;
                ViewData["ClassRooms"] = classRooms;

            }
            if ((await _userManager.IsInRoleAsync(loggedInUser, "Student")))
            {
                i = 3;
                var student = await _context.Students.Where(m => m.ApplicationUserId == loggedInUser.Id).FirstOrDefaultAsync();
                var classRooms = await _context.ClassRoomStudents
                   .Include(c => c.ClassRoom)
                   .Include(c => c.ClassRoom.Course)
                   .Include(c => c.ClassRoom.Teacher)
                   .Where(m => m.StudentId == student.Id && m.ClassRoom.AcademicSession.Status == 1 && m.ClassRoom.AcademicSession.InstitutionId == loggedInUser.InstitutionId).ToListAsync();
                ViewData["ClassRooms"] = classRooms;
            }

            ViewData["UserType"] = i;

            return View();
        }

        public IActionResult AssignmentData(DateTime getDate, DateTime fromDate)
        {
            if (fromDate == default(DateTime))
            {
                fromDate = DateTime.Now.Date;
            }

            ViewData["Date"] = fromDate.Date;
            return View();
        }

        [HttpPost]
        public IActionResult Fetch(FromDateToDateViewModel datesVM)
        {
            ViewData["Date"] = datesVM.FromDate;
            return RedirectToAction("AssignmentData", new { fromDate = datesVM.FromDate });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
