using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;

namespace ManageIdentityBlob
{
    class Program
    {

        private static string blob_url = "";
        private static string download_path = @"C:\tem\digtial-post.txt";
        static void Main(string[] args)
        {

            TokenCredential __credential = new DefaultAzureCredential();
            Uri blob_uri = new Uri(blob_url);

            BlobClient _client = new BlobClient(blob_uri, __credential);

            BlobDownloadInfo _download = _client.Download();

            using (FileStream _downloadFileStream = File.OpenWrite(download_path))
            {
                _download.Content.CopyTo(_downloadFileStream);
                _downloadFileStream.Close();
            }
            Console.WriteLine("File download complete");
            Console.ReadKey();

        }
    }
}
