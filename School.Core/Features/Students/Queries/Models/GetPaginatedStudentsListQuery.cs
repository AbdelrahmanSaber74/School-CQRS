namespace School.Core.Features.Students.Queries.Models
{
    public class GetPaginatedStudentsListQuery : IRequest<Response<PaginatedListDTO<StudentDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetPaginatedStudentsListQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}