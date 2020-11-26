using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace ThumbnailGeneratorFun.Connectors
{
    public class AzBlobStorageConnector
    {
        private const string CONTAINER = "miniatures";
        private readonly StorageSharedKeyCredential _credentials;
        private readonly string _baseUrl;

        public AzBlobStorageConnector()
        {
            var storageName = Environment.GetEnvironmentVariable("AzStorageName");
            var storageKey = Environment.GetEnvironmentVariable("AzStorageKey");
            _credentials = new StorageSharedKeyCredential(storageName, storageKey);
            _baseUrl = $"https://{storageName}.blob.core.windows.net";
        }

        public async Task<Image> GetImageFromBlobStorage(string url)
        {
            var blobClient = new BlobClient(new Uri(url));
            await using var stream = new MemoryStream();
            await blobClient.DownloadToAsync(stream);
            return Image.FromStream(stream);
        }

        public async Task<string> UploadThumbnailImage(string guid, Image image)
        {
            await CreateContainer();
            await UploadBlob(guid, image);
            return $"{_baseUrl}/{CONTAINER}/{guid}.png";
        }

        private async Task CreateContainer()
        {
            try
            {
                var containerUri = new Uri($"{_baseUrl}/{CONTAINER}");
                var blobContainerClient = new BlobContainerClient(containerUri, _credentials);
                await blobContainerClient.CreateIfNotExistsAsync(PublicAccessType.BlobContainer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task UploadBlob(string blobName, Image image)
        {
            try
            {
                var blobUri = new Uri($"{_baseUrl}/{CONTAINER}/{blobName}.png");
                var blobClient = new BlobClient(blobUri, _credentials);
                await using var stream = new MemoryStream();
                image.Save(stream, ImageFormat.Png);
                stream.Position = 0;
                await blobClient.UploadAsync(stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
