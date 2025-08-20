using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Project.common;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text;

namespace Project.core.Services.ContentStorage
{
    public class ContentBlobStorage : IContentStorage
    {
        private const string BlobContainerName = "content";
        private const string QueueName = "vestas";
        private readonly IOptions<StorageConnectionString> _option;
        private readonly ILogger<ContentBlobStorage> _logger;

        public ContentBlobStorage(IOptions<StorageConnectionString> option, ILogger<ContentBlobStorage> logger)
        {
            _option = option;
            _logger = logger;
        }

        // Method to add an image as a blob by its ID (identifier)
        public async Task AddImageByIdAsync(byte[] imageData, Guid identifier)
        {
            try
            {
                BlobServiceClient blobServiceClient = new BlobServiceClient(_option.Value.ConnectionString);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(BlobContainerName);

                await containerClient.CreateIfNotExistsAsync();

                BlobClient blobClient = containerClient.GetBlobClient(identifier.ToString());

                using (MemoryStream stream = new MemoryStream(imageData))
                {
                    await blobClient.UploadAsync(stream, overwrite: true);
                }

                _logger.LogInformation($"Image uploaded to {blobClient.Uri}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while uploading the image: {ex.Message}");
                throw;
            }
        }

        public async Task AddMessageToQueuessync(string content)
        {
            try
            {
                QueueClient queueClient = new QueueClient(_option.Value.ConnectionString, QueueName);

                await queueClient.CreateIfNotExistsAsync();

                await queueClient.SendMessageAsync(content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task AddStringByIdAsync(string content, Guid identifier)
        {
            try
            {
                BlobServiceClient blobServiceClient = new BlobServiceClient(_option.Value.ConnectionString);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(BlobContainerName);

                await containerClient.CreateIfNotExistsAsync();

                BlobClient blobClient = containerClient.GetBlobClient(identifier.ToString());

                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
                {
                    await blobClient.UploadAsync(stream, overwrite: true);
                }

                _logger.LogInformation($"File uploaded to {blobClient.Uri}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while uploading the string content: {ex.Message}");
                throw;
            }
        }

        public async Task<string> GetFileByIdAsync(Guid identifier)
        {
            try
            {
                BlobServiceClient blobServiceClient = new BlobServiceClient(_option.Value.ConnectionString);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(BlobContainerName);

                BlobClient blobClient = containerClient.GetBlobClient(identifier.ToString());

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await blobClient.DownloadToAsync(memoryStream);

                    memoryStream.Position = 0; // Reset position to the start

                    using (StreamReader reader = new StreamReader(memoryStream, Encoding.UTF8))
                    {
                        return await reader.ReadToEndAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving the file: {ex.Message}");
                throw;
            }
        }

        public async Task<byte[]> GetImageByIdAsync(Guid identifier)
        {
            try
            {
                BlobServiceClient blobServiceClient = new BlobServiceClient(_option.Value.ConnectionString);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(BlobContainerName);

                BlobClient blobClient = containerClient.GetBlobClient(identifier.ToString());

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await blobClient.DownloadToAsync(memoryStream);

                    memoryStream.Position = 0;

                    return memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving the image: {ex.Message}");
                throw;
            }
        }
    }
}
