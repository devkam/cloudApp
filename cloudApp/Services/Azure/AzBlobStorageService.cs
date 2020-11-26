using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using cloudApp.Services.Azure.Interfaces;

namespace cloudApp.Services.Azure
{
    public class AzBlobStorageService : IAzBlobStorageService
    {
        private readonly StorageSharedKeyCredential _credentials;
        private readonly string _baseUrl;

        public AzBlobStorageService(IAzKeyVaultService azKeyVaultService)
        {
            var storageName = azKeyVaultService.GetSecret("AzStorageName");
            var storageKey = azKeyVaultService.GetSecret("AzStorageKey");
            _credentials = new StorageSharedKeyCredential(storageName, storageKey);
            _baseUrl = $"https://{storageName}.blob.core.windows.net";
        }

        public async Task<string> UploadImageFromBase64(string container, string filename, string base64Content, string fileExtension = ".jpg")
        {
            var blobName = $"{filename}{fileExtension}";
            await CreateContainer(container);

            var bytes = Convert.FromBase64String(@base64Content);
            await using var stream = new MemoryStream(bytes);
            await UploadBlob(container, blobName, stream);

            return $"{_baseUrl}/{container}/{blobName}";
        }

        private async Task CreateContainer(string container)
        {
            try
            {
                var containerUri = new Uri($"{_baseUrl}/{container}");
                var blobContainerClient = new BlobContainerClient(containerUri, _credentials);
                await blobContainerClient.CreateIfNotExistsAsync(PublicAccessType.BlobContainer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task UploadBlob(string container, string blobName, Stream stream)
        {
            try
            {
                var blobUri = new Uri($"{_baseUrl}/{container}/{blobName}");
                var blobClient = new BlobClient(blobUri, _credentials);
                await blobClient.UploadAsync(stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
