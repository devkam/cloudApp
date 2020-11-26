using System.Collections.Generic;
using System.Threading.Tasks;
using cloudApp.Models;

namespace cloudApp.Services.Api.Interfaces
{
    public interface IImageService
    {
        Task<string> UploadImageAsync(Image image);
        Task<Image> GetImageById(string id);
        Task<IEnumerable<Image>> GetImages();
    }
}
