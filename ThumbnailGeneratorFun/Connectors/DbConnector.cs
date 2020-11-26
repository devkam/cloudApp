using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ThumbnailGeneratorFun.Models;

namespace ThumbnailGeneratorFun.Connectors
{
    public class DbConnector
    {
        private readonly string _connectionString;

        public DbConnector()
        {
            _connectionString = Environment.GetEnvironmentVariable("SqlDbConnection");
        }

        public async Task<ImageModel> GetImageMetaData(string guid)
        {
            var query = "SELECT * FROM Images WHERE Id=@guid;";
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var image = new ImageModel();
            var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@guid", guid);

            await using var reader = cmd.ExecuteReader();
            if (await reader.ReadAsync())
            {
                image.FromSqlReader(reader);
            }

            await connection.CloseAsync();
            return image;
        }

        public async Task UpdateMiniatureThumbnail(string guid, string miniatureLink)
        {
            var query = "UPDATE Images SET MiniatureLink=@link WHERE Id=@guid;";
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            await using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@link", miniatureLink);
            cmd.Parameters.AddWithValue("@guid", guid);
            await cmd.ExecuteNonQueryAsync();
            await connection.CloseAsync();
        }
    }
}
