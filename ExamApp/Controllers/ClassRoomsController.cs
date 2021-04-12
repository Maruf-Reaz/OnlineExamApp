using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamApp.Data;
using ExamApp.Models;
using ExamApp.Models.Common.ViewModels;
using Microsoft.AspNetCore.Identity;
using ExamApp.Models.Common.Authentication;

namespace ExamApp.Controllers
{
    public class ClassRoomsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClassRoomsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }
      

        // GET: ClassRooms
        public async Task<IActionResult> CurrentIndex()
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var applicationDbContext = await _context.ClassRooms.Include(c => c.AcademicSession).Include(c => c.Course).Include(c => c.Section).Include(c => c.Teacher).Where(m => m.AcademicSession.Status == 1 && m.AcademicSession.InstitutionId==loggedInUser.InstitutionId).ToListAsync();

            return View(applicationDbContext);
        }

        public async Task<IActionResult> PreviousIndex()
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var applicationDbContext =  await _context.ClassRooms.Include(c => c.AcademicSession).Include(c => c.Course).Include(c => c.Section).Include(c => c.Teacher).Where(m => m.AcademicSession.Status == 0 && m.AcademicSession.InstitutionId == loggedInUser.InstitutionId).ToListAsync();
            return View( applicationDbContext);
        }

        public async Task<IActionResult> TeacherIndex()
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var teacher = await _context.Teachers.Where(m => m.ApplicationUserId == loggedInUser.Id).FirstOrDefaultAsync();

            var applicationDbContext = await _context.ClassRooms.Include(c => c.AcademicSession).Include(c => c.Course).Include(c => c.Section).Include(c => c.Teacher).Where(m => m.TeacherId == teacher.Id && m.AcademicSession.Status == 1 && m.AcademicSession.InstitutionId == loggedInUser.InstitutionId).ToListAsync();
            return View( applicationDbContext);
        }

        public async Task<IActionResult> StudentIndex()
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var student = await _context.Students.Where(m => m.ApplicationUserId == loggedInUser.Id).FirstOrDefaultAsync();
            var classRooms = await _context.ClassRoomStudents
                .Include(m=>m.ClassRoom)
                .Include(m=>m.ClassRoom.Course)
                .Include(m=>m.ClassRoom.Teacher)
                .Include(m=>m.ClassRoom.Section)
             .Where(m => m.StudentId==student.Id && m.ClassRoom.AcademicSession.Status == 1 && m.ClassRoom.AcademicSession.InstitutionId == loggedInUser.InstitutionId)
             .ToListAsync();
          
            return View(classRooms);
        }



        // GET: ClassRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classRoom = await _context.ClassRooms
                .Include(c => c.AcademicSession)
                .Include(c => c.Section)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classRoom == null)
            {
                return NotFound();
            }

            return View(classRoom);
        }

        // GET: ClassRooms/Create
        public async Task<IActionResult> Create()
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(m=>m.InstitutionId==loggedInUser.InstitutionId), "Id", "ShortName");
            return View();
        }

        // POST: ClassRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassRoom classRoom)
        {
            var currentSession = await _context.AcademicSessions.Where(m => m.Status == 1).FirstOrDefaultAsync();
            if (currentSession != null)
            {
                classRoom.AcademicSessionId = currentSession.Id;
                classRoom.Status = 1;

                if (ModelState.IsValid)
                {
                    _context.Add(classRoom);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(CurrentIndex));
                }
            }

            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "ShortName");
            return View(classRoom);
        }

        // GET: ClassRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classRoom = await _context.ClassRooms.Include(m => m.Section).Where(m => m.Id == id).FirstOrDefaultAsync();
            if (classRoom == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "ShortName", classRoom.Section.DepartmentId);
            ViewData["SectionId"] = new SelectList(_context.Sections, "Id", "FullName", classRoom.SectionId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Name", classRoom.TeacherId);
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Code", classRoom.TeacherId);



            return View(classRoom);
        }

        // POST: ClassRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClassRoom classRoom)
        {
            if (id != classRoom.Id)
            {
                return NotFound();
            }
            var currentSession = await _context.AcademicSessions.Where(m => m.Status == 1).FirstOrDefaultAsync();
            if (currentSession != null)
            {
                classRoom.AcademicSessionId = currentSession.Id;
                classRoom.Status = 1;

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(classRoom);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ClassRoomExists(classRoom.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(CurrentIndex));
                }
            }

            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "ShortName", classRoom.Section.DepartmentId);
            ViewData["SectionId"] = new SelectList(_context.Sections, "Id", "FullName", classRoom.SectionId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Name", classRoom.TeacherId);
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Code", classRoom.TeacherId);
            return View(classRoom);
        }



        private bool ClassRoomExists(int id)
        {
            return _context.ClassRooms.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<JsonResult> GetTeacherCourseSectionByDepartment(int departmentId)
        {
            var sections = await _context.Sections.Where(m => m.DepartmentId == departmentId).ToListAsync();

            var courses = await _context.Courses.Where(m => m.Semester.DepartmentId == departmentId).ToListAsync();

            var teachers = await _context.Teachers.Where(m => m.DepartmentId == departmentId).ToListAsync();

            TeacherCourseSectionViewModel teacherCourseSectionViewModel = new TeacherCourseSectionViewModel();
            teacherCourseSectionViewModel.Teachers = teachers;
            teacherCourseSectionViewModel.Courses = courses;
            teacherCourseSectionViewModel.Sections = sections;
            return Json(teacherCourseSectionViewModel);


        }

        public async Task<IActionResult> AddStudents(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classRoom = await _context.ClassRooms
                .Include(c => c.AcademicSession)
                .Include(c => c.Section)
                .Include(c => c.Teacher)
                .Include(c => c.Course)
                .Include(c => c.ClassRoomStudents)
                .ThenInclude(c => c.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classRoom == null)
            {
                return NotFound();
            }


            var deptStudents = await _context.Students.Where(m => m.Section.DepartmentId == classRoom.Teacher.DepartmentId).ToListAsync();
            foreach (var clStudent in classRoom.ClassRoomStudents)
            {
                deptStudents.Remove(clStudent.Student);
            }

            ViewData["Students"] = deptStudents;

            return View(classRoom);
        }


        [HttpPost]
        public async Task<JsonResult> AddStudentToClassRoom(int studentId, int classRoomId)
        {


            ClassRoomStudent classRoomStudent = new ClassRoomStudent();
            classRoomStudent.StudentId = studentId;
            classRoomStudent.ClassRoomId = classRoomId;
            _context.Add(classRoomStudent);
            await _context.SaveChangesAsync();
            return Json(true);

        }
        [HttpPost]
        public async Task<JsonResult> DeleteStudentFromClassRoom(int studentId, int classRoomId)
        {

            var classrommStudent = await _context.ClassRoomStudents.Where(m => m.StudentId == studentId && m.ClassRoomId == classRoomId).FirstOrDefaultAsync();
            _context.Remove(classrommStudent);
            await _context.SaveChangesAsync();
            return Json(true);

        }
    }
}
