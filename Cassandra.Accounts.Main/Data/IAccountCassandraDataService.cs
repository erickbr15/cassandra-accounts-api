using Cassandra.Accounts.Common.Model;
using Cassandra.Accounts.Common.Model.Cassandra;

namespace Cassandra.Accounts.Main.Data
{
    /// <summary>
    ///     Account cassandra data service contract
    /// </summary>
    public interface IAccountCassandraDataService
    {
        /// <summary>
        ///     Drops the accounts keyspace if exists
        /// </summary>
        Task DeleteKeySpaceIfExistsAsync();
        
        /// <summary>
        ///     Creates the accounts keyspace
        /// </summary>
        /// <returns>
        ///     A text that represents the operation result
        /// </returns>
        Task<string> CreateKeySpaceAsync();

        /// <summary>
        ///     Creates the tables 
        /// </summary>
        /// <returns>
        ///     A text that represents the operation result
        /// </returns>
        Task<string> CreateSchemaAsync();

        /// <summary>
        ///     Inserts a collection of accounts by users in the table accounts_by_user
        /// </summary>
        /// <param name="accountByUsers">
        ///     A collection of accounts by users
        /// </param>
        Task InsertAccountByUsersAsync(IEnumerable<AccountByUser> accountByUsers);

        /// <summary>
        ///     Inserts a collection of instrument symbos by accounts in the table possitions_by_account
        /// </summary>
        /// <param name="possitionsByAccounts">
        ///     A collection of possitions by accounts
        /// </param>
        Task InsertPossitionsByAccountAsync(IEnumerable<PossitionsByAccount> possitionsByAccounts);

        /// <summary>
        ///     Inserts a collection of trades by accounts in the table trades_by_a_d
        /// </summary>
        /// <param name="tradesByAccounts">
        ///     A collection of trades by accounts
        /// </param>
        Task InsertTradesByAccountAsync(IEnumerable<TradesByAccount> tradesByAccounts);

        /// <summary>
        ///     Inserts a collection of trades by accounts in the table trades_by_a_td
        /// </summary>
        /// <param name="tradesByAccounts">
        ///     A collection of trades by accounts
        /// </param>
        Task InsertTradesByAccountAsync(IEnumerable<TradesByAccountQ3> tradesByAccounts);

        /// <summary>
        ///     Inserts a collection of trades by accounts in the table trades_by_a_std
        /// </summary>
        /// <param name="tradesByAccounts">
        ///     A collection of trades by accounts
        /// </param>
        Task InsertTradesByAccountAsync(IEnumerable<TradesByAccountQ4> tradesByAccounts);

        /// <summary>
        ///     Inserts a collection of trades by accounts in the table trades_by_a_sd
        /// </summary>
        /// <param name="tradesByAccounts">
        ///     A collection of trades by accounts
        /// </param>
        Task InsertTradesByAccountAsync(IEnumerable<TradesByAccountQ5> tradesByAccounts);

        /// <summary>
        ///     Gets the accounts by user
        /// </summary>
        /// <param name="username">
        ///     The username
        /// </param>
        /// <returns>
        ///     A populated list of <see cref="AccountByUser"/> that represents the accounts by user
        /// </returns>
        Task<IList<AccountByUser>> GetAccountsByUserAsync(string username);

        /// <summary>
        ///     Gets the instrument symbols by account
        /// </summary>
        /// <param name="accountNumber">
        ///     The account number
        /// </param>
        /// <returns>
        ///     A populated list of <see cref="PossitionsByAccount"/> that represents the possitions by account
        /// </returns>
        Task<IList<PossitionsByAccount>> GetPossitionsByAccountAsync(string accountNumber);

        /// <summary>
        ///     Searches for trades
        /// </summary>
        /// <param name="criteria">
        ///     An instance of <see cref="SearchTradesCriteria"/> that represents the search criteria
        /// </param>
        /// <returns>
        ///     A populated list of <see cref="ITradesByAccount"/> that represents the trades
        /// </returns>
        Task<IList<ITradesByAccount>> SearchTradesAsync(SearchTradesCriteria criteria);
    }
}
