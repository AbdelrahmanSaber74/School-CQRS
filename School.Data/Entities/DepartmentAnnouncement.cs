namespace School.Data.Entities
{
    public class DepartmentAnnouncement : BaseEntity
    {
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public bool IsPinned { get; set; }

        public AnnouncementPriority Priority { get; set; }

        public virtual Department Department { get; set; }
    }

}
