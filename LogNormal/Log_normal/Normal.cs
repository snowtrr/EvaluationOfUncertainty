using System;

namespace Log_normal
{
    /// <summary>
    /// Normal distribution
    /// </summary>
    class Normal
    {
        #region Public methods

        /// <summary>
        /// Generate massive of normal distribution
        /// </summary>
        /// <param name="iseed">Iseed number</param>
        /// <param name="n">N</param>
        /// <returns>Massive of normal random numbers</returns>
        public double[] GenNorm(int iseed, int n)
        {
            // Local variables
            int i;
            var random = new Random();

            // Parameter adjustments
            var massive = new double[n]; 

            // Body of normal
            var nn = n;
            var m = n - (n/2 << 1);

            if (m != 0)
            {
                --nn;
            }

            var i1 = nn;

            for (i = 0; i < i1; i += 2)
            {
                L1:
                var u = random.GenRandNumb(iseed);
                iseed = random.Iseed;
                var v = random.GenRandNumb(iseed);

                u = u + u - 1;
                v = v + v - 1;
                var sum = u * u + v * v;
                if (sum >= 1)
                {
                    goto L1;
                }

                var sln = (float)Math.Log(sum);
                sln = (float)Math.Sqrt(((-sln - sln) / sum));
                massive[i] = u * sln;
                massive[i + 1] = v * sln;
            }

            return massive;
        }

        #endregion Public methods
    }
}