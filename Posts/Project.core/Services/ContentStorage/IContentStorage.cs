namespace Project.core.Services.ContentStorage
{
    public interface IContentStorage
    {
        Task AddImageByIdAsync(byte[] imageData, Guid identifier);
        public Task AddStringByIdAsync(string content, Guid identifier);
        public Task<string> GetFileByIdAsync(Guid identifier);
        public Task<byte[]> GetImageByIdAsync(Guid identifier);
        public Task AddMessageToQueuessync(string content);
    }
}


