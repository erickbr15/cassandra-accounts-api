namespace Cassandra.Accounts.Main.Data
{
    /// <summary>
    ///     Helper to create the Cassandra DDL statements
    /// </summary>
    internal static class CassandraDdlStatementQueryBuilder
    {
        /// <summary>
        ///     Creates a statement to drop an existing keyspace
        /// </summary>
        /// <param name="keyspace">
        ///     The keyspace name
        /// </param>
        /// <returns>
        ///     An intance of <see cref="IStatement"/>
        /// </returns>
        internal static IStatement BuildDropIfExistsStatement(string keyspace)
        {
            var query = $"DROP KEYSPACE IF EXISTS {keyspace}";
            return new SimpleStatement(query);
        }

        /// <summary>
        ///     Creates an statement to create a new keyspace
        /// </summary>
        /// <param name="keyspace">
        ///     The keyspace name
        /// </param>
        /// <returns>
        ///     An intance of <see cref="IStatement"/>
        /// </returns>
        internal static IStatement BuildCreateKeySpaceStatement(string keyspace)
        {
            var query = $"CREATE KEYSPACE {keyspace} WITH REPLICATION = {{ 'class' : 'NetworkTopologyStrategy', 'datacenter1' : 1 }}";
            return new SimpleStatement(query);
        }

        /// <summary>
        ///     Creates an statement to create the table accounts_by_user
        /// </summary>
        /// <param name="keyspace">
        ///     The table keyspace
        /// </param>
        /// <returns>
        ///     An intance of <see cref="IStatement"/>
        /// </returns>
        internal static IStatement BuildCreateTableAccountsByUserStatement(string keyspace)
        {
            var query = $"CREATE TABLE IF NOT EXISTS {keyspace}.accounts_by_user(" +
                            "username TEXT," +
                            "account_number TEXT," +
                            "cash_balance DECIMAL," +
                            "name TEXT STATIC," +
                            "PRIMARY KEY((username), account_number))";
            
            return new SimpleStatement(query);
        }

        /// <summary>
        ///     Creates an stament to create the table possitions_by_account
        /// </summary>
        /// <param name="keyspace">
        ///     The table keyspace
        /// </param>
        /// <returns>
        ///     An intance of <see cref="IStatement"/>
        /// </returns>
        internal static IStatement BuildCreateTablePositionsByAccountStatement(string keyspace)
        {
            var query = $"CREATE TABLE IF NOT EXISTS {keyspace}.possitions_by_account(" +
                            "account TEXT," +
                            "symbol TEXT," +
                            "quantity INT," +
                            "PRIMARY KEY((account), symbol))";
            
            return new SimpleStatement(query);
        }

        /// <summary>
        ///     Creates an statement to create the table trades_by_a_d
        /// </summary>
        /// <param name="keyspace">
        ///     The table keyspace
        /// </param>
        /// <returns>
        ///     An intance of <see cref="IStatement"/>
        /// </returns>
        internal static IStatement BuildCreateTableTradesByAccountStatement(string keyspace)
        {
            var query = $"CREATE TABLE IF NOT EXISTS {keyspace}.trades_by_a_d (" +
                "account TEXT," +
                "trade_id TIMEUUID," +
                "type TEXT," +
                "symbol TEXT," +
                "shares INT," +
                "price DECIMAL," +
                "amount DECIMAL," +
                "PRIMARY KEY((account), trade_id)" +
                ") WITH CLUSTERING ORDER BY(trade_id DESC)";

            return new SimpleStatement(query);
        }

        /// <summary>
        ///     Creates an statement to create the table trades_by_a_td
        /// </summary>
        /// <param name="keyspace">
        ///     The table keyspace
        /// </param>
        /// <returns>
        ///     An intance of <see cref="IStatement"/>
        /// </returns>
        internal static IStatement BuildCreateTableTradesByAccountQ3Statement(string keyspace)
        {
            var query = $"CREATE TABLE IF NOT EXISTS {keyspace}.trades_by_a_td (" +
                "account TEXT," +
                "trade_id TIMEUUID," +
                "type TEXT," +
                "symbol TEXT," +
                "shares INT," +
                "price DECIMAL," +
                "amount DECIMAL," +
                "PRIMARY KEY((account), type, trade_id)" +
                ") WITH CLUSTERING ORDER BY(type ASC, trade_id DESC)";

            return new SimpleStatement(query);
        }

        /// <summary>
        ///     Creates an statement to create the table trades_by_a_std
        /// </summary>
        /// <param name="keyspace">
        ///     The table keyspace
        /// </param>
        /// <returns>
        ///     An intance of <see cref="IStatement"/>
        /// </returns>
        internal static IStatement BuildCreateTableTradesByAccountQ4Statement(string keyspace)
        {
            var query = $"CREATE TABLE IF NOT EXISTS {keyspace}.trades_by_a_std (" +
                "account TEXT," +
                "trade_id TIMEUUID," +
                "type TEXT," +
                "symbol TEXT," +
                "shares INT," +
                "price DECIMAL," +
                "amount DECIMAL," +
                "PRIMARY KEY((account), type, symbol, trade_id)" +
                ") WITH CLUSTERING ORDER BY(type ASC, symbol ASC, trade_id DESC)";

            return new SimpleStatement(query);
        }

        /// <summary>
        ///     Creates an statement to create the table trades_by_a_sd
        /// </summary>
        /// <param name="keyspace">
        ///     The table keyspace
        /// </param>
        /// <returns>
        ///     An intance of <see cref="IStatement"/>
        /// </returns>
        internal static IStatement BuildCreateTableTradesByAccountQ5Statement(string keyspace)
        {
            var query = $"CREATE TABLE IF NOT EXISTS {keyspace}.trades_by_a_sd (" +
                "account TEXT," +
                "trade_id TIMEUUID," +
                "type TEXT," +
                "symbol TEXT," +
                "shares INT," +
                "price DECIMAL," +
                "amount DECIMAL," +
                "PRIMARY KEY((account), symbol, trade_id)" +
                ") WITH CLUSTERING ORDER BY(symbol ASC, trade_id DESC)";

            return new SimpleStatement(query);
        }
    }
}
