using System;

namespace LogNormal
{
    /// <summary>
    /// Log normal distribution
    /// </summary>
    class LogNormal
    {
        #region Public methods

        /// <summary>
        /// Generate massive of log normal distribution
        /// </summary>
        /// <param name="mu">Mu</param>
        /// <param name="sigma">Sigma</param>
        /// <param name="massive">Massive</param>
        /// <returns>Massive of log normal random numbers</returns>
        public double[] GeneralNormal(double mu, double sigma, double[] massive)
        {
            var n = massive.Length;
            var logNormal = new double[n];

            for (var i = 0; i < n; i++)
            {
                logNormal[i] = Math.Exp(mu + sigma * massive[i]);
            }
            return logNormal;
        }

        #endregion Public methods
    }
}