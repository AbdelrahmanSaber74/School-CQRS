namespace School.Infrastructure.Context
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(20)]
        public string? PhoneNumber { get; set; }

    }

}
