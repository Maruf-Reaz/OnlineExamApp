using ExamApp.Models.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models
{
    public class Teacher
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string IdNo { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }


        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


        public List<Course> Courses { get; set; }
    }
}
