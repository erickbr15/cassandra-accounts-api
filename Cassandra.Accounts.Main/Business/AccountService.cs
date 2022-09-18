using AutoMapper;
using Cassandra.Accounts.Common.Model;
using Cassandra.Accounts.Common.Model.Cassandra;
using Cassandra.Accounts.Main.Data;
using Cassandra.Accounts.Main.Mappers;

namespace Cassandra.Accounts.Main.Business
{
    /// <summary>
    ///     Concrete implementation of <see cref="IAccountService"/>
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly IAccountCassandraDataService _dataService;
        private readonly IMapper _mapper;

        /// <summary>
        ///     Creates an instance of <see cref="AccountService"/>
        /// </summary>
        /// <param name="dataService">
        ///     An instance of <see cref="IAccountCassandraDataService"/>
        /// </param>
        /// <param name="mapper">
        ///     An instance of <see cref="IMapper"/>
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     It is thrown when one of the params is null
        /// </exception>
        public AccountService(IAccountCassandraDataService dataService, IMapper mapper)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <inheritdoc />
        public Task<ResultDto> GenerateDataAsync()
        {
            var data = MockDataService.BuildTransactionalMockData();

            var accountByUsers = data.UsersAndAccounts.SelectMany(u => u.Accounts).Select(_mapper.Map<AccountByUser>).ToList();
            var possitionByAccounts = (new PositionsByAccountMapper()).Map(data.Trades);
            var tradesByAccount = data.Trades.Select(_mapper.Map<TradesByAccount>).ToList();
            var tradesByAccountQ3 = data.Trades.Select(_mapper.Map<TradesByAccountQ3>).ToList();
            var tradesByAccountQ4 = data.Trades.Select(_mapper.Map<TradesByAccountQ4>).ToList();
            var tradesByAccountQ5 = data.Trades.Select(_mapper.Map<TradesByAccountQ5>).ToList();

            Task.WaitAll(
                _dataService.InsertAccountByUsersAsync(accountByUsers),
                _dataService.InsertPossitionsByAccountAsync(possitionByAccounts),
                _dataService.InsertTradesByAccountAsync(tradesByAccount),
                _dataService.InsertTradesByAccountAsync(tradesByAccountQ3),
                _dataService.InsertTradesByAccountAsync(tradesByAccountQ4),
                _dataService.InsertTradesByAccountAsync(tradesByAccountQ5));

            return Task.FromResult<ResultDto>(new ResultDto { Result = "Data generated. Users: 10. Accounts by user: 10. Trades by account: 10"});
        }

        /// <inheritdoc />
        public async Task<ResultDto> GenerateKeyspaceAsync()
        {
            await _dataService.DeleteKeySpaceIfExistsAsync();
            
            var keyspaceMetadata = await _dataService.CreateKeySpaceAsync();

            return new ResultDto
            {
                Result = keyspaceMetadata
            };
        }

        /// <inheritdoc />
        public async Task<ResultDto> GenerateSchemaAsync()
        {
            var tablesMetadata = await _dataService.CreateSchemaAsync();
            
            return new ResultDto
            {
                Result = tablesMetadata
            };
        }

        /// <inheritdoc />
        public async Task<IList<AccountByUser>> GetAccountByUserAsync(string username)
        {
            var accountsByUser = await _dataService.GetAccountsByUserAsync(username);
            return accountsByUser;
        }

        /// <inheritdoc />
        public async Task<IList<PossitionsByAccount>> GetPossitionsByAccountAsync(string accountNumber)
        {
            var possitionsByAccount = await _dataService.GetPossitionsByAccountAsync(accountNumber);
            return possitionsByAccount;
        }

        /// <inheritdoc />
        public async Task<IList<TradeByAccountDto>> SearchTradesAsync(SearchTradesCriteria criteria)
        {
            if(criteria == null)
            {
                return new List<TradeByAccountDto>();
            }

            var tradeEntities = await _dataService.SearchTradesAsync(criteria);
            
            var tradesByAccount = tradeEntities.Select(_mapper.Map<TradeByAccountDto>).ToList();

            return tradesByAccount;
        }
    }
}
