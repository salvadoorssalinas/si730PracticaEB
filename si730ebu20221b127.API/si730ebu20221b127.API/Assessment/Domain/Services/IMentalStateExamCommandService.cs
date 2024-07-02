using si730ebu20221b127.API.Assessment.Domain.Model.Aggregates;
using si730ebu20221b127.API.Assessment.Domain.Model.Commands;

namespace si730ebu20221b127.API.Assessment.Domain.Services;

public interface IMentalStateExamCommandService
{
    Task<MentalStateExam?> Handle(CreateMentalStateExamCommand command);
}