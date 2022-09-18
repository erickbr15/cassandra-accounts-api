using System.Runtime.Serialization;

namespace Cassandra.Accounts.Common.Model.Cassandra
{
    /// <summary>
    ///     Data transfer object to represent the results of querying the cassandra tables:
    ///     trades_by_a_d, trades_by_a_td, trades_by_a_std, trades_by_a_sd
    /// </summary>
    [DataContract]
    public class TradeByAccountDto
    {
        /// <summary>
        ///     The account number
        /// </summary>
        [DataMember]
        public string? Account { get; set; }

        /// <summary>
        ///     A time UUID which represents the trade date
        /// </summary>
        [DataMember]
        public DateTime TradeDate { get; set; }

        /// <summary>
        ///     The transaction type [sell, buy]
        /// </summary>
        [DataMember]
        public string? Type { get; set; }

        /// <summary>
        ///     The transaction instrument symbol
        /// </summary>
        [DataMember]
        public string? Symbol { get; set; }

        /// <summary>
        ///     The transaction shares
        /// </summary>
        [DataMember]
        public int Shares { get; set; }

        /// <summary>
        ///     The transaction price
        /// </summary>
        [DataMember]
        public decimal Price { get; set; }

        /// <summary>
        ///     The transaction amount
        /// </summary>
        [DataMember]
        public decimal Amount { get; set; }
    }
}
