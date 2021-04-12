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
    public class AcademicSessionsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AcademicSessionsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }


       

        // GET: AcademicSessions
        public async Task<IActionResult> Index()
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var applicationDbContext = _context.AcademicSessions.Where(a => a.InstitutionId==loggedInUser.InstitutionId);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: AcademicSessions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AcademicSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AcademicSession academicSession)
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            academicSession.Status = 1;
            academicSession.InstitutionId =(int) loggedInUser.InstitutionId;
            if (ModelState.IsValid)
            {
                _context.Add(academicSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(academicSession);
        }

        // GET: AcademicSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicSession = await _context.AcademicSessions.FindAsync(id);
            if (academicSession == null)
            {
                return NotFound();
            }
            return View(academicSession);
        }

        // POST: AcademicSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AcademicSession academicSession)
        {
            if (id != academicSession.Id)
            {
                return NotFound();
            }

           
                try
                {
                var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                academicSession.Status = 1;
                academicSession.InstitutionId = (int)loggedInUser.InstitutionId;
                var tempAcademicSession = await _context.AcademicSessions.Where(m => m.Id == academicSession.Id).FirstOrDefaultAsync();
                    tempAcademicSession.Name = academicSession.Name;

                    _context.Update(tempAcademicSession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicSessionExists(academicSession.Id))
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

        // GET: AcademicSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicSession = await _context.AcademicSessions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (academicSession == null)
            {
                return NotFound();
            }

            return View(academicSession);
        }

        // POST: AcademicSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academicSession = await _context.AcademicSessions.FindAsync(id);
            _context.AcademicSessions.Remove(academicSession);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicSessionExists(int id)
        {
            return _context.AcademicSessions.Any(e => e.Id == id);
        }
    }
}
