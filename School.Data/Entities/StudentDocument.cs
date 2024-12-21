namespace School.Data.Entities
{
    public class StudentDocument : BaseEntity
    {
        public int StudentId { get; set; }

        [Required]
        [StringLength(100)]
        public string DocumentName { get; set; }

        [Required]
        public string FilePath { get; set; }

        public DocumentType DocumentType { get; set; }

        public DateTime UploadDate { get; set; }

        public virtual Student Student { get; set; }
    }
}
