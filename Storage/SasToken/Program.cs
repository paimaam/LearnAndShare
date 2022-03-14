using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using System;

namespace SasToken
{
    class Program
    {
        private static string _container_name = "demo";
        private static string _connection_string = "";
        private static string _blob_name = "abc1.json";
        private static string _location = @"";

        static void Main(string[] args)
        {

            ReadBlob();

            Console.ReadKey();
        }

        public static void ReadBlob()
        {
            Uri _blob_uri = GenerateSAS();

            BlobClient _client = new BlobClient(_blob_uri);

            _client.DownloadTo(_location);
        }
        public static Uri GenerateSAS()
        {
            BlobServiceClient _service_client = new BlobServiceClient(_connection_string);

            BlobContainerClient _container_client = _service_client.GetBlobContainerClient(_container_name);

            BlobClient _blob_client = _container_client.GetBlobClient(_blob_name);

            BlobSasBuilder _builder = new BlobSasBuilder()
            {
                BlobContainerName = _container_name,
                BlobName = _blob_name
            };

            _builder.SetPermissions(BlobSasPermissions.Read | BlobSasPermissions.List);
           
            _builder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);

            return _blob_client.GenerateSasUri(_builder);


        }


    }
}
