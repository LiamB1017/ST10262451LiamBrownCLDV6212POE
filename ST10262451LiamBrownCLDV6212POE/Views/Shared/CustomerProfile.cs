// /Shared/CustomerProfile.cs
using Azure;

namespace ABC_Retail_App_Functions.Shared
{
    public class CustomerProfile : ITableEntity
    {
        public string PartitionKey { get; set; } // Typically "Customer"
        public string RowKey { get; set; } // Unique identifier, e.g., Customer ID
        public string Name { get; set; }
        public string Email { get; set; }
        // Additional fields as needed

        public ETag ETag { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
    }
}
