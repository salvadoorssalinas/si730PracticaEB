using si730ebu20221b127.API.Personnel.Domain.Model.Commands;
using si730ebu20221b127.API.Personnel.Interfaces.REST.Resources;

namespace si730ebu20221b127.API.Personnel.Interfaces.REST.Transform;

public static class CreateExaminerCommandFromResourceAssembler
{
    public static CreateExaminerCommand ToCommandFromResource(CreateExaminerResource resource)
    {
        return new CreateExaminerCommand(
            resource.FirstName,
            resource.LastName,
            resource.NationalProviderIdentifier
            );
    }
    
}