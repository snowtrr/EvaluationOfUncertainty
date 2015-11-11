using System;

namespace LogNormal
{
    /// <summary>
    /// Class for check generated data by calculation integral
    /// </summary>
    class CheckRandom
    {
        #region Public method

        /// <summary>
        /// Approximate calculation of the integral
        /// </summary>
        /// <returns></returns>
        public double Integral()
        {
            var random = new Random(2147483646);

            var underGraph = 0;

            for (var i = 0; i < 1000000; i++)
            {
                var randNumberX = random.GenRandNumb();
                var randNumberY = random.GenRandNumb();

                underGraph = Y(randNumberX) > randNumberY ? underGraph + 1 : underGraph;
            }
            return Convert.ToDouble((double)underGraph/1000000);
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