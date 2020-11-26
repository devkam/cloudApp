using System.Threading.Tasks;
using cloudApp.Models;
using cloudApp.Persistence.Interfaces;

namespace cloudApp.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IImageRepository _imageRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IImageRepository ImageRepository
        {
            get { return _imageRepository = _imageRepository ?? new ImageRepository(_context); }
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
