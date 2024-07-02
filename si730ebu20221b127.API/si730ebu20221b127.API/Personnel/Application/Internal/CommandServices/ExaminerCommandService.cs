using si730ebu20221b127.API.Personnel.Domain.Model.Aggregates;
using si730ebu20221b127.API.Personnel.Domain.Model.Commands;
using si730ebu20221b127.API.Personnel.Domain.Repositories;
using si730ebu20221b127.API.Personnel.Domain.Services;
using si730ebu20221b127.API.Shared.Domain.Repositories;

namespace si730ebu20221b127.API.Personnel.Application.Internal.CommandServices;

public class ExaminerCommandService(IExaminerRepository examinerRepository, IUnitOfWork unitOfWork)
    : IExaminerCommandService
{
    public async Task<Examiner?> Handle(CreateExaminerCommand command)
    {
        // check if the examiner already exists by its npi
        var existingExaminer = await examinerRepository.FindByNationalProviderIdentifierAsync(command.NationalProviderIdentifier);
        if (existingExaminer != null)
        {
            Console.WriteLine($"Examiner with NPI {command.NationalProviderIdentifier} already exists.");
            return null;
        }
        
        var examiner = new Examiner(command);
        try
        {
            await examinerRepository.AddAsync(examiner);
            await unitOfWork.CompleteAsync();
            return examiner;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }
}