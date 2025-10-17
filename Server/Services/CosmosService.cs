using Microsoft.Azure.Cosmos;
using SupportWebApp.Shared.Modeller;

namespace SupportWebApp.Server.Services
{
    /// <summary>
    /// Håndterer forbindelse til Cosmos DB og adgang til en bestemt container.
    /// </summary>
    
    public sealed class CosmosService
    {
        private readonly CosmosClient _client;
        private readonly Container _container;

        /// <summary>
        /// Forbind med connection string + database- og container-navn.
        /// (Vi implementerer indholdet i næste trin)
        /// </summary>
        public CosmosService(string connectionString, string databaseName, string containerName)
        {
            // Opret selve Cosmos-klienten ud fra connection string
            _client = new CosmosClient(connectionString);

            // Hent reference til den ønskede database
            Database database = _client.GetDatabase(databaseName);

            // Hent reference til containeren i databasen
            _container = database.GetContainer(containerName);
        }
        
        public async Task AddHenvendelse(SupportHenvendelse henvendelse)
        {
            // Opret dokumentet i containeren – partition key = kategori
            await _container.CreateItemAsync(henvendelse, new PartitionKey(henvendelse.Kategori));
        }
        
        public async Task<List<SupportHenvendelse>> HentAlleHenvendelser()
        {
            var query = _container.GetItemQueryIterator<SupportHenvendelse>("SELECT * FROM c");
            var results = new List<SupportHenvendelse>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }

    }
}