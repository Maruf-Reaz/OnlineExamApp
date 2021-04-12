using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models.Common.ViewModels
{
    public class TeacherCourseSectionViewModel
    {
        public List<Teacher> Teachers { get; set; }
        public List<Course> Courses { get; set; }
        public List<Section> Sections { get; set; }
    }
}
