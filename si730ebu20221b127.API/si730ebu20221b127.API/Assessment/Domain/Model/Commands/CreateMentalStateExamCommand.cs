
namespace si730ebu20221b127.API.Assessment.Domain.Model.Commands;

public record CreateMentalStateExamCommand(
    int PatientId,
    DateTime ExamDate,
    int OrientationScore,
    int RegistrationScore,
    int AttentionAndCalculationScore,
    int RecallScore,
    int LanguageScore,
    string ExaminerNationalProviderIdentifier
    );