
using Microsoft.AspNetCore.Identity;


namespace ExamApp.Models.Common.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }

        public int? InstitutionId { get; set; }
        public Institution Institution { get; set; }
        
    }
}
