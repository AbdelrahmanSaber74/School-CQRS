using School.Core.Dto;

namespace School.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Response<StudentDTO>>
    {

        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;

        }


    }
}
