namespace School.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommand : IRequest<Response<string>>
    {
        public string StudentId { get; set; }

        public DeleteStudentCommand(string studentId)
        {
            StudentId = studentId;
        }

    }
}
