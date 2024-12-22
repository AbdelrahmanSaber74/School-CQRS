namespace School.Core.Resources
{
    public static class ResourceKeys
    {
        // General Resource Keys
        public const string WelcomeMessage = "WelcomeMessage";
        public const string NotFound = "NotFound";
        public const string DeletedSuccessfully = "DeletedSuccessfully";
        public const string OperationCompletedSuccessfully = "OperationCompletedSuccessfully";
        public const string Unauthorized = "Unauthorized";
        public const string UnprocessableEntity = "UnprocessableEntity";
        public const string BadRequest = "BadRequest";
        public const string CreatedSuccessfully = "CreatedSuccessfully";

        // Student Resource Keys
        public const string StudentAddedSuccessfully = "StudentAddedSuccessfully";
        public const string AddStudentFailed = "AddStudentFailed";
        public const string StudentUpdatedSuccessfully = "StudentUpdatedSuccessfully";
        public const string StudentNotFound = "StudentNotFound";
        public const string DeleteStudentFailed = "DeleteStudentFailed";

        // Validation Messages Keys
        public const string NameRequired = "NameRequired";
        public const string NameMaxLength = "NameMaxLength";
        public const string AlreadyExistsMessage = "AlreadyExistsMessage";

        public const string PhoneRequired = "PhoneRequired";
        public const string PhoneInvalidFormat = "PhoneInvalidFormat";
        public const string PhoneAlreadyExists = "PhoneAlreadyExists";

        public const string EmailRequired = "EmailRequired";
        public const string EmailInvalidFormat = "EmailInvalidFormat";
        public const string EmailAlreadyExists = "EmailAlreadyExists";

        public const string DateOfBirthRequired = "DateOfBirthRequired";
        public const string DateOfBirthPast = "DateOfBirthPast";

        public const string EnrollmentDateRequired = "EnrollmentDateRequired";
        public const string EnrollmentDatePastOrToday = "EnrollmentDatePastOrToday";

        public const string DepartmentIdGreaterThanZero = "DepartmentIdGreaterThanZero";
        public const string DepartmentNotFound = "DepartmentNotFound";

        public const string SurnameRequired = "SurnameRequired";
        public const string SurnameMaxLength = "SurnameMaxLength";

        // New Validation Messages Keys for Additional Fields
        public const string CityRequired = "CityRequired";
        public const string CountryRequired = "CountryRequired";
        public const string NationalIdRequired = "NationalIdRequired";
        public const string NationalIdInvalidFormat = "NationalIdInvalidFormat";
        public const string PostalCodeRequired = "PostalCodeRequired";
        public const string PostalCodeInvalidFormat = "PostalCodeInvalidFormat";
        public const string EmergencyContactNameRequired = "EmergencyContactNameRequired";
        public const string EmergencyContactPhoneRequired = "EmergencyContactPhoneRequired";
        public const string EmergencyContactRelationRequired = "EmergencyContactRelationRequired";
    }
}
