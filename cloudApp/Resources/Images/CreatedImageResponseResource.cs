using System.ComponentModel.DataAnnotations;

namespace cloudApp.Resources.Images
{
    public class CreatedImageResponseResource
    {
        [Required]
        public string Guid { get; set; }
    }
}
