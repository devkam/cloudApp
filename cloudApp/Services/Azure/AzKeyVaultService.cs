using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using cloudApp.Services.Azure.Interfaces;
using System;

namespace cloudApp.Services.Azure
{
    public class AzKeyVaultService : IAzKeyVaultService
    {
        private readonly SecretClient _client;

        public AzKeyVaultService(string keyVaultName)
        {
            var keyVaultUri = $"https://{keyVaultName}.vault.azure.net";
            _client = new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential(true)); ;
        }

        public string GetSecret(string name)
        {
            KeyVaultSecret secret = _client.GetSecret(name);
            return secret.Value;
        }
    }
}
