using System.Collections.Generic;
using System.Threading.Tasks;
using cloudApp.Models;
using cloudApp.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cloudApp.Persistence
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        public ImageRepository(DataContext context) : base(context) { }

        public async Task AddAsync(Image image)
        {
            await _context.Images.AddAsync(image);
        }

        public async Task<Image> GetById(string guid)
        {
            return await _context.Images
                .FirstOrDefaultAsync(x => x.Id.ToString().Equals(guid));
        }

        public async Task<IEnumerable<Image>> GetAllImages()
        {
            return await _context.Images.ToListAsync();
        }
    }
}
