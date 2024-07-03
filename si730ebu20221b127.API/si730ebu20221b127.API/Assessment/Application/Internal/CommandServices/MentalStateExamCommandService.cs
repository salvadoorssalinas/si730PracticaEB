using si730ebu20221b127.API.Assessment.Application.Internal.OutboundServices.ACL;
using si730ebu20221b127.API.Assessment.Domain.Model.Aggregates;
using si730ebu20221b127.API.Assessment.Domain.Model.Commands;
using si730ebu20221b127.API.Assessment.Domain.Model.ValueObjects;
using si730ebu20221b127.API.Assessment.Domain.Repositories;
using si730ebu20221b127.API.Assessment.Domain.Services;
using si730ebu20221b127.API.Personnel.Domain.Model.ValueObjects;
using si730ebu20221b127.API.Shared.Domain.Repositories;

namespace si730ebu20221b127.API.Assessment.Application.Internal.CommandServices;

public class MentalStateExamCommandService(IMentalStateExamRepository mentalStateExamRepository, IUnitOfWork unitOfWork, ExternalPersonnelService externalPersonnelService)
    : IMentalStateExamCommandService
{
    public async Task<MentalStateExam?> Handle(CreateMentalStateExamCommand command)
    {
        // find Examiner
        var examiner = await externalPersonnelService.FetchExaminerByNationalProviderIdentifier(command.ExaminerNationalProviderIdentifier);
        if (examiner is null)
        {
            throw new Exception("Examiner not found");
        }
        // check if date is in the future
        if (command.ExamDate > DateTime.Now)
        {
            throw new Exception("Exam date cannot be in the future.");
        }
        // check score values
        if (command.OrientationScore < 0 || command.OrientationScore > 10)
        {
            throw new Exception("Orientation score must be between 0 and 10.");
        }
        if (command.RegistrationScore < 0 || command.RegistrationScore > 3)
        {
            throw new Exception("Registration score must be between 0 and 3.");
        }
        if (command.AttentionAndCalculationScore < 0 || command.AttentionAndCalculationScore > 5)
        {
            throw new Exception("Attention and calculation score must be between 0 and 5.");
        }
        if (command.RecallScore < 0 || command.RecallScore > 3)
        {
            throw new Exception("Recall score must be between 0 and 3.");
        }
        if (command.LanguageScore < 0 || command.LanguageScore > 9)
        {
            throw new Exception("Language score must be between 0 and 9.");
        }
        var mentalStateExam = new MentalStateExam(command, examiner);
        try
        {
            await mentalStateExamRepository.AddAsync(mentalStateExam);
            await unitOfWork.CompleteAsync();
            return mentalStateExam;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while adding a mental state exam: {e.Message}");
        }
    }
}