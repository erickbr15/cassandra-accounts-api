using Cassandra.Accounts.Common.Model.Cassandra;

namespace Cassandra.Accounts.Main.Data.Mapping
{
    /// <summary>
    ///     Cassandra configuration mapping for the table trades_by_a_sd
    /// </summary>
    public class TradesByAccountQ5Mapping : Cassandra.Mapping.Mappings
    {
        /// <summary>
        ///     Creates an instance of <see cref="TradesByAccountQ5Mapping"/> initializing the cassandra data model configuration mapping
        /// </summary>
        public TradesByAccountQ5Mapping()
        {
            For<TradesByAccountQ5>()
            .TableName("trades_by_a_sd")

            .PartitionKey(t => t.Account)
            .ClusteringKey(t => t.Type, Cassandra.Mapping.SortOrder.Ascending)
            .ClusteringKey(t => t.TradeDate, Cassandra.Mapping.SortOrder.Descending)

            .Column(t => t.Account, column => column.WithName("account"))
            .Column(t => t.TradeDate, column => column.WithName("trade_id"))
            .Column(t => t.Type, column => column.WithName("type"))
            .Column(t => t.Symbol, column => column.WithName("symbol"))
            .Column(t => t.Shares, column => column.WithName("shares"))
            .Column(t => t.Price, column => column.WithName("price"))
            .Column(t => t.Amount, column => column.WithName("amount"));
        }
    }
}
