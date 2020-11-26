using cloudApp.Models;

namespace cloudApp.Persistence
{
    public class BaseRepository
    {
        protected readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }
    }
}
