using si730ebu20221b127.API.Assessment.Domain.Model.Aggregates;
using si730ebu20221b127.API.Assessment.Interfaces.REST.Resources;

namespace si730ebu20221b127.API.Assessment.Interfaces.REST.Transform;

public static class MentalStateExamResourceFromEntityAssembler
{
    public static MentalStateExamResource ToResourceFromEntity(MentalStateExam entity)
    {
        return new MentalStateExamResource(
            entity.Id,
            entity.PatientId,
            entity.ExamDate.examDate,
            entity.OrientationScore,
            entity.RegistrationScore,
            entity.AttentionAndCalculationScore,
            entity.RecallScore,
            entity.LanguageScore,
            entity.ExaminerNationalProviderIdentifier.nationalProviderIdentifier
            );
    }
    
}