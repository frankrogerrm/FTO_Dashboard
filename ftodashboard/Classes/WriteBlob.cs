using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Components.Forms;
using System.Text;

namespace ftodashboard.Classes
{
    public class WriteBlob
    {
        public void Upload(Dictionary<IBrowserFile, string> files,
            string connectionString,
            string container)
        {
            var containerClient = new BlobContainerClient(connectionString, container);

            try
            {
                foreach (var (file, content) in files)
                {
                    var blobClient = containerClient.GetBlobClient(file.Name);
                    byte[] byteArray = Encoding.UTF8.GetBytes(content);
                    MemoryStream stream = new(byteArray);
                    blobClient.Upload(stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading blob: {ex.Message}");
                throw;
            }
        }
    }
}