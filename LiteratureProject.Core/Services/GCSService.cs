using Google.Cloud.Storage.V1;
using LiteratureProject.Core.Models.ProfileModels;
using System.IO;
using System.Threading.Tasks;

public class GCSService
{
    private readonly StorageClient _storageClient;
    private readonly string _bucketName;

    public GCSService(GoogleCloudConfig config)
    {
        // Set the credentials using the JSON file
        var credential = Google.Apis.Auth.OAuth2.GoogleCredential.FromFile(config.CredentialsFilePath);
        _storageClient = StorageClient.Create(credential);

        _bucketName = config.BucketName;
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName,string contentType)
    {
        // Upload file to Google Cloud Storage
        var storageObject = await _storageClient.UploadObjectAsync(
            _bucketName,
            fileName,
            contentType, // Content type
            fileStream
        );

        return $"https://storage.googleapis.com/{_bucketName}/{storageObject.Name}";
    }
}
