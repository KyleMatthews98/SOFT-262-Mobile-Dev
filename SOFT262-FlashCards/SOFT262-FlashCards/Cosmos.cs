using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using SOFT262_FlashCards;

namespace Setup
{

    public class Cosmos
    {
        private static readonly string EndpointUri = "https://jwalker.documents.azure.com:443/";

        // The primary key for the Azure Cosmos account.
        private static readonly string PrimaryKey = "6pkiRTCzakSbPQIDAOrfc0r53p9R2RazUEIf5SWKVdTaossjD3SsS1LDuyGvX30Y20WKIsz4YaFsELN4TaOj6g==";
        // The Cosmos client instance
        private CosmosClient cosmosClient;

        // The database we will create
        private Database database;

        // The container we will create.
        private Container container;

        // The name of the database and container we will create
        private string databaseId = "FlashCards";
        private string containerId = "Items";

        public static async Task Main(string[] args)
        {
            var p = new Cosmos();
            await p.Go();
        }

        public async Task Go()
        {
            this.cosmosClient = new CosmosClient(EndpointUri, PrimaryKey, new CosmosClientOptions()
            {
                ApplicationName = "FlashCards"
            });

            // Create a new database
            this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);

            //Create container
            this.container = await this.database.CreateContainerIfNotExistsAsync(containerId, "/Questions", 400);

            //Add initial records
            await AddNewTopic(new QnA("Mercury", ""));
            await AddNewTopic(new QnA("Venus", ""));
            
            //Read back all records        
            await QueryAllRecords(true);
            await QueryAllRecords(false);

            //Update record
            var mars = new QnA("","");

            //Delete record
            await DeleteItemAsync("Uranus");
        }

        async Task AddNewTopic(QnA p)
        {
            try
            {
                // Read the item to see if it exists.  The ID (unique) is Name property
                ItemResponse<QnA> planetResponse = await this.container.ReadItemAsync<QnA>(p.Answer, new PartitionKey(p.Question));
                Console.WriteLine("Item in database with id: {0} already exists\n", planetResponse.Resource.Answer);
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                ItemResponse<QnA> planetResponse = await this.container.CreateItemAsync<QnA>(p, new PartitionKey(p.Question));

                // Note that after creating the item, we can access the body of the item with the Resource property off the ItemResponse. We can also access the RequestCharge property to see the amount of RUs consumed on this request.
                Console.WriteLine("Created item in database with id: {0} Operation consumed {1} RUs.\n", planetResponse.Resource.Answer, planetResponse.RequestCharge);
            }
        }

        async Task QueryAllRecords(bool exp)
        {
            Console.WriteLine($"Explored is {exp}");
            var sql = $"SELECT * FROM c where c.IsExplored = {exp.ToString().ToLower()}";
            Console.WriteLine("Running query: {0}\n", sql);
            QueryDefinition queryDefinition = new QueryDefinition(sql);
            FeedIterator<QnA> queryResultSetIterator = this.container.GetItemQueryIterator<QnA>(queryDefinition);

            List<QnA> planets = new List<QnA>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<QnA> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (QnA planet in currentResultSet)
                {
                    planets.Add(planet);
                    Console.WriteLine("\tRead {0}\n", planet);
                }
            }
        }

        //Update


        //Delete
        private async Task DeleteItemAsync(string name)
        {
            // Delete an item. Note we must provide the partition key value and id of the item to delete
            ItemResponse<QnA> resp = await this.container.DeleteItemAsync<QnA>(name, new PartitionKey("Sol"));
            Console.WriteLine($"Deleted {name} - response {resp}");
        }

        //Delete Everything
        private async Task DeleteDatabaseAndCleanupAsync()
        {
            DatabaseResponse databaseResourceResponse = await this.database.DeleteAsync();
            // Also valid: await this.cosmosClient.Databases["FamilyDatabase"].DeleteAsync();


            //Dispose of CosmosClient
            this.cosmosClient.Dispose();
        }

    }
}
