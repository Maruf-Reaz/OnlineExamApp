using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models
{
    public class SeriesExamItem
    {

        public int Id { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public int SeriesExamId { get; set; }
        public SeriesExam SeriesExam { get; set; }

     

    }
}
