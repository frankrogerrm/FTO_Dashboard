using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Configuration;

namespace ftodashboard.Classes
{
    public class WriteBlob
    {
        public void Upload(Dictionary<IBrowserFile, string> files,
            string connectionString,
            string container)
        {
            var containerClient = new BlobContainerClient(connectionString, container);
            string exceptionMessage;
            try
            {
                foreach (var (file, content) in files)
                {
                    var blobClient = containerClient.GetBlobClient(file.Name);
                    byte[] byteArray = Encoding.UTF8.GetBytes(content);
                    MemoryStream stream = new (byteArray);
                    blobClient.Upload(stream);

                }
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
        }
       
    }
}
