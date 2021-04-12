using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
        public double TotalMark { get; set; }

        public bool IsNotCountable { get; set; }

        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }
         public int ExamTypeId { get; set; }
        public ExamType ExamType { get; set; }
        public int Status { get; set; }

        public bool HasSets { get; set; }
        public int? TotalQuestions { get; set; }
        public double? EachQuestionMark { get; set; }

        public List<Question> Questions { get; set; }
    }
}
