using Cassandra.Accounts.Common.Model.Cassandra;
using Cassandra.Accounts.Main.Business;
using Microsoft.AspNetCore.Mvc;

namespace Cassandra.Accounts.Api.Controllers
{
    [Route("cassandraaccounts/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        /// <summary>
        ///     Creates an instance of <see cref="AccountsController"/>
        /// </summary>
        /// <param name="accountService">
        ///     An instance of <see cref="IAccountService"/>
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     This exception is thrown when <paramref name="accountService"/> is null
        /// </exception>
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        /// <summary>
        ///     Gets the accounts for a given username
        /// </summary>
        /// <param name="username">
        ///     The username
        /// </param>
        /// <returns>
        ///     A list of populated <see cref="AccountByUser"/> which represents the accounts for the given username
        /// </returns>
        [HttpGet("{username}", Name = "GetAccountsByUser")]
        public async Task<ActionResult<IEnumerable<AccountByUser>>> GetAccountsByUserAsync([FromRoute] string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return new NotFoundResult();
            }

            var accounts = await _accountService.GetAccountByUserAsync(username);

            return Ok(accounts);
        }
    }
}
