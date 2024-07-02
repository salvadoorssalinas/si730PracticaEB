using si730ebu20221b127.API.Personnel.Domain.Model.Aggregates;
using si730ebu20221b127.API.Personnel.Domain.Model.Queries;
using si730ebu20221b127.API.Personnel.Domain.Repositories;
using si730ebu20221b127.API.Personnel.Domain.Services;

namespace si730ebu20221b127.API.Personnel.Application.Internal.QueryServices;

public class ExaminerQueryService(IExaminerRepository examinerRepository) : IExaminerQueryService
{
    public async Task<IEnumerable<Examiner>> Handle(GetAllExaminersQuery query)
    {
        return await examinerRepository.ListAsync();
    }
    
    public async Task<Examiner?> Handle(GetExaminerByIdQuery query)
    {
        return await examinerRepository.FindByIdAsync(query.Id);
    }
    
    public async Task<Examiner?> Handle(GetExaminerByNationalProviderIdentifierQuery query)
    {
        return await examinerRepository.FindByNationalProviderIdentifierAsync(query.NationalProviderIdentifier);
    }
}