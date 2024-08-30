
internal class TableServiceClient
{
    private string storageConnectionString;

    public TableServiceClient(string storageConnectionString)
    {
        this.storageConnectionString = storageConnectionString;
    }

    internal TableClient? GetTableClient(string v)
    {
        throw new NotImplementedException();
    }
}