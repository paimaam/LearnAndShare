using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;

namespace BlobProperties1
{
    class Program
    {
        private static string blob_connection_string = "";
        private static string container_name = "az204";

        private static string local_blob = @"";
        private static string blob_name = "abc1.json";

        static void Main(string[] args)
        {
            BlobServiceClient _service_client = new BlobServiceClient(blob_connection_string);

            BlobContainerClient _container_client = _service_client.GetBlobContainerClient(container_name);

            BlobClient _blob_client = _container_client.GetBlobClient(blob_name);

            BlobProperties _properties = _blob_client.GetProperties();


            Console.WriteLine($"The access tier of the blob is {_properties.AccessTier}");
            Console.WriteLine($"The size of the blob is {_properties.ContentLength}");
            Console.WriteLine(_properties.BlobType);
            Console.WriteLine(_properties.CreatedOn);
            Console.ReadKey();
        }
    }
}
