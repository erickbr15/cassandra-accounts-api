namespace Cassandra.Accounts.Common.Model.Transactional
{
    /// <summary>
    ///     Exposes generic common types
    /// </summary>
    public static class Types
    {
        /// <summary>
        ///     List of instrument symbols
        /// </summary>
        public static string[] InstrumentSymbols = new string[] {
             "ETSY", "PINS", "SE", "SHOP", "SQ", "MELI", "ISRG", "DIS", "BRK.A", "AMZN",
            "VOO", "VEA", "VGT", "VIG", "MBB", "QQQ", "SPY", "BSV", "BND", "MUB",
            "VSMPX", "VFIAX", "FXAIX", "VTSAX", "SPAXX", "VMFXX", "FDRXX", "FGXX"
        };

        /// <summary>
        ///     List of trade types
        /// </summary>
        public static string[] TradeTypes = new string[] { "sell", "buy" };
    }
}
