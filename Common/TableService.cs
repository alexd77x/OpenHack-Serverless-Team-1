using BFYOC.Function.Data;
using Microsoft.Azure.Cosmos.Table;
using System;

namespace BFYOC.Function.Common
{
public static class TableService
    {
        public static CloudTable GetTableReference(string tableName, bool createIfNotExists = false)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(TableService.StorageConnectionString);
            CloudTableClient client = account.CreateCloudTableClient();

            var table = client.GetTableReference(tableName);

            if (createIfNotExists)
            {
                table.CreateIfNotExists();
            }

            return table;
        }

        public static void AddObject<T>(CloudTable table, T value) where T : ITableEntity
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            TableOperation operation = TableOperation.InsertOrReplace(value);
            table.Execute(operation);
        }

        // public static OrderFilesToProcess InsertOrUpdate(CloudTable table, string partitionKey, string entityId)
        // {
        //     if (table == null)
        //     {
        //         throw new ArgumentNullException(nameof(table));
        //     }

        //     TableQuery<OrderFilesToProcess> tableQuery = new TableQuery<OrderFilesToProcess>().Where(
        //         TableQuery.CombineFilters(
        //             TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey),
        //                 TableOperators.And,
        //             TableQuery.GenerateFilterCondition("EntityId", QueryComparisons.Equal, entityId)));

        //     var matchedEntity = table.ExecuteQuery(tableQuery);
        //     if (matchedEntity.Any())
        //     {
        //         return matchedEntity
        //     }

        //     table.ExecuteQuery<T>(new TableQuery<T>().)
        //     TableOperation operation = TableOperation.InsertOrReplace(value);
        //     table.Execute(operation);
        // }

        public static string StorageConnectionString
        {
            get { return Environment.GetEnvironmentVariable(TableService.StorageConnectionStringVariableName); }
        }

        /// <summary>
        /// Environment variable name for the storage connection string.
        /// </summary>
        public const string StorageConnectionStringVariableName = "orderbfyocteam1_STORAGE";
    }
}