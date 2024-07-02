namespace si730ebu20221b127.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}