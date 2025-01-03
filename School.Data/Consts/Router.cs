﻿namespace School.Data.Consts
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

        public static class Users
        {
            public const string GetByEmail = $"{BaseApi}/users/GetByEmail";
            public const string GetAll = $"{BaseApi}/users/GetAll";
            public const string Add = $"{BaseApi}/users/Add";
            public const string Edit = $"{BaseApi}/users/Edit";
            public const string Delete = $"{BaseApi}/users/Delete";
        }

        public static class Authentication
        {
            public const string Login = $"{BaseApi}/auth/login";
            public const string Create = $"{BaseApi}/auth/Create";
            public const string Logout = $"{BaseApi}/auth/logout";
        }
    }
}
