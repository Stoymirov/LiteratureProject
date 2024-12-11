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
       
        var credential = Google.Apis.Auth.OAuth2.GoogleCredential.FromFile(config.CredentialsFilePath);
        _storageClient = StorageClient.Create(credential);

        _bucketName = config.BucketName;
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName,string contentType)
    {
        
        var storageObject = await _storageClient.UploadObjectAsync(
            _bucketName,
            fileName,
            contentType,
            fileStream
        );

        return $"https://storage.googleapis.com/{_bucketName}/{storageObject.Name}";
    }
}
