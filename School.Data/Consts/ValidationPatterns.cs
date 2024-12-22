namespace School.Data.Consts
{
    public static class ValidationPatterns
    {
        public const string PhoneNumber = @"^\+?[1-9]\d{1,14}$";
        public const string PostalCode = @"^\d{5}$";
        public const string NationalId = @"^\d{14}$";

    }
}
