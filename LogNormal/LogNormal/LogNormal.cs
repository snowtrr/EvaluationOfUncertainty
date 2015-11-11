using System;
using System.Collections.Generic;

namespace LogNormal
{
    /// <summary>
    /// Log normal distribution
    /// </summary>
    class LogNormal
    {
        #region Public methods

        /// <summary>
        /// Generate massiveOfNormal of log normal distribution
        /// </summary>
        /// <param name="mu">Mu</param>
        /// <param name="sigma">Sigma</param>
        /// <param name="numberOfElem">Number of elements to generate</param>
        /// <returns>Massive of log normal random numbers</returns>
        public List<double> GenLogNormal(double mu, double sigma, int numberOfElem)
        {
            var normal = new Normal();
            var logNormalMassive = normal.GenNormal(numberOfElem);

            var n = numberOfElem;
            var massLogNormaList = new List<double>();

            for (var i = 0; i < n; i++)
            {
                massLogNormaList.Add(Math.Exp(mu + sigma * logNormalMassive[i]));
            }

            return massLogNormaList;
        }

        #endregion Public methods
    }
}