using si730ebu20221b127.API.Personnel.Domain.Model.Aggregates;
using si730ebu20221b127.API.Personnel.Interfaces.REST.Resources;

namespace si730ebu20221b127.API.Personnel.Interfaces.REST.Transform;

public static class ExaminerResourceFromEntityAssembler
{
    public static ExaminerResource ToResourceFromEntity(Examiner entity)
    {
        return new ExaminerResource(
            entity.Id,
            entity.FirstName.firstName,
            entity.LastName.lastName,
            entity.NationalProviderIdentifier.nationalProviderIdentifier
            );
    }
}