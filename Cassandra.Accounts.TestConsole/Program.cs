using Cassandra.Accounts.Main.Business;
using Cassandra.Accounts.Main.Data;
using Cassandra.Accounts.Main.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Cassandra.Accounts.SchemaSetup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // setup DI                                    
            var serviceProvider = new ServiceCollection()                
                .AddTransient<IAccountService, AccountService>()
                .AddScoped<IAccountCassandraDataService, AccountCassandraDataService>()
                .AddAutoMapper(
                    typeof(AccountByUserMapper),
                    typeof(TradesByAccountMapper),
                    typeof(TradesByAccountQ3Mapper),
                    typeof(TradesByAccountQ4Mapper),
                    typeof(TradesByAccountQ5Mapper))
                .BuildServiceProvider();

            Cassandra.Mapping.MappingConfiguration.Global.Define<Cassandra.Accounts.Main.Data.Mapping.AccountsByUserMapping>();
            Cassandra.Mapping.MappingConfiguration.Global.Define<Cassandra.Accounts.Main.Data.Mapping.PossitionsByAccountMapping>();
            Cassandra.Mapping.MappingConfiguration.Global.Define<Cassandra.Accounts.Main.Data.Mapping.TradesByAccountMapping>();
            Cassandra.Mapping.MappingConfiguration.Global.Define<Cassandra.Accounts.Main.Data.Mapping.TradesByAccountQ3Mapping>();
            Cassandra.Mapping.MappingConfiguration.Global.Define<Cassandra.Accounts.Main.Data.Mapping.TradesByAccountQ4Mapping>();
            Cassandra.Mapping.MappingConfiguration.Global.Define<Cassandra.Accounts.Main.Data.Mapping.TradesByAccountQ5Mapping>();

            var accountService = serviceProvider.GetService<IAccountService>();

            if (accountService == null)
            {
                return;
            }

            //Keyspace generation
            var resultKeyspaceGeneration = accountService.GenerateKeyspaceAsync().WaitAsync(default(CancellationToken)).Result;            
            Console.WriteLine(resultKeyspaceGeneration == null ? string.Empty : resultKeyspaceGeneration.Result);

            //Schema generation
            var resultSchemaGeneration = accountService.GenerateSchemaAsync().WaitAsync(default(CancellationToken)).Result;
            Console.WriteLine(resultSchemaGeneration == null ? string.Empty : resultSchemaGeneration.Result);

            //Data generation
            var resultDataGeneration = accountService.GenerateDataAsync().WaitAsync(default(CancellationToken)).Result;
            Console.WriteLine(resultDataGeneration == null ? string.Empty : resultDataGeneration.Result);
        }
    }
}