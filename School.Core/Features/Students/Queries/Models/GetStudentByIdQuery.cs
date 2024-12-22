namespace School.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Response<StudentDTO>>
    {

        public string StudentId { get; set; }

        public GetStudentByIdQuery(string studentId)
        {
            StudentId = studentId;

        }


    }
}
