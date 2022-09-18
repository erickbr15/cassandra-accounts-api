using Cassandra.Accounts.Common;
using Cassandra.Accounts.Common.Model;
using Cassandra.Accounts.Common.Model.Cassandra;
using Cassandra.Mapping;
using Cassandra.Data.Linq;
using System.Security.Authentication;

namespace Cassandra.Accounts.Main.Data
{
    /// <summary>
    ///     Concrete implementation of <see cref="IAccountCassandraDataService"/>
    /// </summary>
    public class AccountCassandraDataService : IAccountCassandraDataService 
    {
        private readonly CassandraConnectionOptions _cassandraConnectionOptions;

        /// <summary>
        ///     Creates an instance of <see cref="AccountCassandraDataService"/>
        /// </summary>
        public AccountCassandraDataService()
        {
            _cassandraConnectionOptions = new CassandraConnectionOptions();                        
        }       

        /// <inheritdoc />
        public async Task DeleteKeySpaceIfExistsAsync()
        {
            using (var cluster = this.BuildCluster())
            {
                using (var session = cluster.Connect())
                {
                    await session.ExecuteAsync(CassandraDdlStatementQueryBuilder.BuildDropIfExistsStatement(CassandraConnectionOptions.Keyspace));
                }
            }
        }

        /// <inheritdoc />
        public async Task<string> CreateKeySpaceAsync()
        {
            var metadataText = string.Empty;
            using (var cluster = this.BuildCluster())
            {
                using(var session = cluster.Connect())
                {
                    await session.ExecuteAsync(CassandraDdlStatementQueryBuilder.BuildCreateKeySpaceStatement(CassandraConnectionOptions.Keyspace));
                }

                var metadata = cluster.Metadata.GetKeyspace(CassandraConnectionOptions.Keyspace);
                metadataText = metadata == null ? string.Empty : metadata.ExportAsString();
            }

            return metadataText;
        }

        /// <inheritdoc />
        public async Task<string> CreateSchemaAsync()
        {
            var tablesMetadataText = string.Empty;

            using (var cluster = this.BuildCluster())
            {
                using(var session = cluster.Connect(CassandraConnectionOptions.Keyspace))
                {
                    await session.ExecuteAsync(CassandraDdlStatementQueryBuilder.BuildCreateTableAccountsByUserStatement(CassandraConnectionOptions.Keyspace));
                    await session.ExecuteAsync(CassandraDdlStatementQueryBuilder.BuildCreateTablePositionsByAccountStatement(CassandraConnectionOptions.Keyspace));
                    await session.ExecuteAsync(CassandraDdlStatementQueryBuilder.BuildCreateTableTradesByAccountStatement(CassandraConnectionOptions.Keyspace));
                    await session.ExecuteAsync(CassandraDdlStatementQueryBuilder.BuildCreateTableTradesByAccountQ3Statement(CassandraConnectionOptions.Keyspace));
                    await session.ExecuteAsync(CassandraDdlStatementQueryBuilder.BuildCreateTableTradesByAccountQ4Statement(CassandraConnectionOptions.Keyspace));
                    await session.ExecuteAsync(CassandraDdlStatementQueryBuilder.BuildCreateTableTradesByAccountQ5Statement(CassandraConnectionOptions.Keyspace));
                }

                var metadata = cluster.Metadata.GetKeyspace(CassandraConnectionOptions.Keyspace);
                tablesMetadataText = string.Join(",", metadata.GetTablesMetadata().Select(m => m.Name));
            }

            return tablesMetadataText;
        }

        /// <inheritdoc />
        public async Task InsertAccountByUsersAsync(IEnumerable<AccountByUser> accountByUsers)
        {
            if(accountByUsers == null)
            {
                return;
            }

            using (var cluster = this.BuildCluster())
            {
                using (var session = cluster.Connect(CassandraConnectionOptions.Keyspace))
                {
                    var cassandraMapper = new Mapper(session);
                    foreach (var item in accountByUsers)
                    {
                        await cassandraMapper.InsertAsync<AccountByUser>(item);
                    }
                }
            }
        }

        /// <inheritdoc />
        public async Task InsertPossitionsByAccountAsync(IEnumerable<PossitionsByAccount> possitionsByAccounts)
        {
            if (possitionsByAccounts == null)
            {
                return;
            }

            using (var cluster = this.BuildCluster())
            {
                using (var session = cluster.Connect(CassandraConnectionOptions.Keyspace))
                {
                    var cassandraMapper = new Mapper(session);
                    foreach (var item in possitionsByAccounts)
                    {
                        await cassandraMapper.InsertAsync<PossitionsByAccount>(item);
                    }
                }
            }
        }

        /// <inheritdoc />
        public async Task InsertTradesByAccountAsync(IEnumerable<TradesByAccount> tradesByAccounts)
        {
            if (tradesByAccounts == null)
            {
                return;
            }

            using (var cluster = this.BuildCluster())
            {
                using (var session = cluster.Connect(CassandraConnectionOptions.Keyspace))
                {
                    var cassandraMapper = new Mapper(session);
                    foreach (var item in tradesByAccounts)
                    {
                        await cassandraMapper.InsertAsync<TradesByAccount>(item);
                    }
                }
            }
        }

        /// <inheritdoc />
        public async Task InsertTradesByAccountAsync(IEnumerable<TradesByAccountQ3> tradesByAccounts)
        {
            if (tradesByAccounts == null)
            {
                return;
            }

            using (var cluster = this.BuildCluster())
            {
                using (var session = cluster.Connect(CassandraConnectionOptions.Keyspace))
                {
                    var cassandraMapper = new Mapper(session);
                    foreach (var item in tradesByAccounts)
                    {
                        await cassandraMapper.InsertAsync<TradesByAccountQ3>(item);
                    }
                }
            }
        }

        /// <inheritdoc />
        public async Task InsertTradesByAccountAsync(IEnumerable<TradesByAccountQ4> tradesByAccounts)
        {
            if (tradesByAccounts == null)
            {
                return;
            }

            using (var cluster = this.BuildCluster())
            {
                using (var session = cluster.Connect(CassandraConnectionOptions.Keyspace))
                {
                    var cassandraMapper = new Mapper(session);
                    foreach (var item in tradesByAccounts)
                    {
                        await cassandraMapper.InsertAsync<TradesByAccountQ4>(item);
                    }
                }
            }
        }

        /// <inheritdoc />
        public async Task InsertTradesByAccountAsync(IEnumerable<TradesByAccountQ5> tradesByAccounts)
        {
            if (tradesByAccounts == null)
            {
                return;
            }

            using (var cluster = this.BuildCluster())
            {
                using (var session = cluster.Connect(CassandraConnectionOptions.Keyspace))
                {
                    var cassandraMapper = new Mapper(session);
                    foreach (var item in tradesByAccounts)
                    {
                        await cassandraMapper.InsertAsync<TradesByAccountQ5>(item);
                    }
                }
            }
        }

        /// <inheritdoc />
        public async Task<IList<AccountByUser>> GetAccountsByUserAsync(string username)
        {            
            if (string.IsNullOrWhiteSpace(username))
            {
                return new List<AccountByUser>();
            }

            var queryResult = new List<AccountByUser>();

            using (var cluster = this.BuildCluster())
            {
                using (var session = cluster.Connect(CassandraConnectionOptions.Keyspace))
                {
                    var accountsByUser = new Table<AccountByUser>(session);
                    queryResult = (await accountsByUser.Where(a => a.Username == username).ExecuteAsync()).ToList();
                }
            }

            return queryResult;
        }

        /// <inheritdoc />
        public async Task<IList<PossitionsByAccount>> GetPossitionsByAccountAsync(string accountNumber)
        {            
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                return new List<PossitionsByAccount>();
            }

            var queryResult = new List<PossitionsByAccount>();
            using (var cluster = this.BuildCluster())
            {
                using (var session = cluster.Connect(CassandraConnectionOptions.Keyspace))
                {
                    var possitionsByAccount = new Table<PossitionsByAccount>(session);
                    queryResult = (await possitionsByAccount.Where(p => p.Account == accountNumber).ExecuteAsync()).ToList();
                }
            }

            return queryResult;
        }

        /// <inheritdoc />
        public async Task<IList<ITradesByAccount>> SearchTradesAsync(SearchTradesCriteria criteria)
        {
            if(criteria == null)
            {
                return new List<ITradesByAccount>();
            }

            var queryResult = new List<ITradesByAccount>();

            using (var cluster = this.BuildCluster())
            {
                using (var session = cluster.Connect(CassandraConnectionOptions.Keyspace))
                {
                    if (criteria.CanSearchByAccountAndFlightAndOtherCriteria())
                    {
                        queryResult = await SearchTradesAsync(session, criteria.AccountNumber, criteria.StartDate, criteria.EndDate, criteria.Type, criteria.InstrumentSymbol);
                    }
                    else if (criteria.CanSearchByAccountAndFlight())
                    {
                        queryResult = await SearchTradesAsync(session, criteria.AccountNumber, criteria.StartDate, criteria.EndDate);
                    }
                    else if (criteria.CanSearchByAccount())
                    {
                        queryResult = await SearchTradesAsync(session, criteria.AccountNumber);
                    }
                }
            }

            return queryResult;
        }

        /// <summary>
        ///     Connect to cassandra cluster  (Cassandra API on Azure Cosmos DB supports only TLSv1.2)
        /// </summary>
        private Cassandra.Cluster BuildCluster()
        {
            var options = new Cassandra.SSLOptions(SslProtocols.Tls12, true, Security.ValidateServerCertificate);

            options.SetHostNameResolver((ipAddress) => _cassandraConnectionOptions.CassandraContactPoint);

            var cluster = Cassandra.Cluster
                .Builder()
                .WithCredentials(_cassandraConnectionOptions.Username, _cassandraConnectionOptions.Password)
                .WithPort(_cassandraConnectionOptions.CassandraPort)
                .AddContactPoint(_cassandraConnectionOptions.CassandraContactPoint)
                .WithSSL(options)
                .Build();

            return cluster;
        }

        /// <summary>
        ///     Performs a search of trades by account on trades_by_a_d
        /// </summary>
        /// <param name="session">
        ///     An instance of <see cref="Cassandra.ISession"/>
        /// </param>
        /// <param name="accountNumber">
        ///     The account number
        /// </param>
        /// <returns>
        ///     A populated list of <see cref="ITradesByAccount"/>
        /// </returns>
        private async Task<List<ITradesByAccount>> SearchTradesAsync(Cassandra.ISession session, string? accountNumber)
        {
            var tradesByAccount = new Table<TradesByAccount>(session);            
            var queryResult = (await tradesByAccount.Where(p => p.Account == accountNumber).ExecuteAsync()).ToList<ITradesByAccount>();

            return queryResult;
        }

        /// <summary>
        ///     Performs a search of trades by account and flight dates on trades_by_a_d
        /// </summary>
        /// <param name="session">
        ///     An instance of <see cref="Cassandra.ISession"/>
        /// </param>
        /// <param name="accountNumber">
        ///     The account number
        /// </param>
        /// <param name="startDate">
        ///     Flight start date
        /// </param>
        /// <param name="endDate">
        ///     Flight end date
        /// </param>
        /// <returns>
        ///     A populated list of <see cref="ITradesByAccount"/>
        /// </returns>
        private async Task<List<ITradesByAccount>> SearchTradesAsync(Cassandra.ISession session, string? accountNumber, DateTime? startDate, DateTime? endDate)
        {
            var tradesByAccount = new Table<TradesByAccount>(session);

            var queryResult = (await tradesByAccount.Where(p => p.Account == accountNumber &&
                p.TradeDate.CompareTo(TimeUuid.NewId(startDate ?? DateTime.Now)) >= 0 &&
                p.TradeDate.CompareTo(TimeUuid.NewId(endDate ?? DateTime.Now)) <= 0).ExecuteAsync()).ToList<ITradesByAccount>();


            return queryResult;
        }

        /// <summary>
        ///     Performs a search of trades by account number, flight dates, transaction type and instrument symbol
        /// </summary>
        /// <param name="session">
        ///     An instance of <see cref="Cassandra.ISession"/>
        /// </param>
        /// <param name="accountNumber">
        ///     The account number
        /// </param>
        /// <param name="startDate">
        ///     Flight start date
        /// </param>
        /// <param name="endDate">
        ///     Flight end date
        /// </param>
        /// <param name="transactionType">
        ///     The transaction type
        /// </param>
        /// <param name="instrumentSymbol">
        ///     The instrument symbol
        /// </param>
        /// <returns>
        ///     A populated list of <see cref="ITradesByAccount"/>
        /// </returns>
        private async Task<List<ITradesByAccount>> SearchTradesAsync(Cassandra.ISession session, string? accountNumber, DateTime? startDate, DateTime? endDate, string? transactionType, string? instrumentSymbol)
        {
            var isTransactionTypeSetup = !string.IsNullOrWhiteSpace(transactionType);
            var isInstrumentSymbolSetup = !string.IsNullOrWhiteSpace(instrumentSymbol);

            var queryResult = new List<ITradesByAccount>();

            if (isTransactionTypeSetup && isInstrumentSymbolSetup)
            {
                var tradesByAccount = new Table<TradesByAccountQ4>(session);

                queryResult = (await tradesByAccount.Where(p => p.Account == accountNumber &&
                    p.TradeDate.CompareTo(TimeUuid.NewId(startDate ?? DateTime.Now)) >= 0 &&
                    p.TradeDate.CompareTo(TimeUuid.NewId(endDate ?? DateTime.Now)) <= 0 &&
                    p.Type == transactionType &&
                    p.Symbol == instrumentSymbol).ExecuteAsync()).ToList<ITradesByAccount>();

            }
            else if(isTransactionTypeSetup)
            {
                var tradesByAccount = new Table<TradesByAccountQ3>(session);

                queryResult = (await tradesByAccount.Where(p => p.Account == accountNumber &&
                    p.Type == transactionType &&
                    p.TradeDate.CompareTo(TimeUuid.NewId(startDate ?? DateTime.Now)) >= 0 &&
                    p.TradeDate.CompareTo(TimeUuid.NewId(endDate ?? DateTime.Now)) <= 0).ExecuteAsync()).ToList<ITradesByAccount>();
            }
            else if(isInstrumentSymbolSetup)
            {
                var tradesByAccount = new Table<TradesByAccountQ5>(session);

                queryResult = (await tradesByAccount.Where(p => p.Account == accountNumber &&
                    p.TradeDate.CompareTo(TimeUuid.NewId(startDate ?? DateTime.Now)) >= 0 &&
                    p.TradeDate.CompareTo(TimeUuid.NewId(endDate ?? DateTime.Now)) <= 0 &&
                    p.Symbol == instrumentSymbol).ExecuteAsync()).ToList<ITradesByAccount>();
            }

            return queryResult;
        }
    }
}