using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public int NumericValue { get; set; }
        


        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Student> Students { get; set; }
    }
}
