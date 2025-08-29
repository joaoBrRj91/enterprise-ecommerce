namespace NSE.Shared.Data;

public interface IUnitOfWork
{
    Task<bool> Commit();
}
