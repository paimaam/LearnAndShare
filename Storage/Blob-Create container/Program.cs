using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;

namespace Blob_Create_container
{
    class Program
    {
        // Ensure to replace the connection string and the container name
        private static string blob_connection_string = "";
        private static string container_name = "az204";

        private static string local_blob = @"";
        private static string blob_name = "abc1.json";


        static void Main(string[] args)
        {

            #region Blob container
            BlobServiceClient _client = new BlobServiceClient(blob_connection_string);

            BlobContainerClient _container_client = _client.CreateBlobContainer(container_name, PublicAccessType.Blob);

            Console.WriteLine("Container created");
            Console.ReadKey();
            #endregion


            #region Add Blob
            //BlobServiceClient _client = new BlobServiceClient(blob_connection_string);

            //BlobContainerClient _container_client = _client.GetBlobContainerClient(container_name);


            //BlobClient _blob_client = _container_client.GetBlobClient(blob_name);

            //_blob_client.Upload(local_blob);


            //Console.WriteLine("Blob added");
            //Console.ReadKey();
            #endregion


            #region List Blob
            //BlobServiceClient _client = new BlobServiceClient(blob_connection_string);

            //BlobContainerClient _container_client = _client.GetBlobContainerClient(container_name);

            //foreach (BlobItem item in _container_client.GetBlobs())
            //{
            //    Console.WriteLine(item.Name);
            //}

            //Console.ReadKey();
            #endregion

            #region Download Blob
            //BlobServiceClient _client = new BlobServiceClient(blob_connection_string);

            //BlobContainerClient _container_client = _client.GetBlobContainerClient(container_name);

            //BlobClient _blob_client = _container_client.GetBlobClient(blob_name);

            //_blob_client.DownloadTo(local_blob);

            //Console.WriteLine("Blob downloaded");
            //Console.ReadKey();
            #endregion
        }
    }
}
