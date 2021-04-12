using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models
{
    public class StudentAnswer
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
         public int StudentId { get; set; }
        public Student Student { get; set; }



        public string DetailedAnswer { get; set; }
        public string FillInTheGapAnswer { get; set; }


        public bool IsOption1Correct { get; set; }
        public bool IsOption2Correct { get; set; }
        public bool IsOption3Correct { get; set; }
        public bool IsOption4Correct { get; set; }

        public int MultipleChoiceANswer { get; set; }
        public int Status { get; set; }

        public bool TrueFalseAnswer { get; set; }

        public double ObtailedMark { get; set; }
        public double ActualObtailedMark { get; set; }

        public string PhotoName1 { get; set; }
        public string PhotoName2 { get; set; }
        public string PhotoName3 { get; set; }
        public string PhotoName4 { get; set; }
        public string PhotoName5 { get; set; }

    }
}
