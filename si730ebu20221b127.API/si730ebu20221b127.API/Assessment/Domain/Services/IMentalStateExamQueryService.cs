using si730ebu20221b127.API.Assessment.Domain.Model.Aggregates;
using si730ebu20221b127.API.Assessment.Domain.Model.Queries;

namespace si730ebu20221b127.API.Assessment.Domain.Services;

public interface IMentalStateExamQueryService
{
    Task<IEnumerable<MentalStateExam>> Handle(GetAllMentalStateExamsQuery query);
    Task<MentalStateExam?> Handle(GetMentalStateExamByIdQuery query);
}