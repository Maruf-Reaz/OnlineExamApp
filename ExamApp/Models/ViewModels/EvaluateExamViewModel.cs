using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models.ViewModels
{
    public class EvaluateExamViewModel
    {

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }

         public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public double ExamMark { get; set; }
        public double ObtainedMark { get; set; }
        public double PercentageMark { get; set; }

        public int Status { get; set; }
    }
}
