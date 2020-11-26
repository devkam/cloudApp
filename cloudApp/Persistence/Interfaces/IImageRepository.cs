using System.Collections.Generic;
using System.Threading.Tasks;
using cloudApp.Models;

namespace cloudApp.Persistence.Interfaces
{
    public interface IImageRepository
    {
        Task AddAsync(Image image);
        Task<Image> GetById(string guid);
        Task<IEnumerable<Image>> GetAllImages();
    }
}
