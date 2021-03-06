using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models.ViewModels
{
    public class ParticipateQuestionViewModel
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }


        public List<int> Options { get; set; }

    }
}
