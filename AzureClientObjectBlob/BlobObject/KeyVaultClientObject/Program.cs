using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;

namespace KeyVaultClientObject
{
    class Program
    {
        private static string tenantid = "";
        private static string clientid = "";
        private static string clientsecret = "";

        private static string keyvault_url = "";
        private static string secret_name = "";
        static void Main(string[] args)
        {

            ClientSecretCredential _client_secret = new ClientSecretCredential(tenantid, clientid, clientsecret);

            SecretClient _secret_client = new SecretClient(new Uri(keyvault_url), _client_secret);

            var secret = _secret_client.GetSecret(secret_name);

            Console.WriteLine($"The value of the secret is {secret.Value.Value}");

            Console.ReadKey();

        }
    }
}
