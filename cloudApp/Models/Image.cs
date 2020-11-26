using System;

namespace cloudApp.Models
{
    public class Image
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public DateTime Created { get; set;}

        public string ImageContent { get; set; }

        public string ImageLink { get; set; }

        public string MiniatureLink { get; set; }
    }
}
