using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using cloudApp.Models;
using cloudApp.Persistence.Interfaces;
using cloudApp.Services.Api.Interfaces;
using cloudApp.Services.Azure.Interfaces;

namespace cloudApp.Services.Api
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAzBlobStorageService _azBlobStorageService;
        private readonly IAzQueueStorageService _azQueueStorageService;

        private const string IMAGES_CONTAINER_NAME = "images";
        private const string QUEUE_NAME = "images";

        public ImageService(IUnitOfWork unitOfWork, IAzBlobStorageService azBlobStorageService, IAzQueueStorageService azQueueStorageService)
        {
            _unitOfWork = unitOfWork;
            _azBlobStorageService = azBlobStorageService;
            _azQueueStorageService = azQueueStorageService;
        }

        public async Task<string> UploadImageAsync(Image image, string content)
        {
            image.Id = Guid.NewGuid();
            image.Created = DateTime.Now;

            try
            {
                var guid = image.Id.ToString();
                var imageLink = await _azBlobStorageService.UploadImageFromBase64(IMAGES_CONTAINER_NAME, guid, content);

                image.ImageLink = imageLink;

                await _azQueueStorageService.SendMessage(QUEUE_NAME, guid);
                await _unitOfWork.ImageRepository.AddAsync(image);
                await _unitOfWork.CompleteAsync();
                return guid;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<Image> GetImageById(string guid)
        {
            return await _unitOfWork.ImageRepository.GetById(guid);
        }

        public async Task<IEnumerable<Image>> GetImages()
        {
            return await _unitOfWork.ImageRepository.GetAllImages();
        }
    }
}
