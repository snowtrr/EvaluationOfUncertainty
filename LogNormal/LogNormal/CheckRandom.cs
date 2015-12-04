namespace LogNormal
{
    using System;

    /// <summary>
    /// Class for check generated data by calculation integral
    /// </summary>
    internal class CheckRandom
    {
        #region Public method

        /// <summary>
        /// Approximate calculation of the integral
        /// </summary>
        /// <returns></returns>
        public double Integral()
        {
            var random = new CustomRandom(Environment.TickCount);

            var underGraph = 0;
            const int accuracy = 10000;

            for (var i = 0; i < accuracy; i++)
            {
                var randNumberX = random.GenRandNumbCustom();
                var randNumberY = random.GenRandNumbCustom();

                underGraph = Y(randNumberX) > randNumberY ? underGraph + 1 : underGraph;
            }
            return Convert.ToDouble((double)underGraph/accuracy);
        }

        /// <summary>
        /// Approximate calculation of the integral
        /// </summary>
        /// <returns></returns>
        public double IntegralDotNet()
        {
            var underGraph = 0;
            const int accuracy = 10000000;

            for (var i = 0; i < accuracy; i++)
            {
                var randNumberX = RandomProvider.GetThreadRandom().NextDouble();
                var randNumberY = RandomProvider.GetThreadRandom().NextDouble();

                underGraph = Y(randNumberX) > randNumberY ? underGraph + 1 : underGraph;
            }
            return Convert.ToDouble((double)underGraph / accuracy);
        }

        #endregion Public method

        #region Private method

        /// <summary>
        /// Function Y(X) = X*X for check
        /// </summary>
        /// <param name="x">X</param>
        /// <returns>X*X</returns>
        private double Y(double x)
        {
            return x*x;
        }

        #endregion Private method
    }
}