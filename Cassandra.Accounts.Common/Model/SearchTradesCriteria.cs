using System.Runtime.Serialization;

namespace Cassandra.Accounts.Common.Model
{
    /// <summary>
    ///     Represents the criteria to search for trades
    /// </summary>
    [DataContract]
    public class SearchTradesCriteria
    {
        /// <summary>
        ///     The account number
        /// </summary>
        [DataMember]
        public string? AccountNumber { get; set; }

        /// <summary>
        ///     The flight start date
        /// </summary>
        [DataMember]
        public DateTime? StartDate { get; set; }

        /// <summary>
        ///     The flight end date
        /// </summary>
        [DataMember] 
        public DateTime? EndDate { get; set; }

        /// <summary>
        ///     The type [sell | buy]
        /// </summary>
        [DataMember]
        public string? Type { get; set; }
        
        /// <summary>
        ///     The instrument symbol
        /// </summary>
        [DataMember]
        public string? InstrumentSymbol { get; set; }
    }

    /// <summary>
    ///     Search trades criteria extensions
    /// </summary>
    public static class SearchTradesCriteriaExtensions
    {
        /// <summary>
        ///     Indicates whether or not the query can be performed by the account number
        /// </summary>
        /// <param name="criteria">
        ///     An instance of <see cref="SearchTradesCriteria"/>
        /// </param>
        /// <returns>
        ///     true if the query can be performed by the account number, otherwise false
        /// </returns>
        public static bool CanSearchByAccount(this SearchTradesCriteria criteria)
        {
            return !string.IsNullOrWhiteSpace(criteria.AccountNumber);
        }

        /// <summary>
        ///     Indicates whether or not the query can be performed by the account number and flight dates
        /// </summary>
        /// <param name="criteria">
        ///     An instance of <see cref="SearchTradesCriteria"/>
        /// </param>
        /// <returns>
        ///     true if the query can be performed by account number and flight dates
        /// </returns>
        public static bool CanSearchByAccountAndFlight(this SearchTradesCriteria criteria)
        {
            return !string.IsNullOrWhiteSpace(criteria.AccountNumber) &&
                criteria.StartDate.HasValue &&
                criteria.EndDate.HasValue;
        }

        /// <summary>
        ///     Indicates whether or not the query can be performed by account number, flight dates and/or trade type, instrument symbol
        /// </summary>
        /// <param name="criteria">
        ///     An instance of <see cref="SearchTradesCriteria"/>
        /// </param>
        /// <returns>
        ///     true if the query can be performed by account number, flight dates and/or trade type, instrument symbol
        /// </returns>
        public static bool CanSearchByAccountAndFlightAndOtherCriteria(this SearchTradesCriteria criteria)
        {
            return !string.IsNullOrWhiteSpace(criteria.AccountNumber) &&
                criteria.StartDate.HasValue &&
                criteria.EndDate.HasValue &&
                (!string.IsNullOrWhiteSpace(criteria.Type) || !string.IsNullOrWhiteSpace(criteria.InstrumentSymbol));
        }       
    }
}
