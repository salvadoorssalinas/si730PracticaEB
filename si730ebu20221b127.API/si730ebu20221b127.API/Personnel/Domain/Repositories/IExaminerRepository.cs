using si730ebu20221b127.API.Personnel.Domain.Model.Aggregates;
using si730ebu20221b127.API.Shared.Domain.Repositories;

namespace si730ebu20221b127.API.Personnel.Domain.Repositories;

public interface IExaminerRepository : IBaseRepository<Examiner>
{
    Task<Examiner?> FindByNationalProviderIdentifierAsync(string nationalProviderIdentifier);
}