using ExamApp.Models.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdNo { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }
        
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public List<ClassRoomStudent> ClassRoomStudents { get; set; }
        public List<StudentQuestion> StudentQuestions { get; set; }
    }
}
