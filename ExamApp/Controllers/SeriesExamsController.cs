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
    public class SeriesExamsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeriesExamsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }
      
        // GET: SeriesExams
        public async Task<IActionResult> Index()
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var teacher = await _context.Teachers.Where(m => m.ApplicationUserId == loggedInUser.Id).FirstOrDefaultAsync();



            var applicationDbContext = _context.SeriesExams
                .Include(s => s.SelectedExam)
                .Include(s => s.ClassRoom)
                .Include(s => s.SeriesExamItems)
                .ThenInclude(s => s.Exam)
                .ThenInclude(s => s.ClassRoom)
                .ThenInclude(s => s.Course)
                .Include(s => s.ClassRoom.Course)
                .Where(m => m.ClassRoom.AcademicSession.Status == 1 && m.ClassRoom.AcademicSession.InstitutionId == loggedInUser.InstitutionId && m.ClassRoom.Teacher.ApplicationUser.Id == loggedInUser.Id);
            return View(await applicationDbContext.ToListAsync());
        }



        // GET: SeriesExams/Create
        public async Task<IActionResult> Create()
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            ViewData["ClassRoomId"] = await _context.ClassRooms
                .Include(m => m.Course)
                .Include(m => m.Section)
                .Where(m => m.Teacher.ApplicationUserId == loggedInUser.Id).ToListAsync();
            return View();
        }

        // POST: SeriesExams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SeriesExam seriesExam)
        {


            seriesExam.Status = 0;

            if (ModelState.IsValid)
            {
                _context.Add(seriesExam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // ViewData["AcademicSessionId"] = new SelectList(_context.AcademicSessions, "Id", "Id", seriesExam.AcademicSessionId);
            return View(seriesExam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSelectedExam(SeriesExam seriesExam)
        {
            var seriesExamTemp = await _context.SeriesExams.Where(m => m.Id == seriesExam.Id).FirstOrDefaultAsync();

            seriesExamTemp.SelectedExamId = seriesExam.SelectedExamId;
                _context.Update(seriesExamTemp);
                await _context.SaveChangesAsync();
            return RedirectToAction("AddExams", new { id = seriesExam.Id });
        }


        public async Task<IActionResult> FinalizeSeriesExam(int id)
        {
            var seriesExam = await _context.SeriesExams
                .Include(m=>m.SeriesExamItems)
                .ThenInclude(m=>m.Exam)
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();

            foreach (var item in seriesExam.SeriesExamItems)
            {
                if (item.ExamId!= seriesExam.SelectedExamId)
                {
                    var tempExam = await _context.Exams.Where(m => m.Id == item.ExamId).FirstOrDefaultAsync();
                    tempExam.IsNotCountable = true;
                    _context.Update(tempExam);
                    await _context.SaveChangesAsync();
                }

            }
            seriesExam.Status = 1;
            _context.Update(seriesExam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: SeriesExams/Edit/5
        public async Task<IActionResult> AddExams(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seriesExam = await _context.SeriesExams
                .Include(c => c.ClassRoom.Course)
                .Include(c => c.ClassRoom.Section)
                .Include(c => c.ClassRoom.Course)
                .Include(c => c.ClassRoom)
                .Include(c => c.SelectedExam)
                .Include(c => c.SeriesExamItems)
                .ThenInclude(c => c.Exam)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seriesExam == null)
            {
                return NotFound();
            }
            if (seriesExam.Status!=0)
            {
                return NotFound();
            }

            var exams = await _context.Exams
                .Where(m => m.ClassRoomId == id)
                .ToListAsync();
            
            foreach (var seriesTempExam in seriesExam.SeriesExamItems)
            {
               
                    exams.Remove(seriesTempExam.Exam);
               
            }
            
            ViewData["Exam"] = exams;

            return View(seriesExam);
        }



        [HttpPost]
        public async Task<JsonResult> AddExamToSeries(int examId, int seriesExamId)
        {


            SeriesExamItem seriesExamItem = new SeriesExamItem();
            seriesExamItem.ExamId = examId;
            seriesExamItem.SeriesExamId = seriesExamId;
            _context.Add(seriesExamItem);
            await _context.SaveChangesAsync();
            return Json(true);

        }
        [HttpPost]
        public async Task<JsonResult> GetExamById(int examId)
        {

            var exam = await _context.Exams.Where(m => m.Id == examId).FirstOrDefaultAsync();

            return Json(exam);

        }

        [HttpPost]
        public async Task<JsonResult> DeleteExamFromSeries( int seriesExamItemId)
        {

            var seriesExamItem = await _context.SeriesExamItems.Where(m => m.Id == seriesExamItemId).FirstOrDefaultAsync();
            _context.Remove(seriesExamItem);
            await _context.SaveChangesAsync();
            return Json(true);

        }


        // GET: SeriesExams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seriesExam = await _context.SeriesExams
                .Include(s => s.ClassRoom.AcademicSession)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seriesExam == null)
            {
                return NotFound();
            }

            return View(seriesExam);
        }

        // POST: SeriesExams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seriesExam = await _context.SeriesExams.FindAsync(id);
            _context.SeriesExams.Remove(seriesExam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeriesExamExists(int id)
        {
            return _context.SeriesExams.Any(e => e.Id == id);
        }
    }
}
