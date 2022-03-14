using Azure.Identity;
using Azure.Storage.Blobs;
using System;

namespace BlobObject
{
    class Program
    {

        // Ensure to change the connection string and other properties accordingly
        private static string blob_connection_string = "";
        private static string container_name = "az204";
        private static string local_blob = @"C:\tem\digtial-post.txt";
        private static string blob_name = "digital-post.txt";
        static void Main(string[] args)
        {

            BlobServiceClient _client = new BlobServiceClient(blob_connection_string);

            BlobContainerClient _container_client = _client.GetBlobContainerClient(container_name);


            BlobClient _blob_client = _container_client.GetBlobClient(blob_name);

            _blob_client.DownloadTo(local_blob);


            Console.WriteLine("Blob downloaded");
            Console.ReadKey();
        }
    }


    //class Program
    //{

    //    // Ensure to change the connection string and other properties accordingly
    //    private static string local_blob = @"";

    //    private static string tenantid = "";
    //    private static string clientid = "";
    //    private static string clientsecret = "";

    //    private static string blob_url = "";

    //    static void Main(string[] args)
    //    {

    //        ClientSecretCredential _client_credential = new ClientSecretCredential(tenantid, clientid, clientsecret);

    //        Uri blob_uri = new Uri(blob_url);


    //        BlobClient _blob_client = new BlobClient(blob_uri, _client_credential);

    //        _blob_client.DownloadTo(local_blob);


    //        Console.WriteLine("Blob downloaded using client creds");
    //        Console.ReadKey();
    //    }
}

