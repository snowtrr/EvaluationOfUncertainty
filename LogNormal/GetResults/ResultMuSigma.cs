namespace GetResults
{
    using System;

    internal class ResultMuSigma
    {
        private double _resultMu;
        private double _resultSigma;

        public ResultMuSigma(double[] numbers)
        {
            // Получаем математическое ожидание
            foreach (var num in numbers)
            {
                _resultMu += num;
            }
            _resultMu = _resultMu/numbers.Length;

            // Получаем среднеквадратичное отклонение
            foreach (var num in numbers)
            {
                _resultSigma += (num - _resultMu)*(num - _resultMu);
            }

            _resultSigma = Math.Sqrt(_resultSigma / numbers.Length);

            ResultMu = _resultMu;
            ResultSigma = _resultSigma;
        }

        public double ResultMu { get; private set; }
        public double ResultSigma { get; private set; }
    }
}
