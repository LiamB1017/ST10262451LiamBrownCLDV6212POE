using Azure.Storage.Blobs;

public class AzureBlobService
{
    private readonly BlobContainerClient _containerClient;

    public AzureBlobService(string storageConnectionString, string containerName)
    {
        var blobServiceClient = new BlobServiceClient(storageConnectionString);
        _containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        _containerClient.CreateIfNotExists();
    }

    public async Task<string> UploadImageAsync(string blobName, Stream imageStream)
    {
        var blobClient = _containerClient.GetBlobClient(blobName);
        await blobClient.UploadAsync(imageStream, true);
        return blobClient.Uri.ToString();
    }

    public async Task<Stream> DownloadImageAsync(string blobName)
    {
        var blobClient = _containerClient.GetBlobClient(blobName);
        var response = await blobClient.DownloadAsync();
        return response.Value.Content;
    }

    // Additional methods for handling multimedia content...
}
