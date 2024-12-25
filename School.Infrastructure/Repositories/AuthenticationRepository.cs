namespace School.Infrastructure.Repositories
{
    public class AuthenticationRepository : GenericRepositoryAsync<ApplicationUser>, IAuthenticationRepository
    {
        private readonly DbSet<ApplicationUser> _users;

        public AuthenticationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _users = dbContext.Set<ApplicationUser>();
        }
    }
}
