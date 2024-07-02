namespace si730ebu20221b127.API.Personnel.Interfaces.REST.Resources;

public record CreateExaminerResource(
    string FirstName,
    string LastName,
    string NationalProviderIdentifier
    );