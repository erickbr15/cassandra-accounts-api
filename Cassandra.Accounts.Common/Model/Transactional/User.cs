using Bogus;

namespace Cassandra.Accounts.Common.Model.Transactional
{
    /// <summary>
    ///     Represents a user
    /// </summary>
    public class User
    {
        /// <summary>
        ///     The username
        /// </summary>
        public string? Username { get; set; }
        
        /// <summary>
        ///     The name
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        ///     A list of accounts
        /// </summary>
        public IList<Account> Accounts { get; set; } = new List<Account>();       

        /// <summary>
        ///     Gets an instance of <see cref="Faker{User}"/> that allows to create an instance of <see cref="User"/> with mocked data
        /// </summary>
        public static Faker<User> FakeData { get; } = new Faker<User>()
            .RuleFor(u => u.Username, f => f.Person.UserName)
            .RuleFor(u => u.Name, f => f.Person.FullName);
    }
}
