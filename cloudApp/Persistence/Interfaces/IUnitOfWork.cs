using System.Threading.Tasks;

namespace cloudApp.Persistence.Interfaces
{
    public interface IUnitOfWork
    {
        IImageRepository ImageRepository { get; }
        Task CompleteAsync();
        Task RollbackAsync();
    }
}
