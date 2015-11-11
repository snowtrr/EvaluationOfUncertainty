using System;
using System.Collections.Generic;

namespace LogNormal
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
        /// <param name="n">N</param>
        /// <param name="iseed">Iseed number</param>
        /// <returns>Massive of normal random numbers</returns>
        public List<double> GenNormal(int n, int iseed = 2147483646)
        {
            // Save primal number to create output list
            var curN = n;
            if (n%2 != 0)
            {
                n++;
            }

            // Local variables
            int i;
            var random = new Random(iseed);

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
                var u = random.GenRandNumb();
                // iseed = random.Iseed;
                var v = random.GenRandNumb();

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

            var massNormaList = new List<double>();
            for (var j = 0; j < curN; j++)
            {
                massNormaList.Add(massive[j]);
            }

            return massNormaList;
        }

        #endregion Public methods
    }
}