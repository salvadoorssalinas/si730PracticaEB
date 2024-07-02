using si730ebu20221b127.API.Personnel.Domain.Model.Aggregates;
using si730ebu20221b127.API.Personnel.Domain.Model.Queries;

namespace si730ebu20221b127.API.Personnel.Domain.Services;

public interface IExaminerQueryService
{
    Task<IEnumerable<Examiner>> Handle(GetAllExaminersQuery query);
    Task<Examiner?> Handle(GetExaminerByIdQuery query);
    Task<Examiner?> Handle(GetExaminerByNationalProviderIdentifierQuery query);
}