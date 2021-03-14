using System;
using System.IO;
using System.Threading.Tasks;

namespace AzChallangeCalicotApi.Type.Interfaces
{
    public interface IBlobStorageService
    {
        void UploadFileToBlob(Stream file, string fileName);
        Task<Uri> UploadFileBlobAsync(Stream content, string contentType, string fileName);
        string GetDownloadUrl(string fileName);
        Stream Download(string fileName);
    }
}
