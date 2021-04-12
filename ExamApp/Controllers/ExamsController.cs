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
    public class ExamsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ExamsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Exams
        public async Task<IActionResult> Index(int classRoomId)
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var applicationDbContext = _context.Exams.Include(e => e.ClassRoom).Include(e => e.ExamType).Where(m => m.ClassRoomId == classRoomId);
            ViewData["ClassRoomId"] = classRoomId;
            int i = 0;
            if ((await _userManager.IsInRoleAsync(loggedInUser, "Admin")))
            {
                i = 1;
            }
            if ((await _userManager.IsInRoleAsync(loggedInUser, "Teacher")))
            {
                i = 2;
            }
            if ((await _userManager.IsInRoleAsync(loggedInUser, "Student")))
            {
                i = 3;
                var student = await _context.Students.Where(m => m.ApplicationUserId == loggedInUser.Id).FirstOrDefaultAsync();
                ViewData["Student"] = student;
            }

            ViewData["UserType"] = i;

            return View(await applicationDbContext.ToListAsync());
        }






        // GET: Exams/Create
        public IActionResult Create(int classRoomId)
        {
            ViewData["ClassRoomId"] = classRoomId;
            ViewData["ExamTypeId"] = new SelectList(_context.ExamTypes, "Id", "Name");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Exam exam)
        {
            if (ModelState.IsValid)
            {
                exam.Status = 0;
                _context.Add(exam);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { classRoomId = exam.ClassRoomId });
            }

            ViewData["ClassRoomId"] = exam.ClassRoomId;
            ViewData["ExamTypeId"] = new SelectList(_context.ExamTypes, "Id", "Name", exam.ExamTypeId);
            return View(exam);
        }

        // GET: Exams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            ViewData["ExamTypeId"] = new SelectList(_context.ExamTypes, "Id", "Name", exam.ExamTypeId);
            return View(exam);
        }
         // GET: Exams/Edit/5
     

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Exam exam)
        {
            if (id != exam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    exam.Status = 0;
                    _context.Update(exam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamExists(exam.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { classRoomId = exam.ClassRoomId });
            }
            ViewData["ExamTypeId"] = new SelectList(_context.ExamTypes, "Id", "Name", exam.ExamTypeId);
            return View(exam);
        }


        private bool ExamExists(int id)
        {
            return _context.Exams.Any(e => e.Id == id);
        }

        public async Task<IActionResult> StartExam(int? examId)
        {
            if (examId == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams.Where(m => m.Id == examId)
                .Include(m=>m.Questions)
                .Include(m=>m.ClassRoom)
                .Include(m=>m.ClassRoom.ClassRoomStudents)
                .FirstOrDefaultAsync();

            if (exam == null)
            {
                return NotFound();
            }

            else
            {

                foreach (var student in exam.ClassRoom.ClassRoomStudents)
                {
                    var shuffleQuestions = exam.Questions.OrderBy(a => Guid.NewGuid()).ToList();
                    if (exam.HasSets)
                    {
                        var firstNQuestions = shuffleQuestions.Take((int)exam.TotalQuestions);

                        foreach (var question in firstNQuestions)
                        {
                            StudentQuestion studentQuestion = new StudentQuestion();
                            studentQuestion.StudentId = student.StudentId;
                            studentQuestion.QuestionId = question.Id;

                            if (question.QuestionTypeId==2)
                            {
                                Random rnd = new Random();
                                List<int> temp = new List<int>();
                                while (temp.Count != 4)
                                {
                                    int tempVar = rnd.Next(1, 5);
                                    if (temp.Contains(tempVar))
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        temp.Add(tempVar);

                                    }
                                 
                                }
                                studentQuestion.First = temp[0];
                                studentQuestion.Second = temp[1];
                                studentQuestion.Third = temp[2];
                                studentQuestion.Fourth = temp[3];
                            }
                            
                            _context.Add(studentQuestion);
                            await _context.SaveChangesAsync();
                        }
                    }
                    else
                    {
                        foreach (var question in shuffleQuestions)
                        {
                            StudentQuestion studentQuestion = new StudentQuestion();
                            studentQuestion.StudentId = student.StudentId;
                            studentQuestion.QuestionId = question.Id;

                            if (question.QuestionTypeId == 2)
                            {
                                Random rnd = new Random();
                                List<int> temp = new List<int>();
                                while (temp.Count != 4)
                                {
                                    int tempVar = rnd.Next(1, 5);
                                    if (temp.Contains(tempVar))
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        temp.Add(tempVar);

                                    }
                                  

                                }
                                studentQuestion.First = temp[0];
                                studentQuestion.Second = temp[1];
                                studentQuestion.Third = temp[2];
                                studentQuestion.Fourth = temp[3];
                            }


                            _context.Add(studentQuestion);
                            await _context.SaveChangesAsync();
                        }
                    }


                }



                if (exam.HasSets)
                {
                    double tempTotalMark =(double) (exam.TotalQuestions * exam.EachQuestionMark);
                    foreach (var question in exam.Questions)
                    {


                        question.ActualMark = (question.Mark * exam.TotalMark) / tempTotalMark;
                        _context.Update(question);
                        await _context.SaveChangesAsync();

                    }
                }
                else
                {
                    double tempTotalMark = (double)exam.Questions.Sum(m => m.Mark); 
                    foreach (var question in exam.Questions)
                    {
                        question.ActualMark = (question.Mark * exam.TotalMark) / tempTotalMark;
                        _context.Update(question);
                        await _context.SaveChangesAsync();

                    }
                }


                    exam.Status = 1;
                _context.Update(exam);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { classRoomId = exam.ClassRoomId });
            }
            
        }

        public async Task<IActionResult> EndExam(int? examId)
        {
            if (examId == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams.Where(m => m.Id == examId).FirstOrDefaultAsync(); ;
            if (exam == null)
            {
                return NotFound();
            }

            else
            {

                var classRoomStudents = await _context.ClassRoomStudents
                    .Include(m=> m.ClassRoom)
                    .Include(m=> m.Student)
                    .Where(m => m.ClassRoomId == exam.ClassRoomId).ToListAsync();
                foreach (var student in classRoomStudents)
                {
                    var allAnswers = await _context.StudentAnswers
                        .Include(m=> m.Question)
                        .Where(m => m.Question.ExamId == exam.Id && m.StudentId == student.StudentId).ToListAsync();

                    foreach (var answer in allAnswers)
                    {
                        if (answer.Question.QuestionTypeId==2)
                        {
                            if (answer.Question.IsOption1Correct == answer.IsOption1Correct && answer.Question.IsOption2Correct == answer.IsOption2Correct &&answer.Question.IsOption3Correct == answer.IsOption3Correct &&answer.Question.IsOption4Correct == answer.IsOption4Correct)
                            {
                                answer.ObtailedMark = answer.Question.Mark;
                                answer.ActualObtailedMark = answer.Question.ActualMark;
                                answer.Status = 1;
                                _context.Update(answer);
                                await _context.SaveChangesAsync();
                            }
                            else
                            {
                                answer.ObtailedMark =0;
                                answer.ActualObtailedMark =0;
                                answer.Status = 1;
                                _context.Update(answer);
                                await _context.SaveChangesAsync();
                            }
                            //var answer = await _context.StudentAnswers.Where(m => m.Id == answerId).FirstOrDefaultAsync();
                            //answer.ObtailedMark = obtainedMark;
                            //answer.Status = 1;
                        }

                        else if (answer.Question.QuestionTypeId == 3)
                        {
                            if (answer.Question.TrueFalseAnswer == answer.TrueFalseAnswer)
                            {
                                answer.ObtailedMark = answer.Question.Mark;
                                answer.ActualObtailedMark = answer.Question.ActualMark;
                                answer.Status = 1;
                                _context.Update(answer);
                                await _context.SaveChangesAsync();
                            }
                            else
                            {
                                answer.ObtailedMark = 0;
                                answer.ActualObtailedMark = 0;
                                answer.Status = 1;
                                _context.Update(answer);
                                await _context.SaveChangesAsync();
                            }
                        }


                    }


                }



                exam.Status = 2;
                _context.Update(exam);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { classRoomId = exam.ClassRoomId });
            }
        }
        [HttpPost]
        public async Task<JsonResult> GetAllExams(int classRoomId)
        {
            var classRoom = await _context.ClassRooms.Where(m => m.Id == classRoomId)
                .FirstOrDefaultAsync();

            var exams = await _context.Exams.Where(m => m.ClassRoom.TeacherId == classRoom.TeacherId && m.ClassRoom.CourseId == classRoom.CourseId)
                .Include(m=> m.ClassRoom.AcademicSession)
                .Include(m=> m.ClassRoom)
                .Include(m=> m.ClassRoom.Section)
                .ToListAsync();


            return Json(exams);

        }
         [HttpPost]
        public async Task<JsonResult> AddExamQuestionsFromPreviousExam(int selectedExamId,int examId)
        {
            var questions = await _context.Questions.Where(m => m.ExamId == selectedExamId)
                .ToListAsync();

            if (questions.Count!=0)
            {
                foreach (var question in questions)
                {
                    Question tempQuestion = new Question();
                    tempQuestion.ExamId = examId;
                    tempQuestion.QuestionTypeId = question.QuestionTypeId;
                    tempQuestion.CorrectAnswer = question.CorrectAnswer;
                    tempQuestion.Description = question.Description;
                    tempQuestion.Opton1 = question.Opton1;
                    tempQuestion.Opton2 = question.Opton2;
                    tempQuestion.Opton3 = question.Opton3;
                    tempQuestion.Opton4 = question.Opton4;
                    tempQuestion.IsOption1Correct = question.IsOption1Correct;
                    tempQuestion.IsOption2Correct = question.IsOption2Correct;
                    tempQuestion.IsOption3Correct = question.IsOption3Correct;
                    tempQuestion.IsOption4Correct = question.IsOption4Correct;


                    tempQuestion.TrueFalseAnswer = question.TrueFalseAnswer;
                    tempQuestion.FillInTheBlanksAnswer = question.FillInTheBlanksAnswer;
                    tempQuestion.Mark = question.Mark;
                    _context.Add(tempQuestion);
                    await _context.SaveChangesAsync();
                }

                return Json(true);
            }
            else
            {
                return Json(false);
            }
          
         

        }

        

    }
}
