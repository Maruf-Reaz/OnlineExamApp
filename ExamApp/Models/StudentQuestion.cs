using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models
{
    public class StudentQuestion
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int? First { get; set; }
        public int? Second { get; set; }
        public int? Third { get; set; }
        public int? Fourth { get; set; }
    }
}
