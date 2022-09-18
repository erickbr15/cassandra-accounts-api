namespace Cassandra.Accounts.Common.Model.Cassandra
{
    /// <summary>
    ///     Contract to represent the model for the Cassandra tables:
    ///     trades_by_a_d, trades_by_a_td, trades_by_a_std, trades_by_a_sd
    /// </summary>
    public interface ITradesByAccount
    {
        /// <summary>
        ///     The account number
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        ///     A time UUID which represents the trade date
        /// </summary>
        public TimeUuid TradeDate { get; set; }

        /// <summary>
        ///     The transaction type [sell, buy]
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        ///     The transaction instrument symbol
        /// </summary>
        public string? Symbol { get; set; }

        /// <summary>
        ///     The transaction shares
        /// </summary>
        public int Shares { get; set; }

        /// <summary>
        ///     The transaction price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        ///     The transaction amount
        /// </summary>
        public decimal Amount { get; set; }
    }
}
