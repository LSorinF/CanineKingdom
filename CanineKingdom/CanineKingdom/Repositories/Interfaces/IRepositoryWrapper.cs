using CanineKingdom.Repositories.Interfaces;

namespace CanineKingdom.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserServiceRepository UserServiceRepository { get; }
        void Save();
    }
}
