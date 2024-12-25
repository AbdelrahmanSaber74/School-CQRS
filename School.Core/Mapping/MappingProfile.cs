using School.Core.Dto.Student;

namespace School.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping from Student entity to StudentDTO
            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.DepartmentName,
                    opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : "Unknown"))
                .ForMember(dest => dest.Subjects,
                    opt => opt.MapFrom(src => src.StudentSubjects != null
                        ? src.StudentSubjects.Select(ss => ss.Subject.Name).ToList()
                        : new List<string>()));

            // Mapping from AddStudentDTO to Student
            CreateMap<AddStudentDTO, Student>();

            CreateMap<Department, DepartmentDto>();

            // Mapping from EditStudentDTO to Student
            CreateMap<EditStudentDTO, Student>();

            CreateMap<CreateDTO, ApplicationUser>();

            // Mapping from PaginatedList<T> to PaginatedListDTO<T>
            CreateMap(typeof(PaginatedList<>), typeof(PaginatedListDTO<>))
                .ConvertUsing(typeof(PaginatedListConverter<,>));
        }
    }
}
