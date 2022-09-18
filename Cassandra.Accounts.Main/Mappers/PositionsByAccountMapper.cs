using Cassandra.Accounts.Common.Model.Cassandra;
using Cassandra.Accounts.Common.Model.Transactional;

namespace Cassandra.Accounts.Main.Mappers
{
    /// <summary>
    ///     Helper class to map the trades to possitions by account
    /// </summary>
    public sealed class PositionsByAccountMapper
    {        
        /// <summary>
        ///     Maps a list of trades to a list of possitions by account
        /// </summary>
        /// <param name="trades">
        ///     A populated list of <see cref="Trade"/>
        /// </param>
        /// <returns>
        ///     A populated list of <see cref="PossitionsByAccount"/>
        /// </returns>
        public IList<PossitionsByAccount> Map(IList<Trade> trades)
        {
            if(trades == null)
            {
                return new List<PossitionsByAccount>();
            }

            var possitionsByAccount = new List<PossitionsByAccount>();

            foreach (var groupsByAccount in trades.GroupBy(t=> t.AccountNumber))
            {
                foreach (var groupsByInstrument in groupsByAccount.GroupBy(t=> t.InstrumentSymbol))
                {
                    possitionsByAccount.Add(new PossitionsByAccount
                    {
                        Account = groupsByAccount.Key,
                        Symbol = groupsByInstrument.Key,
                        Quantity = groupsByInstrument.Count()
                    });
                }
            }

            return possitionsByAccount;
        }
    }
}
