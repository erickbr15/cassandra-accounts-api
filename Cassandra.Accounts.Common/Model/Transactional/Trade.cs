using Bogus;

namespace Cassandra.Accounts.Common.Model.Transactional
{
    /// <summary>
    ///     Represents a trade
    /// </summary>
    public class Trade
    {
        /// <summary>
        ///     The number of shares for the trade
        /// </summary>
        public int Shares { get; set; }

        /// <summary>
        ///     The price share for the trade
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        ///     The trade amount
        /// </summary>
        public decimal Amount { get; set; }
        
        /// <summary>
        ///     The trade date
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        ///     Trade type [sell | buy]
        /// </summary>
        public string? Type { get; set; }
        
        /// <summary>
        ///     The username that performs the trade
        /// </summary>
        public string? Username { get; set; }
        
        /// <summary>
        ///     The trade target account number
        /// </summary>
        public string? AccountNumber { get; set; }

        /// <summary>
        ///     The used instrument symbol
        /// </summary>
        public string? InstrumentSymbol { get; set; }

        /// <summary>
        ///     Gets an instance of <see cref="Faker{Trade}"/> that creates an instance of <see cref="Trade"/> with mocked data
        /// </summary>
        public static Faker<Trade> FakeData { get; } = new Faker<Trade>()
            .RuleFor(i => i.Shares, f => f.Random.Int(10, 5000))
            .RuleFor(i => i.Price, f => f.Finance.Amount(50.00m, 500.00m, 2))
            .RuleFor(i => i.Date, f => f.Date.Between(DateTime.Now.AddYears(-1), DateTime.Now))
            .RuleFor(i => i.Type, f => f.PickRandom(Types.TradeTypes));
    }
}
