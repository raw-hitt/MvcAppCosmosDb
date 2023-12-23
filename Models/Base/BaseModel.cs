namespace MvcAppCosmosDb.Models.Base
{
    public class BaseModel
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
