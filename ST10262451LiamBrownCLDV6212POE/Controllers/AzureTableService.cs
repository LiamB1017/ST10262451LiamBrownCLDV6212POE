
using Azure;

public class AzureTableService
{
    private readonly TableClient _customerTableClient;
    private readonly TableClient _productTableClient;

    public AzureTableService(string storageConnectionString)
    {
        var serviceClient = new TableServiceClient(storageConnectionString);
        _customerTableClient = serviceClient.GetTableClient("CustomerProfiles");
        _productTableClient = serviceClient.GetTableClient("ProductInfo");

        _customerTableClient.CreateIfNotExists();
        _productTableClient.CreateIfNotExists();
    }

    public async Task AddCustomerProfileAsync(CustomerProfile customer)
    {
        await _customerTableClient.AddEntityAsync(customer);
    }

    public async Task AddProductInfoAsync(ProductInfo product)
    {
        await _productTableClient.AddEntityAsync(product);
    }

    // Additional CRUD operations...
}

public class CustomerProfile : ITableEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    // Additional fields...

    public ETag ETag { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
}

public class ProductInfo : ITableEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    // Additional fields...

    public ETag ETag { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
}
