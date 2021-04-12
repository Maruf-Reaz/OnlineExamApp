using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models
{
    public class Question
    {
        public int Id { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public int QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }

        public string Description { get; set; }
        public string Opton1 { get; set; }
        public string Opton2 { get; set; }
        public string Opton3 { get; set; }
        public string Opton4 { get; set; }

        public int CorrectAnswer { get; set; }


        public bool IsOption1Correct { get; set; }
        public bool IsOption2Correct { get; set; }
        public bool IsOption3Correct { get; set; }
        public bool IsOption4Correct { get; set; }


        public bool TrueFalseAnswer { get; set; }
        public string FillInTheBlanksAnswer { get; set; }

        public double Mark { get; set; }
        public double ActualMark { get; set; }
        
        public string PhotoName1 { get; set; }
        public string PhotoName2 { get; set; }
        public string PhotoName3 { get; set; }
        public string PhotoName4 { get; set; }
        public string PhotoName5 { get; set; }
        public List<StudentQuestion> StudentQuestions { get; set; }

    }
}
