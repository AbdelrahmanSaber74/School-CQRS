﻿namespace School.Data.Entities;
public class SubjectMaterial : BaseEntity
{
    public int SubjectId { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    [Required]
    public string FilePath { get; set; }

    public MaterialType Type { get; set; }

    public DateTime UploadDate { get; set; }

    public virtual Subject Subject { get; set; }
}