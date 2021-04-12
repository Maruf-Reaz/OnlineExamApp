using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamApp.Data;
using ExamApp.Models;
using ExamApp.Models.Common.Authentication;
using Microsoft.AspNetCore.Identity;
using ExamApp.Models.ViewModels;

namespace ExamApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: Students
        public async Task<IActionResult> Index()
        {

            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var applicationDbContext = _context.Students.Include(s => s.ApplicationUser).Include(s => s.Section).Include(s => s.Section.Department).Include(s => s.Section).Where(m => m.Section.Department.InstitutionId == loggedInUser.InstitutionId);
            return View(await applicationDbContext.ToListAsync());
        }



        // GET: Students/Create
        public async Task<IActionResult> Create()
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            ViewData["SectionId"] = new SelectList(_context.Sections.Where(m => m.Department.InstitutionId == loggedInUser.InstitutionId), "Id", "Name");
            ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(m => m.InstitutionId == loggedInUser.InstitutionId), "Id", "ShortName");


            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                string userName = student.Name;
                userName = userName.Replace(" ", String.Empty);


                var user = new ApplicationUser()
                {
                    UserName = userName,
                    Email = student.Email,
                    UserTypeId = 3,
                    PhoneNumber = student.PhoneNo,
                    InstitutionId = loggedInUser.InstitutionId
                };



                //Create user with password
                var result = await _userManager.CreateAsync(user, "Admin123#");
                await _userManager.AddToRoleAsync(user, "Student");
                var userProfile = new UserProfile
                {
                    ApplicationUserId = student.ApplicationUserId,
                    Name = student.Name,
                    PhoneNumber = student.PhoneNo,
                    Email = student.Email,

                };
                var tempStudent = await _context.Students.Where(m => m.Id == student.Id).FirstOrDefaultAsync();
                tempStudent.ApplicationUserId = user.Id;

                _context.Update(tempStudent);
                await _context.SaveChangesAsync();



                return RedirectToAction(nameof(Index));
            }
            ViewData["SectionId"] = new SelectList(_context.Sections.Where(m => m.Department.InstitutionId == loggedInUser.InstitutionId), "Id", "Name", student.SectionId);

            ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(m => m.InstitutionId == loggedInUser.InstitutionId), "Id", "ShortName");
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var student = await _context.Students.Include(m => m.Section).Include(m => m.Section.Department).Where(m => m.Id == id).FirstOrDefaultAsync();
            if (student == null)
            {
                return NotFound();
            }
            ViewData["SectionId"] = new SelectList(_context.Sections.Where(m => m.Department.InstitutionId == loggedInUser.InstitutionId && m.DepartmentId == student.Section.DepartmentId), "Id", "Name", student.SectionId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(m => m.InstitutionId == loggedInUser.InstitutionId), "Id", "ShortName", student.Section.DepartmentId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SectionId"] = new SelectList(_context.Sections.Where(m => m.Department.InstitutionId == loggedInUser.InstitutionId && m.DepartmentId == student.Section.DepartmentId), "Id", "Name", student.SectionId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(m => m.InstitutionId == loggedInUser.InstitutionId), "Id", "ShortName");
            return View(student);
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<JsonResult> GetStudentById(int studentId)
        {

            var student = await _context.Students.Where(m => m.Id == studentId).FirstOrDefaultAsync();

            return Json(student);

        }

        public async Task<IActionResult> ViewStudentResult(int id)
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            if ((await _userManager.IsInRoleAsync(loggedInUser, "Student")))
            {
                var student = await _context.Students.Where(m => m.ApplicationUserId == loggedInUser.Id).FirstOrDefaultAsync();
                id = student.Id;
            }
            var classRooms = await _context.ClassRoomStudents
              .Include(m => m.ClassRoom)
              .Include(m => m.ClassRoom.Course)
              .Include(m => m.ClassRoom.Teacher)
              .Include(m => m.ClassRoom.Section)
           .Where(m => m.StudentId == id && m.ClassRoom.AcademicSession.Status == 1)
           .ToListAsync();

            var resultStudent = await _context.Students.Where(m => m.Id == id).FirstOrDefaultAsync();
            
            List<EvaluateExamViewModel> evaluetedStudents = new List<EvaluateExamViewModel>();
            foreach (var classRoom in classRooms)
            {
                EvaluateExamViewModel evaluateExamViewModel = new EvaluateExamViewModel();
                evaluateExamViewModel.Course = classRoom.ClassRoom.Course;
                evaluateExamViewModel.CourseId = classRoom.ClassRoom.CourseId;

                var allAnswers = _context.StudentAnswers
                      .Include(m => m.Question)
                     .Include(m => m.Question.Exam)
                  .Where(m => m.Question.Exam.ClassRoomId == classRoom.ClassRoom.Id && m.Question.Exam.IsNotCountable==false && m.StudentId == id)
                  .ToList();

                var allquestions = _context.StudentQuestions
                      .Include(m => m.Question)
                     .Include(m => m.Question.Exam)
                 .Where(m => m.Question.Exam.ClassRoomId == classRoom.ClassRoom.Id && m.Question.Exam.IsNotCountable==false && m.StudentId == id)
                 .ToList();
                evaluateExamViewModel.ObtainedMark = (double)allAnswers.Sum(m => m.ActualObtailedMark);
                evaluateExamViewModel.ExamMark = (double)allquestions.Sum(m => m.Question.ActualMark);
                if (evaluateExamViewModel.ExamMark == 0 && evaluateExamViewModel.ObtainedMark == 0)
                {
                    evaluateExamViewModel.PercentageMark = 0;
                    evaluateExamViewModel.GradeId = 0;
                }
                else
                {
                    double markBeforePercentage = evaluateExamViewModel.ObtainedMark / evaluateExamViewModel.ExamMark;

                    evaluateExamViewModel.PercentageMark = markBeforePercentage * 100;
                    evaluateExamViewModel.PercentageMark = Math.Ceiling(evaluateExamViewModel.PercentageMark);

                    var allgrades = await _context.Grades.ToListAsync();
                    foreach (var grade in allgrades)
                    {
                        if (evaluateExamViewModel.PercentageMark >= grade.FromMark && evaluateExamViewModel.PercentageMark <= grade.ToMark)
                        {
                            evaluateExamViewModel.Grade = grade;
                            evaluateExamViewModel.GradeId = grade.Id;
                        }

                    }
                }

               
                evaluetedStudents.Add(evaluateExamViewModel);
            }
            ViewData["Student"] = resultStudent;
            return View(evaluetedStudents);
        }
    }
}
