using si730ebu20221b127.API.Assessment.Domain.Model.Commands;
using si730ebu20221b127.API.Assessment.Interfaces.REST.Resources;

namespace si730ebu20221b127.API.Assessment.Interfaces.REST.Transform;

public static class CreateMentalStateExamCommandFromResourceAssembler
{
    public static CreateMentalStateExamCommand ToCommandFromResource(CreateMentalStateExamResource resource)
    {
        return new CreateMentalStateExamCommand(
            resource.PatientId,
            resource.ExamDate,
            resource.OrientationScore,
            resource.RegistrationScore,
            resource.AttentionAndCalculationScore,
            resource.RecallScore,
            resource.LanguageScore,
            resource.ExaminerNationalProviderIdentifier
            );
    }
}