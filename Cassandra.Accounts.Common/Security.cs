using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Cassandra.Accounts.Common
{
    /// <summary>
    ///     Security helper
    /// </summary>
    public static class Security
    {
        /// <summary>
        ///     Validates the server certificate
        /// </summary>        
        /// <returns>
        ///     true if there is no SSL policy errors, otherwise false
        /// </returns>
        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                return true;
            }
            return false;
        }
    }
}
