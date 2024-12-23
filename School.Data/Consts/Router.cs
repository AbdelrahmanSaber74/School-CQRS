namespace School.Data.Consts
{
    public static class Router
    {
        private const string BaseApi = "/api";

        public static class Students
        {
            public const string GetById = $"{BaseApi}/students/GetById";
            public const string GetAll = $"{BaseApi}/students/GetAll";
            public const string GetPaginated = $"{BaseApi}/students/GetPaginated";
            public const string Add = $"{BaseApi}/students/Add";
            public const string Edit = $"{BaseApi}/students/Edit";
            public const string Delete = $"{BaseApi}/students/Delete";
        }

        public static class Departments
        {
            public const string GetById = $"{BaseApi}/departments/GetById";
            public const string GetAll = $"{BaseApi}/departments/GetAll";
            public const string GetPaginated = $"{BaseApi}/departments/GetPaginated";
            public const string Add = $"{BaseApi}/departments/Add";
            public const string Edit = $"{BaseApi}/departments/Edit";
            public const string Delete = $"{BaseApi}/departments/Delete";
        }
    }
}
