namespace si730ebu20221b127.API.Personnel.Interfaces.ACL;

public interface IPersonnelContextFacade
{
    Task<int> FetchExaminerIdByNationalProviderIdentifier(string nationalProviderIdentifier);
}