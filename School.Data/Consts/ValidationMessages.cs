namespace School.Data.Consts
{
    public static class ValidationMessages
    {
        public const string NameRequired = "{PropertyName} is required.";
        public const string NameMaxLength = "{PropertyName} cannot exceed 100 characters.";
        public const string PhoneRequired = "{PropertyName} is required.";
        public const string PhoneInvalidFormat = "{PropertyName} format is invalid.";
        public const string EmailRequired = "{PropertyName} is required.";
        public const string EmailInvalidFormat = "{PropertyName} format is invalid.";
        public const string DateOfBirthRequired = "{PropertyName} is required.";
        public const string DateOfBirthPast = "{PropertyName} must be in the past.";
        public const string EnrollmentDateRequired = "{PropertyName} is required.";
        public const string EnrollmentDatePastOrToday = "{PropertyName} cannot be in the future.";
        public const string DepartmentIdGreaterThanZero = "{PropertyName} must be greater than 0.";
        public const string SurnameRequired = "{PropertyName} is required.";
        public const string SurnameMaxLength = "{PropertyName} cannot exceed 100 characters.";
    }
}
