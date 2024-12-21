namespace School.Data.Interface
{
    public interface ISoftDeleteEntity
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedAt { get; set; }
        string DeletedBy { get; set; }
    }
}
