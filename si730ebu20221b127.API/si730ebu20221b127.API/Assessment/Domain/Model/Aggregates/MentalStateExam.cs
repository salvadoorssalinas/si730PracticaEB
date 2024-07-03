using si730ebu20221b127.API.Assessment.Domain.Model.Commands;
using si730ebu20221b127.API.Assessment.Domain.Model.ValueObjects;
using si730ebu20221b127.API.Personnel.Domain.Model.Aggregates;
using si730ebu20221b127.API.Personnel.Domain.Model.ValueObjects;

namespace si730ebu20221b127.API.Assessment.Domain.Model.Aggregates;

public partial class MentalStateExam
{
    public MentalStateExam()
    {
        
    }
    
    public MentalStateExam(int patientId, ExamDate examDate, int orientationScore, int registrationScore, int attentionAndCalculationScore, int recallScore, int languageScore, NationalProviderIdentifier examinerNationalProviderIdentifier, Examiner examiner)
    {
        PatientId = patientId;
        ExamDate = examDate;
        OrientationScore = orientationScore;
        RegistrationScore = registrationScore;
        AttentionAndCalculationScore = attentionAndCalculationScore;
        RecallScore = recallScore;
        LanguageScore = languageScore;
        ExaminerNationalProviderIdentifier = examinerNationalProviderIdentifier;
        Examiner = examiner;
        ExaminerId = examiner.Id;
    }

    public MentalStateExam(CreateMentalStateExamCommand command, Examiner examiner)
    {
        PatientId = command.PatientId;
        ExamDate = new ExamDate(command.ExamDate);
        OrientationScore = command.OrientationScore;
        RegistrationScore = command.RegistrationScore;
        AttentionAndCalculationScore = command.AttentionAndCalculationScore;
        RecallScore = command.RecallScore;
        LanguageScore = command.LanguageScore;
        ExaminerNationalProviderIdentifier = new NationalProviderIdentifier(command.ExaminerNationalProviderIdentifier);
        Examiner = examiner;
        ExaminerId = examiner.Id;
    }
    
    public int Id { get; set; }
    public int PatientId { get; set; }
    public ExamDate ExamDate { get; set; }
    public int OrientationScore { get; set; }
    public int RegistrationScore { get; set; }
    public int AttentionAndCalculationScore { get; set; }
    public int RecallScore { get; set; }
    public int LanguageScore { get; set; }
    public NationalProviderIdentifier ExaminerNationalProviderIdentifier { get; set; }
    public Examiner Examiner { get; set; }
    public int ExaminerId { get; set; }
}