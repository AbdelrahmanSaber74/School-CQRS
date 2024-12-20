﻿namespace School.Data.Entities
{
    public class StudentSubject
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public decimal? Grade { get; set; }
        public GradeStatus GradeStatus { get; set; } = GradeStatus.NotGraded;

        // Navigation properties
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
