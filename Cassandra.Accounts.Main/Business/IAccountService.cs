using Cassandra.Accounts.Common.Model;
using Cassandra.Accounts.Common.Model.Cassandra;

namespace Cassandra.Accounts.Main.Business
{
    /// <summary>
    ///     Account main service contract
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        ///     Generates the keyspace accounts
        /// </summary>
        /// <returns>
        ///     An instance of <see cref="ResultDto"/> which represents the operation result
        /// </returns>
        Task<ResultDto> GenerateKeyspaceAsync();

        /// <summary>
        ///     Generates the accounts tables
        /// </summary>
        /// <returns>
        ///     An instance of <see cref="ResultDto"/> which represents the operation result
        /// </returns>
        Task<ResultDto> GenerateSchemaAsync();

        /// <summary>
        ///     Generates the transactional data and populates the Cassandra data model
        /// </summary>
        /// <returns>
        ///     An instance of <see cref="ResultDto"/> which represents the operation result
        /// </returns>
        Task<ResultDto> GenerateDataAsync();

        /// <summary>
        ///     Gets a list accounts given a username
        /// </summary>
        /// <param name="username">
        ///     The username
        /// </param>
        /// <returns>
        ///     A populated list of <see cref="AccountByUser"/>
        /// </returns>
        Task<IList<AccountByUser>> GetAccountByUserAsync(string username);

        /// <summary>
        ///     Gets a list of instrument symbols given an account number
        /// </summary>
        /// <param name="accountNumber">
        ///     The account number
        /// </param>
        /// <returns>
        ///     A populated list of <see cref="PossitionsByAccount"/>
        /// </returns>
        Task<IList<PossitionsByAccount>> GetPossitionsByAccountAsync(string accountNumber);

        /// <summary>
        ///     Searches for trades given the search criteria
        /// </summary>
        /// <param name="criteria">
        ///     An instance of <see cref="SearchTradesCriteria"/> that represents the search criteria
        /// </param>
        /// <returns>
        ///     A populated list of <see cref="TradeByAccountDto"/>
        /// </returns>
        Task<IList<TradeByAccountDto>> SearchTradesAsync(SearchTradesCriteria criteria);
    }
}
