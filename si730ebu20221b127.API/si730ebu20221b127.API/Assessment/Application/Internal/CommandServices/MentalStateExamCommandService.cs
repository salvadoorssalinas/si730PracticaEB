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
            Console.WriteLine("Examiner not found");
            return null;
        }
        // check if date is in the future
        if (command.ExamDate > DateTime.Now)
        {
            Console.WriteLine("Exam date cannot be in the future.");
            return null;
        }
        // check score values
        if (command.OrientationScore < 0 || command.OrientationScore > 10)
        {
            Console.WriteLine("Orientation score must be between 0 and 10.");
            return null;
        }
        if (command.RegistrationScore < 0 || command.RegistrationScore > 3)
        {
            Console.WriteLine("Registration score must be between 0 and 3.");
            return null;
        }
        if (command.AttentionAndCalculationScore < 0 || command.AttentionAndCalculationScore > 5)
        {
            Console.WriteLine("Attention and calculation score must be between 0 and 5.");
            return null;
        }
        if (command.RecallScore < 0 || command.RecallScore > 3)
        {
            Console.WriteLine("Recall score must be between 0 and 3.");
            return null;
        }
        if (command.LanguageScore < 0 || command.LanguageScore > 9)
        {
            Console.WriteLine("Language score must be between 0 and 9.");
            return null;
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
            Console.WriteLine($"An error occurred while adding a mental state exam: {e.Message}");
            return null;
        }
    }
}