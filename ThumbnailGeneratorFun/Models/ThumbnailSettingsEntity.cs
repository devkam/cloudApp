using Microsoft.WindowsAzure.Storage.Table;

namespace ThumbnailGeneratorFun.Models
{
    public class ThumbnailSettingsEntity : TableEntity
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public ThumbnailSettingsEntity()
        {
            RowKey = "ThumbnailSize";
        }
    }
}
