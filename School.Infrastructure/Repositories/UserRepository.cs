namespace School.Infrastructure.Abstracts
{
    public class UserRepository : GenericRepositoryAsync<ApplicationUser>, IUserRepository
    {
        private readonly DbSet<ApplicationUser> _users;

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _users = dbContext.Set<ApplicationUser>();
        }
    }
}
