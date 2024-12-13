namespace School.Data.Consts
{
    public static class ValidationMessages
    {
        public const string NameRequired = "Name is required.";
        public const string NameMaxLength = "Name cannot exceed 100 characters.";
        public const string PhoneRequired = "Phone number is required.";
        public const string PhoneInvalidFormat = "Phone number format is invalid.";
        public const string EmailRequired = "Email is required.";
        public const string EmailInvalidFormat = "Invalid email format.";
        public const string DateOfBirthRequired = "Date of birth is required.";
        public const string DateOfBirthPast = "Date of birth must be in the past.";
        public const string EnrollmentDateRequired = "Enrollment date is required.";
        public const string EnrollmentDatePastOrToday = "Enrollment date cannot be in the future.";
        public const string DepartmentIdGreaterThanZero = "Department ID must be greater than 0.";
    }

}
