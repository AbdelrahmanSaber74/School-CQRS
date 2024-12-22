namespace School.Core.Dto
{
    public class BaseDTO
    {
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public string Metadata { get; set; }
    }
}
