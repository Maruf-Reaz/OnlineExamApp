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

namespace ExamApp.Controllers
{
    public class SectionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SectionsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: Sections
        public async Task<IActionResult> Index()
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var applicationDbContext = _context.Sections.Include(m => m.Department).Where(a => a.Department.InstitutionId == loggedInUser.InstitutionId);
            return View(await applicationDbContext.ToListAsync());
        }



        // GET: Sections/Create
        public async Task<IActionResult> Create()
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(m => m.InstitutionId == loggedInUser.InstitutionId), "Id", "ShortName");
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Section section)
        {
            section.FullName = section.NumericValue + " " + section.Name;
            if (ModelState.IsValid)
            {
                _context.Add(section);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(section);
        }

        // GET: Sections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var section = await _context.Sections.FindAsync(id);
            if (section == null)
            {
                return NotFound();
            }
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(m => m.InstitutionId == loggedInUser.InstitutionId), "Id", "ShortName", section.DepartmentId);
            return View(section);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Section section)
        {
            if (id != section.Id)
            {
                return NotFound();
            }


            try
            {
                section.FullName = section.NumericValue + " " + section.Name;
                _context.Update(section);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionExists(section.Id))
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


        private bool SectionExists(int id)
        {
            return _context.Sections.Any(e => e.Id == id);
        }



        [HttpPost]
        public async Task<JsonResult> GetSectionsByDepartment(int departmentId)
        {
            var sections = await _context.Sections.Where(m => m.DepartmentId == departmentId).ToListAsync();
            return Json(sections);

        }
    }
}
