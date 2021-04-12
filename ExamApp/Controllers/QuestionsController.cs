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
using ExamApp.Models.ViewModels;

namespace ExamApp.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public QuestionsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }




        public async Task<IActionResult> AddQuestions(int? examId)
        {
            if (examId == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams
                .Include(c => c.ClassRoom)
                .Include(c => c.ClassRoom.Section)
                .Include(c => c.ClassRoom.Teacher)
                .Include(c => c.ClassRoom.Course)
                .Include(c => c.Questions)
                .ThenInclude(c => c.QuestionType)
                .Include(c => c.ExamType)
                .FirstOrDefaultAsync(m => m.Id == examId);
            if (exam == null)
            {
                return NotFound();
            }


            var questionTypes = await _context.QuestionTypes.ToListAsync();

            ViewData["ExamId"] = examId;

            ViewData["QuestionTypeId"] = new SelectList(questionTypes, "Id", "Name");
            ViewData["Exam"] = exam;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddQuestions(Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction("AddQuestions", new { examId = question.ExamId });
            }
            ViewData["ExamId"] = new SelectList(_context.Exams, "Id", "Id", question.ExamId);
            ViewData["QuestionTypeId"] = new SelectList(_context.QuestionTypes, "Id", "Id", question.QuestionTypeId);
            var questionTypes = await _context.QuestionTypes.ToListAsync();
            var exam = await _context.Exams
              .Include(c => c.ClassRoom)
              .Include(c => c.ClassRoom.Section)
              .Include(c => c.ClassRoom.Teacher)
              .Include(c => c.ClassRoom.Course)
              .Include(c => c.Questions)
              .ThenInclude(c => c.QuestionType)
              .Include(c => c.ExamType)
              .FirstOrDefaultAsync(m => m.Id == question.ExamId);
            ViewData["ExamId"] = question.ExamId;

            ViewData["QuestionTypeId"] = new SelectList(questionTypes, "Id", "Name");
            ViewData["QuestionTypeId"] = questionTypes;
            ViewData["Exam"] = exam;
            return View(question);
        }





        public IActionResult DeleteQuestion(int id)
        {
            var question = _context.Questions.Where(m => m.Id == id).FirstOrDefault();

            _context.Remove(question);
            _context.SaveChanges();
            return RedirectToAction("AddQuestions", new { examId = question.ExamId });
        }

        public async Task<IActionResult> ParticipateInExam(int? examId)
        {
            if (examId == null)
            {
                return NotFound();
            }

            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var student = await _context.Students.Where(m => m.ApplicationUserId == loggedInUser.Id).FirstOrDefaultAsync();
            var answers = await _context.StudentAnswers
                .Include(c => c.Question)
                .Include(c => c.Question.Exam)
                .Include(c => c.Student)
                .Where(m => m.StudentId == student.Id && m.Question.ExamId == examId)
                .ToListAsync();


            var exam = await _context.Exams
                .Include(c => c.ClassRoom)
                .Include(c => c.ClassRoom.Section)
                .Include(c => c.ClassRoom.Teacher)
                .Include(c => c.ClassRoom.Course)
                .Include(c => c.ExamType)
                .FirstOrDefaultAsync(m => m.Id == examId);

            if (exam.Status!=1)
            {
                return NotFound();
            }


            var questions = await _context.StudentQuestions.Where(m => m.StudentId == student.Id && m.Question.ExamId== exam.Id)
                .Include(m=> m.Question)
                .Include(m=> m.Question.QuestionType)
                .Include(m=> m.Question.Exam)
                .Include(m=> m.Question.Exam.ClassRoom)
                .ToListAsync();

            List<ParticipateQuestionViewModel> participateQuestionViewModels = new List<ParticipateQuestionViewModel>();


            foreach (var TempQ in questions)
            {
                ParticipateQuestionViewModel participateQuestionViewModel = new ParticipateQuestionViewModel();
                participateQuestionViewModel.Question = TempQ.Question;
                participateQuestionViewModel.QuestionId = TempQ.QuestionId;

                if (TempQ.Question.QuestionTypeId==2)
                {
                    List<int> tempOptionList = new List<int>();
                    tempOptionList.Add((int)TempQ.First);
                    tempOptionList.Add((int)TempQ.Second);
                    tempOptionList.Add((int)TempQ.Third);
                    tempOptionList.Add((int)TempQ.Fourth);
                    participateQuestionViewModel.Options = tempOptionList;
                }
                

                participateQuestionViewModels.Add(participateQuestionViewModel);

            }
           
            

            if (exam == null)
            {
                return NotFound();
            }


            var questionTypes = await _context.QuestionTypes.ToListAsync();

            ViewData["ExamId"] = examId;

            ViewData["Questions"] = participateQuestionViewModels;
            ViewData["Exam"] = exam;
            ViewData["Answers"] = answers;

            return View();
        }

        public async Task<IActionResult> EvaluateExam(int? studentId, int? examId)
        {
            if (examId == null)
            {
                return NotFound();
            }

            var studnet = await _context.Students.Where(m => m.Id == studentId).FirstOrDefaultAsync();


            var answers = await _context.StudentAnswers
                .Include(c => c.Question)
                .Include(c => c.Question.Exam)
                .Include(c => c.Student)
                .Where(m => m.StudentId == studentId && m.Question.ExamId == examId)
                .ToListAsync();


            var exam = await _context.Exams
                .Include(c => c.ExamType)
                .Include(c => c.ClassRoom)
                .Include(c => c.ClassRoom.Section)
                .Include(c => c.ClassRoom.Teacher)
                .Include(c => c.ClassRoom.Course)
                .Include(c => c.ExamType)
                .FirstOrDefaultAsync(m => m.Id == examId);

            var questions = await _context.StudentQuestions.Where(m => m.StudentId == studnet.Id && m.Question.ExamId == exam.Id)
            .Include(m => m.Question)
            .Include(m => m.Question.QuestionType)
            .Include(m => m.Question.Exam)
            .Include(m => m.Question.Exam.ClassRoom)
            .ToListAsync();
            if (exam == null)
            {
                return NotFound();
            }


            var questionTypes = await _context.QuestionTypes.ToListAsync();

            ViewData["ExamId"] = examId;

            ViewData["Exam"] = exam;
            ViewData["Questions"] = questions;
            ViewData["Student"] = studnet;
            ViewData["Answers"] = answers;

            return View();
        }
        public async Task<IActionResult> ViewExam(int? studentId, int? examId)
        {
            if (examId == null)
            {
                return NotFound();
            }

            var studnet = await _context.Students.Where(m => m.Id == studentId).FirstOrDefaultAsync();


            var answers = await _context.StudentAnswers
                .Include(c => c.Question)
                .Include(c => c.Question.Exam)
                .Include(c => c.Student)
                .Where(m => m.StudentId == studentId && m.Question.ExamId == examId)
                .ToListAsync();


            var exam = await _context.Exams
                .Include(c => c.ExamType)
                .Include(c => c.ClassRoom)
                .Include(c => c.ClassRoom.Section)
                .Include(c => c.ClassRoom.Teacher)
                .Include(c => c.ClassRoom.Course)
                .Include(c => c.ExamType)
                .FirstOrDefaultAsync(m => m.Id == examId);

            var questions = await _context.StudentQuestions.Where(m => m.StudentId == studnet.Id && m.Question.ExamId == exam.Id)
              .Include(m => m.Question)
              .Include(m => m.Question.QuestionType)
              .Include(m => m.Question.Exam)
              .Include(m => m.Question.Exam.ClassRoom)
              .ToListAsync();



            if (exam == null)
            {
                return NotFound();
            }


            var questionTypes = await _context.QuestionTypes.ToListAsync();

            ViewData["ExamId"] = examId;

            ViewData["Exam"] = exam;
            ViewData["Questions"] = questions;
            ViewData["Student"] = studnet;
            ViewData["Answers"] = answers;

            return View();
        }

        public async Task<IActionResult> EvaluateExamIndex(int? examId)
        {
            if (examId == null)
            {
                return NotFound();
            }
            var exam = await _context.Exams
                .Include(c => c.ClassRoom)
                .ThenInclude(c => c.ClassRoomStudents)
                .ThenInclude(c => c.Student)
                .Where(m=>m.Id == examId)
                .FirstOrDefaultAsync();
            if (exam == null)
            {
                return NotFound();
            }

            List<EvaluateExamViewModel> evaluetedStudents = new List<EvaluateExamViewModel>();
            foreach (var student in exam.ClassRoom.ClassRoomStudents)
            {
                EvaluateExamViewModel evaluateExamViewModel = new EvaluateExamViewModel();
                evaluateExamViewModel.Student = student.Student;
                evaluateExamViewModel.StudentId = student.StudentId;

                var allAnswers = _context.StudentAnswers
                    .Include(m=>m.Question)
                  .Where(m => m.Question.ExamId == exam.Id && m.StudentId == student.StudentId )
                  .ToList();

                var allquestions = _context.StudentQuestions
                     .Include(m => m.Question)
                 .Where(m => m.Question.ExamId == exam.Id && m.StudentId == student.StudentId)
                 .ToList();
                evaluateExamViewModel.ObtainedMark = (double)allAnswers.Sum(m => m.ActualObtailedMark);
                evaluateExamViewModel.ExamMark = (double)allquestions.Sum(m => m.Question.ActualMark);
                var unSavedAnswer = allAnswers.Where(m => m.Status == 0).FirstOrDefault();
                if (unSavedAnswer == null && allAnswers.Count != 0)
                {
                    evaluateExamViewModel.Status = 1;
                }
                else if (allAnswers.Count == 0)
                {
                    evaluateExamViewModel.Status = 404;
                }
                else
                {
                    evaluateExamViewModel.Status = 0;
                }
                evaluetedStudents.Add(evaluateExamViewModel);
            }

            var questionTypes = await _context.QuestionTypes.ToListAsync();

            ViewData["ExamId"] = examId;
            return View(evaluetedStudents);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAnswer(StudentAnswer answer)
        {
            var question = await _context.Questions.Where(m => m.Id == answer.QuestionId).FirstOrDefaultAsync();
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var student = await _context.Students.Where(m => m.ApplicationUserId == loggedInUser.Id).FirstOrDefaultAsync();
            if (answer.Id == 0)
            {
                answer.StudentId = student.Id;
                answer.Status = 0;
                _context.Add(answer);
                await _context.SaveChangesAsync();

            }

            else
            {
                answer.StudentId = student.Id;
                _context.Update(answer);
                await _context.SaveChangesAsync();

            }
            return RedirectToAction("ParticipateInExam", new { examId = question.ExamId });
        }


        [HttpPost]
        public async Task<JsonResult> SaveAnswerMark(int answerId, int obtainedMark)
        {
            var answer = await _context.StudentAnswers.Where(m => m.Id == answerId).FirstOrDefaultAsync();
            answer.ObtailedMark = obtainedMark;
            answer.Status = 1;
            _context.Update(answer);
            await _context.SaveChangesAsync();
            return Json(true);

        }
        public async Task<IActionResult> CourseStat(int classRoomId)
        {
            var loggedInUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var classRoom = await _context.ClassRooms
                 .Include(m => m.ClassRoomStudents)
                 .ThenInclude(m => m.Student)
                .Where(m => m.Id == classRoomId).FirstOrDefaultAsync();

            List<EvaluateExamViewModel> evaluetedStudents = new List<EvaluateExamViewModel>();
            foreach (var student in classRoom.ClassRoomStudents)
            {
                EvaluateExamViewModel evaluateExamViewModel = new EvaluateExamViewModel();
                evaluateExamViewModel.Student = student.Student;
                evaluateExamViewModel.StudentId = student.StudentId;

                var allAnswers = _context.StudentAnswers
                     .Include(m => m.Question)
                     .Include(m => m.Question.Exam)
                  .Where(m => m.Question.Exam.ClassRoomId == classRoom.Id && m.StudentId == student.StudentId && m.Question.Exam.IsNotCountable==false)
                  .ToList();

                var allquestions = _context.StudentQuestions
                      .Include(m => m.Question)
                     .Include(m => m.Question.Exam)
                 .Where(m => m.Question.Exam.ClassRoomId == classRoom.Id && m.Question.Exam.IsNotCountable==false && m.StudentId == student.StudentId)
                 .ToList();
                evaluateExamViewModel.ObtainedMark = (double)allAnswers.Sum(m => m.ActualObtailedMark);
                evaluateExamViewModel.ExamMark = (double)allquestions.Sum(m => m.Question.ActualMark);
                if (evaluateExamViewModel.ExamMark==0 && evaluateExamViewModel.ObtainedMark==0)
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

            return View(evaluetedStudents);
        }
    }
}
