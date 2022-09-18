using Cassandra.Accounts.Main.Business;
using Cassandra.Accounts.Main.Data;
using Cassandra.Accounts.Main.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#if DEBUG
builder.Services.AddSwaggerGen();
#else
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("cassandraaccounts", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "cassandraaccounts",
        Version = "v1"
    });
    config.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});
#endif

builder.Services.AddAutoMapper(
    typeof(AccountByUserMapper),
    typeof(TradesByAccountMapper),
    typeof(TradesByAccountQ3Mapper),
    typeof(TradesByAccountQ4Mapper),
    typeof(TradesByAccountQ5Mapper));

builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountCassandraDataService, AccountCassandraDataService>();

Cassandra.Mapping.MappingConfiguration.Global.Define<Cassandra.Accounts.Main.Data.Mapping.AccountsByUserMapping>();
Cassandra.Mapping.MappingConfiguration.Global.Define<Cassandra.Accounts.Main.Data.Mapping.PossitionsByAccountMapping>();
Cassandra.Mapping.MappingConfiguration.Global.Define<Cassandra.Accounts.Main.Data.Mapping.TradesByAccountMapping>();
Cassandra.Mapping.MappingConfiguration.Global.Define<Cassandra.Accounts.Main.Data.Mapping.TradesByAccountQ3Mapping>();
Cassandra.Mapping.MappingConfiguration.Global.Define<Cassandra.Accounts.Main.Data.Mapping.TradesByAccountQ4Mapping>();
Cassandra.Mapping.MappingConfiguration.Global.Define<Cassandra.Accounts.Main.Data.Mapping.TradesByAccountQ5Mapping>();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseSwagger();

#if DEBUG
app.UseSwaggerUI();
#else
app.UseSwaggerUI(c => 
{
    c.SwaggerEndpoint("../swagger.json", "Cassandra Accounts API v1");
});
#endif

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
