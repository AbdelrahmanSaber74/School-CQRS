namespace School.Data.Entities.Base
{
    public abstract class BaseEntity : IBaseEntity, IAuditableEntity, ISoftDeleteEntity
    {
        [Key]
        public int Id { get; set; }

        #region Status Properties
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        [MaxLength(100)]
        public string? DeletedBy { get; set; }
        public bool IsActive { get; set; } = true;
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        #endregion

        #region Audit Properties
        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [MaxLength(100)]
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        [MaxLength(100)]
        public string LastModifiedBy { get; set; }
        #endregion

        #region Concurrency Control
        [Timestamp]
        public byte[] RowVersion { get; set; }
        #endregion

        #region Metadata Properties
        [MaxLength(50)]
        public string? IpAddress { get; set; }

        [MaxLength(250)]
        public string? UserAgent { get; set; }
        public string? Metadata { get; set; }
        #endregion

        #region Methods
        public virtual void SetCreationProperties(string userId, string ipAddress = null)
        {
            CreatedAt = DateTime.UtcNow;
            CreatedBy = userId;
            IpAddress = ipAddress;
        }

        public virtual void SetModificationProperties(string userId, string ipAddress = null)
        {
            LastModifiedAt = DateTime.UtcNow;
            LastModifiedBy = userId;
            IpAddress = ipAddress;
        }

        public virtual void SoftDelete(string userId)
        {
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
            DeletedBy = userId;
            Status = EntityStatus.Deleted;
        }
        #endregion
    }
  
}

