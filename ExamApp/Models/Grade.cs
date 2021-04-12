using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public double FromMark { get; set; }
        public double ToMark { get; set; }
        public string Alphabet { get; set; }
        public double Gpa { get; set; }
    }
}
