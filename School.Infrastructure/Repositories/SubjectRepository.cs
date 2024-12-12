namespace School.Infrastructure.Repositories
{
    public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
    {
        private readonly DbSet<Subject> _subject;

        public SubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _subject = dbContext.Set<Subject>();
        }

    }
}
