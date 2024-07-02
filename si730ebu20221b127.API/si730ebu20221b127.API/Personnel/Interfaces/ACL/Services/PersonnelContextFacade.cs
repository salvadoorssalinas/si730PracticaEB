using si730ebu20221b127.API.Personnel.Domain.Model.Queries;
using si730ebu20221b127.API.Personnel.Domain.Services;

namespace si730ebu20221b127.API.Personnel.Interfaces.ACL.Services;

public class PersonnelContextFacade(IExaminerQueryService examinerQueryService) : IPersonnelContextFacade
{
    public async Task<int> FetchExaminerIdByNationalProviderIdentifier(string nationalProviderIdentifier)
    {
        var getExaminerByNationalProviderIdentifierQuery =
            new GetExaminerByNationalProviderIdentifierQuery(nationalProviderIdentifier);
        var examiner = await examinerQueryService.Handle(getExaminerByNationalProviderIdentifierQuery);
        return examiner?.Id ?? 0;
    }
    
}