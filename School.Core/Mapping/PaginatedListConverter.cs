using School.Core.Dto.Student;

namespace School.Core.Mapping
{
    public class PaginatedListConverter<TSource, TDestination> : ITypeConverter<PaginatedList<TSource>, PaginatedListDTO<TDestination>>
    {
        public PaginatedListDTO<TDestination> Convert(PaginatedList<TSource> source, PaginatedListDTO<TDestination> destination, ResolutionContext context)
        {
            // Map each item directly from PaginatedList<TSource> (which is already a List<TSource>)
            var items = context.Mapper.Map<List<TDestination>>(source);

            // Create and return the PaginatedListDTO, including HasPreviousPage and HasNextPage
            return new PaginatedListDTO<TDestination>(items, source.TotalCount, source.PageNumber, source.PageSize)
            {
                HasPreviousPage = source.HasPreviousPage,
                HasNextPage = source.HasNextPage
            };
        }
    }

}
