using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models
{
    public class Designation
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }

        public List<Teacher> Teachers { get; set; }
    }
}
