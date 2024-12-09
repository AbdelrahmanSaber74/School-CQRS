namespace School.Infrastructure.Basics;
public interface IGenericRepositoryAsync<T> where T : class
{
    Task DeleteRangeAsync(ICollection<T> entities);
    Task<T> GetByIdAsync(int id);
    Task SaveChangesAsync();
    IDbContextTransaction BeginTransaction();
    void Commit();
    void RollBack();
    IQueryable<T> GetTableNoTracking();
    IQueryable<T> GetTableAsTracking();
    Task<T> AddAsync(T entity);
    Task AddRangeAsync(ICollection<T> entities);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(ICollection<T> entities);
    Task DeleteAsync(T entity);

    Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
    Task<int> CountAsync();
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> GetAllAsync();
    IQueryable<T> GetQueryable();

}
