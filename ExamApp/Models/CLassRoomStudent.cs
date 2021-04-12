using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models
{
    public class ClassRoomStudent
    {


        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
