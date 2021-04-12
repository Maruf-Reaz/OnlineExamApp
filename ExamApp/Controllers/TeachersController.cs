using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamApp.Data;
using ExamApp.Models;
using Microsoft.AspNetCore.Identity;
using ExamApp.Models.Common.Authentication;

namespace ExamApp.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TeachersController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var applicationDbContext = _context.Teachers.Include(t => t.ApplicationUser).Include(t => t.Department).Include(t => t.Designation).Include(t => t.Designation.Institution).Where(m => m.Designation.InstitutionId == loggedInUser.InstitutionId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers
                .Include(t => t.ApplicationUser)
                .Include(t => t.Designation)
                .Include(t => t.Designation.Institution)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public async Task<IActionResult> Create()
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            ViewData["DesignationId"] = new SelectList(_context.Designations.Where(m => m.InstitutionId == loggedInUser.InstitutionId), "Id", "Name");
            ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(m => m.InstitutionId == loggedInUser.InstitutionId), "Id", "ShortName");
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);



            if (ModelState.IsValid)
            {

                string userNmae = teacher.Name;
                userNmae = userNmae.Replace(" ", String.Empty);


                var user = new ApplicationUser()
                {
                    UserName = userNmae,
                    Email = teacher.Email,
                    UserTypeId = 2,
                    PhoneNumber = teacher.PhoneNo,
                    InstitutionId = loggedInUser.InstitutionId
                };


                //Create user with password
                var result = await _userManager.CreateAsync(user, "Admin123#");



                _context.Add(teacher);
                await _context.SaveChangesAsync();


                await _userManager.AddToRoleAsync(user, "Teacher");
                var userProfile = new UserProfile
                {
                    ApplicationUserId = teacher.ApplicationUserId,
                    Name = teacher.Name,
                    PhoneNumber = teacher.PhoneNo,
                    Email = teacher.Email,

                };
                var tempTeacher = await _context.Teachers.Where(m => m.Id == teacher.Id).FirstOrDefaultAsync();
                tempTeacher.ApplicationUserId = user.Id;

                _context.Update(tempTeacher);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["DesignationId"] = new SelectList(_context.Designations.Where(m => m.InstitutionId == loggedInUser.InstitutionId), "Id", "Name");
            ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(m => m.InstitutionId == loggedInUser.InstitutionId), "Id", "ShortName");
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            ViewData["DesignationId"] = new SelectList(_context.Designations.Where(m => m.InstitutionId == loggedInUser.InstitutionId), "Id", "Name", teacher.DesignationId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(m => m.InstitutionId == loggedInUser.InstitutionId), "Id", "ShortName");
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var tempTeacher = await _context.Teachers.Where(m => m.Id == teacher.Id).FirstOrDefaultAsync();

                    tempTeacher.Name = teacher.Name;
                    tempTeacher.IdNo = teacher.IdNo;
                    tempTeacher.Email = teacher.Email;
                    tempTeacher.PhoneNo = teacher.PhoneNo;
                    tempTeacher.Address = teacher.Address;
                    tempTeacher.DepartmentId = teacher.DepartmentId;
                    tempTeacher.DesignationId = teacher.DesignationId;
                    _context.Update(tempTeacher);
                    await _context.SaveChangesAsync();

                    var user = await _userManager.FindByIdAsync(tempTeacher.ApplicationUserId);
                    user.PhoneNumber = teacher.PhoneNo;
                    var result = await _userManager.UpdateAsync(user);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.Id))
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
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            ViewData["DesignationId"] = new SelectList(_context.Designations.Where(m => m.InstitutionId == loggedInUser.InstitutionId), "Id", "Name", teacher.DesignationId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(m => m.InstitutionId == loggedInUser.InstitutionId), "Id", "ShortName");
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers
                .Include(t => t.ApplicationUser)
                .Include(t => t.Designation)
                .Include(t => t.Designation.Institution)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }
}
