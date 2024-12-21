namespace School.Data.Entities
{
    public class DepartmentResource : BaseEntity
    {
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public ResourceType Type { get; set; }

        public string Location { get; set; }

        public bool IsAvailable { get; set; }

        // Navigation Properties
        public virtual Department Department { get; set; }
    }
}
