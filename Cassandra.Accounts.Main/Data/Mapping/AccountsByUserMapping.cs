using Cassandra.Accounts.Common.Model.Cassandra;

namespace Cassandra.Accounts.Main.Data.Mapping
{
    /// <summary>
    ///     Cassandra configuration mapping for the table accounts_by_user
    /// </summary>
    public class AccountsByUserMapping : Cassandra.Mapping.Mappings
    {
        /// <summary>
        ///     Creates an instance of <see cref="AccountsByUserMapping"/> initializing the cassandra data model configuration mapping
        /// </summary>
        public AccountsByUserMapping()
        {
            For<AccountByUser>()
            .TableName("accounts_by_user")
            .PartitionKey(t => t.Username)
            .Column(t => t.Username, column => column.WithName("username"))
            .Column(t => t.AccountNumber, column => column.WithName("account_number"))
            .Column(t => t.CashBalance, column => column.WithName("cash_balance"))
            .Column(t => t.Name, column => column.WithName("name"));
        }
    }
}
