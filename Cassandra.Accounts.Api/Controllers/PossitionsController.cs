using Cassandra.Accounts.Common.Model.Cassandra;
using Cassandra.Accounts.Main.Business;
using Microsoft.AspNetCore.Mvc;

namespace Cassandra.Accounts.Api.Controllers
{
    [Route("cassandraaccounts/[controller]")]
    [ApiController]
    public class PossitionsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        /// <summary>
        ///     Creates an instance of <see cref="PossitionsController"/>
        /// </summary>
        /// <param name="accountService">
        ///     An instance of <see cref="IAccountService"/>
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     It is thrown when the <paramref name="accountService"/> is null
        /// </exception>
        public PossitionsController(IAccountService accountService)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        /// <summary>
        ///     Gets the instrument symbols for an account number
        /// </summary>
        /// <param name="accountNumber">
        ///     The account number
        /// </param>
        /// <returns>
        ///     The instrument symbols for the account number
        /// </returns>
        [HttpGet("{accountNumber}", Name = "GetPossitionsByAccount")]
        public async Task<ActionResult<IEnumerable<AccountByUser>>> GetPossitionsByAccountAsync([FromRoute]string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                return new NotFoundResult();
            }

            var possitions = await _accountService.GetPossitionsByAccountAsync(accountNumber);

            return Ok(possitions);
        }
    }
}
