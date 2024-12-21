namespace School.Data.Interface
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        bool IsActive { get; set; }
        EntityStatus Status { get; set; }
    }

}
