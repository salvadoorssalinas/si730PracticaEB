using si730ebu20221b127.API.Assessment.Domain.Model.Aggregates;
using si730ebu20221b127.API.Personnel.Domain.Model.Commands;
using si730ebu20221b127.API.Personnel.Domain.Model.ValueObjects;

namespace si730ebu20221b127.API.Personnel.Domain.Model.Aggregates;

public partial class Examiner
{
    
    public Examiner()
    {
        
    }
    
    public Examiner(FirstName firstName, LastName lastName, NationalProviderIdentifier nationalProviderIdentifier)
    {
        // check if strings are empty
        if (string.IsNullOrEmpty(firstName.firstName) || string.IsNullOrEmpty(lastName.lastName) || string.IsNullOrEmpty(nationalProviderIdentifier.nationalProviderIdentifier))
        {
            throw new ArgumentNullException("Attributes cannot be empty.");
        }
        FirstName = firstName;
        LastName = lastName;
        NationalProviderIdentifier = nationalProviderIdentifier;
    }

    public Examiner(CreateExaminerCommand command)
    {
        // check if strings are empty
        if (string.IsNullOrEmpty(command.FirstName) || string.IsNullOrEmpty(command.LastName) || string.IsNullOrEmpty(command.NationalProviderIdentifier))
        {
            throw new ArgumentNullException("Attributes cannot be empty.");
        }
        FirstName = new FirstName(command.FirstName);
        LastName = new LastName(command.LastName);
        NationalProviderIdentifier = new NationalProviderIdentifier(command.NationalProviderIdentifier);
    }
    
    
    public int Id { get; set; }
    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }
    public NationalProviderIdentifier NationalProviderIdentifier { get; set; }
    public ICollection<MentalStateExam> MentalStateExams { get; }
}