namespace School.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        private readonly DbSet<Department> _department;

        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _department = dbContext.Set<Department>();
        }

    }
}
