using NSE.Shared.DomainObjects;

namespace NSE.Shared.Data;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}

