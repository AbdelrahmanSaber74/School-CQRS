namespace School.Data.Entities
{
    public class InstructorSchedule
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string RoomNumber { get; set; }
        public string BuildingName { get; set; }

        // Navigation Properties
        public virtual Instructor Instructor { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
