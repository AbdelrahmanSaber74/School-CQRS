namespace School.Data.Consts
{
    public static class Router
    {
        private const string BaseApi = "/api";

        public static class Students
        {
            public const string GetById = $"{BaseApi}/GetById/{{id}}";
            public const string GetAll = $"{BaseApi}/GetAllStudents";
            public const string AddStudent = $"{BaseApi}/AddStudent";
            public const string EditStudent = $"{BaseApi}/EditStudent";
        }
    }

}
