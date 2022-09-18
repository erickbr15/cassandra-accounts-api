using Cassandra.Accounts.Common.Model.Transactional;

namespace Cassandra.Accounts.Main.Data
{
    /// <summary>
    ///     Static helper server to create the transactional mocked data
    /// </summary>
    public static class MockDataService
    {
        /// <summary>
        ///     Creates the transactional mocked data for users, accounts, and trades
        /// </summary>
        /// <param name="numberOfUsers">
        ///     Indicates the number of users to create
        /// </param>
        /// <param name="accountsByUser">
        ///     Indicates the number of accounts to create per user
        /// </param>
        /// <param name="tradesbyAccount">
        ///     Indicates the number of trades to create per account
        /// </param>
        /// <returns>
        ///     A list of users and accounts, and a list of trades
        /// </returns>
        public static (IList<User> UsersAndAccounts, IList<Trade> Trades) BuildTransactionalMockData(int numberOfUsers = 10, int accountsByUser = 10, int tradesbyAccount = 10)
        {
            var users = new List<User>(User.FakeData.Generate(numberOfUsers));
            var trades = new List<Trade>();

            foreach (var user in users)
            {
                (user.Accounts as List<Account>)?.AddRange(Account.FakeData.Generate(accountsByUser));
                foreach (var account in user.Accounts)
                {
                    account.Username = user.Username;
                    account.Name = user.Name;

                    var tradesByAccount = new List<Trade>(Trade.FakeData.Generate(tradesbyAccount));
                    tradesByAccount.ForEach(t =>
                    {
                        t.Username = user.Username;
                        t.AccountNumber = account.AccountNumber;
                        t.Amount = t.Shares * t.Price;

                        var index = new Random().Next(0, account.InstrumentSymbols.Count - 1);
                        t.InstrumentSymbol = account.InstrumentSymbols[index];
                    });

                    trades.AddRange(tradesByAccount);

                    var sellAmount = tradesByAccount.Where(t => string.Equals(t.Type, "sell")).Sum(t => t.Amount);
                    var buyAmount = tradesByAccount.Where(t => string.Equals(t.Type, "buy")).Sum(t => t.Amount);

                    var balance = sellAmount - buyAmount;
                    account.CashBalance = balance > 0.00m ? balance : 0.00m;
                }

            }
            return (users, trades);
        }
    }
}
