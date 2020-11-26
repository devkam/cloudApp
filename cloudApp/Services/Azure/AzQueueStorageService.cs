using System;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Queues;
using cloudApp.Services.Azure.Interfaces;

namespace cloudApp.Services.Azure
{
    public class AzQueueStorageService : IAzQueueStorageService
    {
        private readonly StorageSharedKeyCredential _credentials;
        private readonly string _baseUrl;

        public AzQueueStorageService(IAzKeyVaultService azKeyVaultService)
        {
            var storageName = azKeyVaultService.GetSecret("AzStorageName");
            var storageKey = azKeyVaultService.GetSecret("AzStorageKey");
            _credentials = new StorageSharedKeyCredential(storageName, storageKey);
            _baseUrl = $"https://{storageName}.queue.core.windows.net";
        }

        public async Task SendMessage(string queueName, string message)
        {
            try
            {
                var uri = new Uri($"{_baseUrl}/{queueName}");
                var queueClient = new QueueClient(uri, _credentials);
                var encodedMessage = EncodeMessage(message);

                await queueClient.CreateIfNotExistsAsync();
                await queueClient.SendMessageAsync(encodedMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string EncodeMessage(string message)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(message);
            return System.Convert.ToBase64String(bytes);
        }
    }
}
