using Microsoft.EntityFrameworkCore;
using si730ebu20221b127.API.Personnel.Domain.Model.Aggregates;
using si730ebu20221b127.API.Personnel.Domain.Repositories;
using si730ebu20221b127.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu20221b127.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebu20221b127.API.Personnel.Infrastructure.Persistence.EFC.Repositories;

public class ExaminerRepository(AppDbContext context) : BaseRepository<Examiner>(context), IExaminerRepository
{
    public Task<Examiner?> FindByNationalProviderIdentifierAsync(string nationalProviderIdentifier)
    {
        return context.Set<Examiner>().FirstOrDefaultAsync(x => x.NationalProviderIdentifier.nationalProviderIdentifier == nationalProviderIdentifier);
    }
    
}