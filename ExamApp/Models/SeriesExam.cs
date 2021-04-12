using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models
{
    public class SeriesExam
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Status { get; set; }

        public int? SelectedExamId { get; set; }
        public Exam SelectedExam { get; set; }

       
        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }

        public List<SeriesExamItem> SeriesExamItems { get; set; }
    }
}
