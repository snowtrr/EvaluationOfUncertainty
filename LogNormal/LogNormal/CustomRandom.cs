﻿namespace LogNormal
{
    using System;
    using System.Threading;

    /// <summary>
    /// Class for generate random massive
    /// </summary>
    internal class CustomRandom
    {
        #region Constructors

        /// <summary>
        /// Constructor of class
        /// </summary>
        public CustomRandom(int iseed)
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

        public float GenRandNumbCustom()
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

    /// <summary>
    /// Random numbers generated by standart platform generator (.Net)
    /// </summary>
    public static class RandomProvider
    {
        private static int _seed = Environment.TickCount;

        private static readonly ThreadLocal<Random> RandomWrapper = new ThreadLocal<Random>(() =>
            new Random(Interlocked.Increment(ref _seed))
        );

        public static Random GetThreadRandom()
        {
            return RandomWrapper.Value;
        }
    }
}