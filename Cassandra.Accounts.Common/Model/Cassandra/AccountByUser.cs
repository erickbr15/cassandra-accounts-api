using System.Runtime.Serialization;

namespace Cassandra.Accounts.Common.Model.Cassandra
{
    /// <summary>
    ///     Data model to represent in memory the Cassandra table accounts_by_user
    /// </summary>
    [DataContract]
    public class AccountByUser
    {
        /// <summary>
        ///     The username
        /// </summary>
        [DataMember]
        public string? Username { get; set; }

        /// <summary>
        ///     The account number
        /// </summary>
        [DataMember]
        public string? AccountNumber { get; set; }

        /// <summary>
        ///     The account cash balance
        /// </summary>
        [DataMember]
        public decimal? CashBalance { get; set; }

        /// <summary>
        ///     The user name
        /// </summary>
        [DataMember]
        public string? Name { get; set; }
    }
}
