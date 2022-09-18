using System.Runtime.Serialization;

namespace Cassandra.Accounts.Common.Model.Cassandra
{
    /// <summary>
    ///     Data model to represent in memory the Cassandra table possitions_by_account
    /// </summary>
    [DataContract]
    public class PossitionsByAccount
    {
        /// <summary>
        ///     The account number
        /// </summary>
        [DataMember]
        public string? Account { get; set; }

        /// <summary>
        ///     The instrument symbol
        /// </summary>
        [DataMember]
        public string? Symbol { get; set; }

        /// <summary>
        ///     The quantity
        /// </summary>
        [DataMember]
        public int Quantity { get; set; }
    }
}
