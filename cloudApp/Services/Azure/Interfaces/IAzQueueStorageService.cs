using System.Threading.Tasks;

namespace cloudApp.Services.Azure.Interfaces
{
    public interface IAzQueueStorageService
    {
        Task SendMessage(string queueName, string message);
    }
}
