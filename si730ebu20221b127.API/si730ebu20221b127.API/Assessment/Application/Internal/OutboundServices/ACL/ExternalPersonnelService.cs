using si730ebu20221b127.API.Personnel.Domain.Model.Aggregates;
using si730ebu20221b127.API.Personnel.Interfaces.ACL;

namespace si730ebu20221b127.API.Assessment.Application.Internal.OutboundServices.ACL;

public class ExternalPersonnelService(IPersonnelContextFacade personnelContextFacade)
{
    public async Task<Examiner?> FetchExaminerByNationalProviderIdentifier(string nationalProviderIdentifier)
    {
        var examiner = await personnelContextFacade.FetchExaminerByNationalProviderIdentifier(nationalProviderIdentifier);
        return examiner;
    }
}