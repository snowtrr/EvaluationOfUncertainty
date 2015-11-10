using System;

namespace LogNormal
{
    /// <summary>
    /// Class for generate random massive
    /// </summary>
    class Random
    {
        #region Fields

        /// <summary>
        /// Field for save
        /// </summary>
        private int _iseed;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructor of class
        /// </summary>
        public Random()
        {
            _iseed = Iseed;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The number needed to generate the next number
        /// </summary>
        public int Iseed { get; set; }

        #endregion Properties

        #region Public methods

        public float GenRandNumb(int curIseed)
        {
            // Initialized data
            const double lowerValue = 4.656612873077392578125e-10;
            const double apperValue = 2147483647;
            const int intValue = 16807;

            // Body of generate
            var z1 = Convert.ToDouble(curIseed);
            var d1 = intValue * z1;
            z1 = d1 % apperValue;
            var retVal = (float)(z1 * lowerValue);
            _iseed = Convert.ToInt32(z1);
            Iseed = _iseed;
            return retVal;
        }

        #endregion Public methods
    }
}