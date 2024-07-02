namespace si730ebu20221b127.API.Personnel.Domain.Model.Commands;

public record CreateExaminerCommand(
    string FirstName,
    string LastName,
    string NationalProviderIdentifier
    );