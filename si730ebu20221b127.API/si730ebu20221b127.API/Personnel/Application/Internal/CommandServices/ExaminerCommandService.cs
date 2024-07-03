using si730ebu20221b127.API.Personnel.Domain.Model.Aggregates;
using si730ebu20221b127.API.Personnel.Domain.Model.Commands;
using si730ebu20221b127.API.Personnel.Domain.Model.ValueObjects;
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
            throw new Exception($"Examiner with NPI {command.NationalProviderIdentifier} already exists.");
        }

        var firstName = new FirstName(command.FirstName);
        var lastName = new LastName(command.LastName);
        var nationalProviderIdentifier = new NationalProviderIdentifier(command.NationalProviderIdentifier);
        
        var examiner = new Examiner(firstName, lastName, nationalProviderIdentifier);
        try
        {
            await examinerRepository.AddAsync(examiner);
            await unitOfWork.CompleteAsync();
            return examiner;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating the profile: {e.Message}");
        }
    }
}