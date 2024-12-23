namespace School.Service.Abstracts
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartmentsListAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
    }
}
