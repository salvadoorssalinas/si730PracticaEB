using si730ebu20221b127.API.Assessment.Domain.Model.Aggregates;
using si730ebu20221b127.API.Assessment.Domain.Model.Queries;
using si730ebu20221b127.API.Assessment.Domain.Repositories;
using si730ebu20221b127.API.Assessment.Domain.Services;

namespace si730ebu20221b127.API.Assessment.Application.Internal.QueryServices;

public class MentalStateExamQueryService(IMentalStateExamRepository mentalStateExamRepository)
    : IMentalStateExamQueryService
{
    public async Task<IEnumerable<MentalStateExam>> Handle(GetAllMentalStateExamsQuery query)
    {
        return await mentalStateExamRepository.ListAsync();
    }
    
    public async Task<MentalStateExam?> Handle(GetMentalStateExamByIdQuery query)
    {
        return await mentalStateExamRepository.FindByIdAsync(query.Id);
    }
    
}