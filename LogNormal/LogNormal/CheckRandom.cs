using System;

namespace Log_normal
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
            var random = new Random {Iseed = 2147483646};

            Console.WriteLine(random.Iseed);
            int underGraph = 0;

            for (int i = 0; i < 100000; i++)
            {
                double randNumberX = random.GenRandNumb(random.Iseed);
                double randNumberY = random.GenRandNumb(random.Iseed);

                //// Console.WriteLine(Random.GenRandNumb(Random.Iseed));
                underGraph = Y(randNumberX) > randNumberY ? underGraph + 1 : underGraph;
            }
            return Convert.ToDouble((double)underGraph/100000);
        }

        /// <summary>
        /// Function Y(X) = X*X for check
        /// </summary>
        /// <param name="x">X</param>
        /// <returns>X*X</returns>
        public double Y(double x)
        {
            return x*x;
        }
    }

    #endregion Public method
}