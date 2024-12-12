   namespace School.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<Response<string>>
    {
        public AddStudentDTO Student { get; set; }

        public AddStudentCommand(AddStudentDTO student)
        {
            Student = student;
        }

    }
}
