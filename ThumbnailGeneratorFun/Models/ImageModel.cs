using System;
using System.Data.SqlClient;

namespace ThumbnailGeneratorFun.Models
{
    public class ImageModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public string ImageLink { get; set; }

        public ImageModel FromSqlReader(SqlDataReader reader)
        {
            Id = (Guid)reader["Id"];
            Name = reader["Name"].ToString();
            Author = reader["Author"].ToString();
            Description = reader["Description"].ToString();
            Created = (DateTime)reader["Created"];
            ImageLink = reader["ImageLink"].ToString();

            return this;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nAuthor: {Author}\nDescription: {Description}\nCreated: {Created}\nImageLink: {ImageLink}";
        }
    }
}
