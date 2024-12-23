namespace School.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _departmentRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Department>> GetDepartmentsListAsync()
        {
            return await _departmentRepository.GetAllAsync();
        }
        public async Task<bool> DepartmentExists(int departmentId)
        {
            return await _departmentRepository.ExistsAsync(d => d.Id == departmentId);
        }
    }
}
