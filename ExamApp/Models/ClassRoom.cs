using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models
{
    public class ClassRoom
    {
        public int Id { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int Status { get; set; }
        public int AcademicSessionId { get; set; }
        public AcademicSession AcademicSession { get; set; }
        public List<ClassRoomStudent> ClassRoomStudents { get; set; }
    }
}
