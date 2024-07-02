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
        var examDate = new ExamDate(command.ExamDate);
        var mentalStateExam = new MentalStateExam(
            command.PatientId,
            examDate,
            command.OrientationScore,
            command.RegistrationScore,
            command.AttentionAndCalculationScore,
            command.RecallScore,
            command.LanguageScore,
            new NationalProviderIdentifier(command.ExaminerNationalProviderIdentifier),
            examiner
            );
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