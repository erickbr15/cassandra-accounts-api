using Cassandra.Accounts.Common.Model.Cassandra;

namespace Cassandra.Accounts.Main.Data.Mapping
{
    /// <summary>
    ///     Cassandra configuration mapping for the table trades_by_a_std
    /// </summary>
    public class TradesByAccountQ4Mapping : Cassandra.Mapping.Mappings
    {
        /// <summary>
        ///     Creates an instance of <see cref="TradesByAccountQ4Mapping"/> initializing the cassandra data model configuration mapping
        /// </summary>
        public TradesByAccountQ4Mapping()
        {
            For<TradesByAccountQ4>()
            .TableName("trades_by_a_std")

            .PartitionKey(t => t.Account)
            .ClusteringKey(t => t.Type, Cassandra.Mapping.SortOrder.Ascending)
            .ClusteringKey(t => t.Symbol, Cassandra.Mapping.SortOrder.Ascending)
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
