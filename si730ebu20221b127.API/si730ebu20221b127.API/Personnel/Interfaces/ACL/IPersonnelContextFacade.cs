using si730ebu20221b127.API.Personnel.Domain.Model.Aggregates;

namespace si730ebu20221b127.API.Personnel.Interfaces.ACL;

public interface IPersonnelContextFacade
{
    Task<Examiner?> FetchExaminerByNationalProviderIdentifier(string nationalProviderIdentifier);
}