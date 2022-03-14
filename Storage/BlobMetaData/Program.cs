using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;

namespace BlobMetaData
{
    class Program
    {
        private static string blob_connection_string = "";
        private static string container_name = "az204";

        private static string local_blob = @"";
        private static string blob_name = "abc1.json";

        static void Main(string[] args)
        {
            GetMetadata();
            // SetMetadata();
        }

        public static void GetMetadata()
        {
            BlobServiceClient _service_client = new BlobServiceClient(blob_connection_string);

            BlobContainerClient _container_client = _service_client.GetBlobContainerClient(container_name);

            BlobClient _blob_client = _container_client.GetBlobClient(blob_name);

            BlobProperties _properties = _blob_client.GetProperties();

            IDictionary<string, string> _metadata = _properties.Metadata;

            foreach (var item in _metadata)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }

            Console.ReadKey();
        }

        public static void SetMetadata()
        {
            BlobServiceClient _service_client = new BlobServiceClient(blob_connection_string);

            BlobContainerClient _container_client = _service_client.GetBlobContainerClient(container_name);

            BlobClient _blob_client = _container_client.GetBlobClient(blob_name);

            BlobProperties _properties = _blob_client.GetProperties();

            IDictionary<string, string> _metadata = _properties.Metadata;

            _metadata.Add("Tier", "1");

            _blob_client.SetMetadata(_metadata);

            Console.WriteLine("Metadata appended");
        }
    }
}
