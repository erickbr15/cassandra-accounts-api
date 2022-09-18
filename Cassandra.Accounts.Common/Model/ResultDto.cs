using System.Runtime.Serialization;

namespace Cassandra.Accounts.Common.Model
{
    /// <summary>
    ///     Data transfer object to carry out an operation result
    /// </summary>
    [DataContract]
    public class ResultDto
    {
        /// <summary>
        ///     A string that represents the operation result text
        /// </summary>
        [DataMember]
        public string? Result { get; set; }
    }
}
