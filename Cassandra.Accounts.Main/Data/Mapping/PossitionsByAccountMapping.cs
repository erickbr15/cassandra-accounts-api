using Cassandra.Accounts.Common.Model.Cassandra;

namespace Cassandra.Accounts.Main.Data.Mapping
{
    /// <summary>
    ///     Cassandra configuration mapping for the table possitions_by_account
    /// </summary>
    public class PossitionsByAccountMapping : Cassandra.Mapping.Mappings
    {
        /// <summary>
        ///     Creates an instance of <see cref="PossitionsByAccountMapping"/> initializing the cassandra data model configuration mapping
        /// </summary>
        public PossitionsByAccountMapping()
        {
            For<PossitionsByAccount>()
            .TableName("possitions_by_account")
            .PartitionKey(t => t.Account)
            .Column(t => t.Account, column => column.WithName("account"))
            .Column(t => t.Symbol, column => column.WithName("symbol"))
            .Column(t => t.Quantity, column => column.WithName("quantity"));
        }
    }
}
