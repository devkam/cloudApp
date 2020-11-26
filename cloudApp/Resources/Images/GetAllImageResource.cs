using System;
using System.ComponentModel.DataAnnotations;

namespace cloudApp.Resources.Images
{
    public class GetAllImageResource
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public string ImageLink { get; set; }

        [Required]
        public string MiniatureLink { get; set; }
    }
}
