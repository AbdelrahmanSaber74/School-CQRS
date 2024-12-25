using System.ComponentModel.DataAnnotations.Schema;

namespace School.Infrastructure.Context
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; } 

        [NotMapped] 
        public string FullName => $"{FirstName?.Trim()} {LastName?.Trim()}".Trim();
    }
}
