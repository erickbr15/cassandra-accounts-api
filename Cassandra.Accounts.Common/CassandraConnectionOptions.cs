namespace Cassandra.Accounts.Common
{
    /// <summary>
    ///     Cassandra cluster configurations
    /// </summary>
    public class CassandraConnectionOptions
    {        
        /// <summary>
        ///     Username to connect to the cluster
        /// </summary>
        public string Username { get; private set; }
        
        /// <summary>
        ///     Password to connect to the cluster
        /// </summary>
        public string Password { get; private set; }
        
        /// <summary>
        ///     Cluster contact point
        /// </summary>
        public string CassandraContactPoint { get; private set; }
        
        /// <summary>
        ///     Cluster connection port
        /// </summary>
        public int CassandraPort { get; private set; }
        
        /// <summary>
        ///     Accounts keyspace
        /// </summary>
        public static string Keyspace { get; set; } = "accounts";

        /// <summary>
        ///     Creates an instance of <see cref="CassandraConnectionOptions"/> and initialize the connection properties
        /// </summary>
        public CassandraConnectionOptions()
        {
            Username = "cassandra-investmentdb";
            Password = "your-password";
            CassandraContactPoint = "your-cassandra-contact-point";
            CassandraPort = 10350;
        }
    }
}
