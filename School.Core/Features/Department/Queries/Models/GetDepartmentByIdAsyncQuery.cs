namespace School.Core.Features.Department.Queries.Models
{
    public class GetDepartmentByIdAsyncQuery : IRequest<Response<DepartmentDto>>
    {
        public int Id { get; set; }

        public GetDepartmentByIdAsyncQuery(int id)
        {
            Id = id;
        }
    }
}
