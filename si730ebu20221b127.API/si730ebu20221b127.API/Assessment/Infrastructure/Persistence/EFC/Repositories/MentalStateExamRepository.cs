using si730ebu20221b127.API.Assessment.Domain.Repositories;
using si730ebu20221b127.API.Assessment.Domain.Model.Aggregates;
using si730ebu20221b127.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu20221b127.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebu20221b127.API.Assessment.Infrastructure.Persistence.EFC.Repositories;

public class MentalStateExamRepository(AppDbContext context) : BaseRepository<MentalStateExam>(context), IMentalStateExamRepository
{
    
}