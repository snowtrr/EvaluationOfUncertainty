namespace LogNormal
{
    using System;

    /// <summary>
    /// Log normal distribution
    /// </summary>
    class LogNormal
    {
        #region Public methods

        /// <summary>
        /// Generate massiveOfNormal of log normal distribution
        /// </summary>
        /// <param name="mu">Mu (Считанное значение для добавления погрешности)</param>
        /// <param name="sigma">Sigma</param>
        /// <param name="normalNumber">Normal number (Случайная величин распределенная по нормальному закону)</param>
        /// <returns>Massive of log normal random numbers</returns>
        public double GenLogNormalNumber(double mu, double sigma, double normalNumber)
        {
            var genLogNormal = mu * Math.Exp(0 + sigma/100 * normalNumber);

            return genLogNormal;
        }

        #endregion Public methods
    }
}