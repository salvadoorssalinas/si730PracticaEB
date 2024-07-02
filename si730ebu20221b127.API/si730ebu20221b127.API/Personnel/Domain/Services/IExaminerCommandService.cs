using si730ebu20221b127.API.Personnel.Domain.Model.Aggregates;
using si730ebu20221b127.API.Personnel.Domain.Model.Commands;

namespace si730ebu20221b127.API.Personnel.Domain.Services;

public interface IExaminerCommandService
{
    Task<Examiner?> Handle(CreateExaminerCommand command);
}