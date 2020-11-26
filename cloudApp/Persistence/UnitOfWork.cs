using System.Threading.Tasks;
using cloudApp.Models;
using cloudApp.Persistence.Interfaces;

namespace cloudApp.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IImageRepository ImageRepository { get; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            ImageRepository = new ImageRepository(_context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task RollbackAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
