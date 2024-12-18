using School.Core.Features.Subjects.Queries.Models;

namespace School.Core.Features.Subjects.Queries.Handlers
{
    internal class SubjectsHandler : ResponseHandler, IRequestHandler<GetAllSubjects, Response<IEnumerable<Subject>>>
    {
        private readonly ISubjectService _subjectService;

        public SubjectsHandler(ISubjectService subjectService, IStringLocalizer<SharedResource> localizer)
            : base(localizer)
        {
            _subjectService = subjectService;
        }

        public async Task<Response<IEnumerable<Subject>>> Handle(GetAllSubjects request, CancellationToken cancellationToken)
        {
            var subjects = await _subjectService.GetSubjectsListAsync();
            return Success(subjects);
        }
    }
}