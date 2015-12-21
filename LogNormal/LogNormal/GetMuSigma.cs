namespace LogNormal
{
    using System;

    class GetMuSigma
    {
        private double _resultMu;
        private double _resultSigma;

        public GetMuSigma(double[] numbers)
        {
            // Получаем математическое ожидание
            foreach (var num in numbers)
            {
                _resultMu += num;
            }
            _resultMu = _resultMu / numbers.Length;

            // Получаем среднеквадратичное отклонение
            foreach (var num in numbers)
            {
                _resultSigma += (num - _resultMu) * (num - _resultMu);
            }

            _resultSigma = Math.Sqrt(_resultSigma / numbers.Length);
            _resultSigma = (_resultSigma / _resultMu) * 100;

            ResultMu = _resultMu;
            ResultSigma = _resultSigma;
        }

        public double ResultMu { get; private set; }
        public double ResultSigma { get; private set; }
    }
}
