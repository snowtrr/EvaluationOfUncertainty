using System;
using System.Runtime.Remoting.Proxies;

namespace LogNormal
{
    /// <summary>
    /// Class for generate random massive
    /// </summary>
    class Random
    {
        #region Constructors

        /// <summary>
        /// Constructor of class
        /// </summary>
        public Random(int iseed)
        {
            Iseed = iseed;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The number needed to generate the next number
        /// </summary>
        public int Iseed { get; private set; }

        #endregion Properties

        #region Public methods

        public float GenRandNumb()
        {
            // Initialized data
            const double lowerValue = 4.656612873077392578125e-10;
            const double apperValue = 2147483647;
            const Int16 intValue = 16807;

            // Body of generate
            var z1 = Convert.ToDouble(Iseed);
            var d1 = intValue * z1;
            z1 = d1 % apperValue;
            var retVal = (float)(z1 * lowerValue);
            Iseed = Convert.ToInt32(z1);

            return retVal;
        }

        #endregion Public methods
    }
}