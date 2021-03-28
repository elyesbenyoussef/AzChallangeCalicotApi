using AzChallangeCalicotApi.Type;
using AzChallangeCalicotApi.Type.Interfaces;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;

namespace AzChallangeCalicotApi.Service
{
    public class BlobStorageService : IBlobStorageService
    {
        private static BlobContainerClient _containerClient;
        public BlobStorageService(AppSettings appSettings)
        {
            _containerClient = ConnectContainerClient(appSettings.BlobStorageConnectionString, appSettings.BlobStorageContainer);
        }

        private BlobContainerClient ConnectContainerClient(string connectionString, string blobContainerName)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            return blobServiceClient.GetBlobContainerClient(blobContainerName);
        }

        public void UploadFileToBlob(Stream file, string fileName)
        {
            BlobClient blobClient  = _containerClient.GetBlobClient(fileName);
            blobClient.Upload(file, true);
        }

        public async Task<Uri> UploadFileBlobAsync(Stream content, string contentType, string fileName)
        {
            var blobClient = _containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(content, new BlobHttpHeaders { ContentType = contentType });
            return blobClient.Uri;
        }
        public string GetDownloadUrl(string fileName)
        {
            BlobClient blobClient = _containerClient.GetBlobClient(blobName: fileName);
            Uri uri = blobClient.GenerateSasUri(Azure.Storage.Sas.BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddDays(1));
            return uri.ToString();
        }

        public Stream Download(string fileName)
        {
            BlobClient blobClient = _containerClient.GetBlobClient(blobName: fileName);
            BlobDownloadInfo blobDownloadInfo = blobClient.Download();
            return blobDownloadInfo.Content;
        }

        public void CreateThumb(string fileName)
        {
            using (var ms = Download(fileName))
            {
                var image = Image.FromStream(ms);

                // calculate a 150px thumbnail
                int width;
                int height;
                if (image.Width > image.Height)
                {
                    width = 150;
                    height = 150 * image.Height / image.Width;
                }
                else
                {
                    height = 150;
                    width = 150 * image.Width / image.Height;
                }

                // generate the thumb
                var thumb = image.GetThumbnailImage(
                    width,
                    height,
                    () => false,
                    IntPtr.Zero);

                // save it off to blob storage
                using (var thumbStream = new MemoryStream())
                {
                    thumb.Save(
                        thumbStream,
                        System.Drawing.Imaging.ImageFormat.Jpeg);

                    thumbStream.Position = 0; // reset;

                    UploadFileToBlob(thumbStream, Path.Combine("thumb", fileName));
                }
            }
        }
    }
}
