using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

public class GCSService
{
    private readonly string _bucketName;
    private readonly StorageClient _storageClient;

    // Constructor that initializes the service with credentials and bucket name
    public GCSService(string credentialsPath, string bucketName)
    {
        _bucketName = bucketName;

        // Set up the storage client with your credentials file
        var storageClientBuilder = new StorageClientBuilder
        {
            CredentialsPath = credentialsPath  // Path to your service account key file
        };

        _storageClient = storageClientBuilder.Build();
    }

    // Method to upload a file to Google Cloud Storage
    public async Task<string> UploadFileAsync(IFormFile file)
    {
        // Generate a unique file name for the uploaded file
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

        using (var stream = file.OpenReadStream())
        {
            // Upload the file to the specified bucket
            var storageObject = await _storageClient.UploadObjectAsync(
                _bucketName,      // The name of the bucket
                fileName,         // The file name in the bucket
                file.ContentType, // Content type (MIME type) of the file
                stream            // File stream to upload
            );

            // Return the public URL of the uploaded file (you can use this to display it)
            return storageObject.MediaLink;
        }
    }
}
