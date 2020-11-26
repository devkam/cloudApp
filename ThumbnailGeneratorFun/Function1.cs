using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using ThumbnailGeneratorFun.Connectors;

namespace ThumbnailGeneratorFun
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task Run([QueueTrigger("images")] string myQueueItem, ILogger log)
        {
            const int THUMB_SIZE = 100;
            var dbConnector = new DbConnector();
            var azConnector = new AzBlobStorageConnector();

            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            var guid = myQueueItem;
            var imageModel = await dbConnector.GetImageMetaData(guid);
            var image = await azConnector.GetImageFromBlobStorage(imageModel.ImageLink);
            var thumbnail = image.GetThumbnailImage(THUMB_SIZE, THUMB_SIZE, () => false, IntPtr.Zero);
            
            var miniatureUrl = await azConnector.UploadThumbnailImage(guid, thumbnail);
            await dbConnector.UpdateMiniatureThumbnail(guid, miniatureUrl);
        }
    }
}
