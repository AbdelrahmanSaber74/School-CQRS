namespace School.Data.Entities
{
    public class DepartmentSubject
    {
        public int? DepartmentId { get; set; }

        public int? SubjectId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; }
    }
}
