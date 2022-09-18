using Bogus;

namespace Cassandra.Accounts.Common.Model.Transactional
{
    /// <summary>
    ///     Represents an account
    /// </summary>
    public class Account
    {
        /// <summary>
        ///     The account number
        /// </summary>
        public string? AccountNumber { get; set; }
        
        /// <summary>
        ///     The instrument symbols
        /// </summary>
        public IList<string> InstrumentSymbols { get; set; } = new List<string>();
        
        /// <summary>
        ///     The cash balance
        /// </summary>
        public decimal CashBalance { get; set; }
        
        /// <summary>
        ///     The username
        /// </summary>
        public string? Username { get; set; }
        
        /// <summary>
        ///     The user name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        ///     Gets an instance of <see cref="Faker{Account}"/> to generate an instance of <see cref="Account"/> with mocked data
        /// </summary>
        public static Faker<Account> FakeData { get; } = new Faker<Account>()
            .RuleFor(u => u.AccountNumber, f => Guid.NewGuid().ToString())
            .RuleFor(u => u.InstrumentSymbols, f => Enumerable.Range(1, f.Random.Int(1, Types.InstrumentSymbols.Length - 1))
            .Select(x => f.PickRandom(Types.InstrumentSymbols)).ToList());
    }
}
