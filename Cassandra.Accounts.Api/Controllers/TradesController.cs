using Cassandra.Accounts.Common.Model;
using Cassandra.Accounts.Common.Model.Cassandra;
using Cassandra.Accounts.Main.Business;
using Microsoft.AspNetCore.Mvc;

namespace Cassandra.Accounts.Api.Controllers
{
    [Route("cassandraaccounts/[controller]")]
    [ApiController]
    public class TradesController : ControllerBase
    {
        private readonly IAccountService _accountService;

        /// <summary>
        ///     Creates an instance of <see cref="TradesController"/>
        /// </summary>
        /// <param name="accountService">
        ///     An instance of <see cref="IAccountService"/>
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     It is thrown when the <paramref name="accountService"/> is null
        /// </exception>
        public TradesController(IAccountService accountService)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        /// <summary>
        ///     Searches for trades given the search criteria
        /// </summary>
        /// <param name="criteria">
        ///     An instance of <see cref="SearchTradesCriteria"/> which represents the search criteria
        /// </param>
        /// <returns>
        ///     A list of trades
        /// </returns>
        [HttpPost("search", Name = "SearchTrades")]
        public async Task<ActionResult<IEnumerable<TradesByAccount>>> SearchTradesAsync([FromBody] SearchTradesCriteria criteria)
        {
            if (criteria == null)
            {
                return new BadRequestObjectResult($"The search criteria is required.");
            }

            var trades = await _accountService.SearchTradesAsync(criteria);
            
            return Ok(trades);
        }
    }
}
