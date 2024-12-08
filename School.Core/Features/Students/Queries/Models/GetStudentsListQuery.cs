﻿using MediatR;
using School.Data.Entities;

namespace School.Core.Features.Students.Queries.Models
{
    public class GetStudentsListQuery : IRequest<List<Student>>
    {


    }
}
