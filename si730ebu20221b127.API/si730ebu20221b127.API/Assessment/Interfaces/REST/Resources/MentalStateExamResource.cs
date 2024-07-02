namespace si730ebu20221b127.API.Assessment.Interfaces.REST.Resources;

public record MentalStateExamResource(
    int Id,
    int PatientId,
    DateTime ExamDate,
    int OrientationScore,
    int RegistrationScore,
    int AttentionAndCalculationScore,
    int RecallScore,
    int LanguageScore,
    string ExaminerNationalProviderIdentifier
    );