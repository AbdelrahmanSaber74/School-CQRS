using School.Core.Dto.Student;

namespace School.Core.Features.Students.Commands.Models
{
    public class EditStudentCommand : IRequest<Response<string>>
    {
        public EditStudentDTO EditStudentDTO { get; set; }

        public EditStudentCommand(EditStudentDTO studentDTO)
        {
            EditStudentDTO = studentDTO;
        }

    }
}
