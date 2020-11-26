using System.Threading.Tasks;

namespace cloudApp.Services.Azure.Interfaces
{
    public interface IAzBlobStorageService
    {
        Task<string> UploadImageFromBase64(string container, string filename, string content, string fileExtension = ".jpg");
    }
}
