using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogNormal
{
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
