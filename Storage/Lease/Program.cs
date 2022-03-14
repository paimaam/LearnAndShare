using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using System;
using System.IO;

namespace Lease
{
    class Program
    {
        private static string blob_connection_string = "DefaultEndpointsProtocol=https;AccountName=practicetime2;AccountKey=6BLAdEJB2JQD4eU/Z4Kf1t4ZGJxHEL14br4RT4VxJtS4Cv7ynPJTzZWlmgGGd5FVqDe81Q8NBXEAWOsLrNvtsg==;EndpointSuffix=core.windows.net";
        private static string container_name = "az204";
        private static string local_blob = "C:\\tmp\\Program.cs";
        private static string blob_name = "intialStructure.json";
        static void Main(string[] args)
        {
            GetLease();
        }

        public static void GetLease()
        {
            BlobServiceClient _client = new BlobServiceClient(blob_connection_string);

            BlobContainerClient _container_client = _client.GetBlobContainerClient(container_name);


            BlobClient _blob_client = _container_client.GetBlobClient(blob_name);


            MemoryStream _memory = new MemoryStream();

            _blob_client.DownloadTo(_memory);

            StreamReader _reader = new StreamReader(_memory);
            Console.WriteLine(_reader.ReadToEnd());

            BlobLeaseClient _blob_lease_client = _blob_client.GetBlobLeaseClient();
            BlobLease _lease = _blob_lease_client.Acquire(TimeSpan.FromSeconds(60));

            Console.WriteLine($"The lease is {_lease.LeaseId}");

            StreamWriter _writer = new StreamWriter(_memory);
            _writer.Write("This is a change az204");
            _writer.Flush();

            _memory.Position = 0;

            BlobUploadOptions _blobUploadOptions = new BlobUploadOptions()
            {
                Conditions = new BlobRequestConditions()
                {
                    LeaseId = _lease.LeaseId
                }
            };

            _blob_client.Upload(_memory, _blobUploadOptions);
            _blob_lease_client.Release();


            Console.WriteLine("Change made");

            Console.ReadKey();
        }
    }
}
