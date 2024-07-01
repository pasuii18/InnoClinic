using Azure.Identity;
using DAL.Common.Options;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace DAL.Common.Clients;

public class CosmosDbClient(IOptions<CosmosDbOptions> options) 
    : CosmosClient(options.Value.AccountEndpoint, options.Value.AccountKey);