using School.Core.Features.Students.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        // Configure mapping from Student entity to GetStudentsListResponse DTO
        CreateMap<Student, GetStudentsListDTO>()
              .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : "Unknown"))
              .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.StudentSubjects != null ? (src.StudentSubjects.Select(ss => ss.Subject.Name).ToList()) : new List<string>()));




    }
}
