using System.Collections.Generic;
using System.Linq;

namespace LogNormal
{
    using System;

    internal class CheckAndGraph
    {
        public double IntegralCheck()
        {
            var checkRandom = new CheckRandom();

            return checkRandom.Integral();
        }

        public bool Graph(bool genCustom = true)
        {
            var logN = new LogNormal();
            var normal = new Normal();
            var m = genCustom ? normal.GenCustomNormal(1000000, Environment.TickCount) : normal.GenNormal(10000);

            var mas = new double[m.Count];
            var i = 0;
            var list = new List<double>();

            foreach (var el in m)
            {
                list.Add(el);
                mas[i] = logN.GenLogNormalNumber(1, 10, el);
                i++;
            }

            var res = new CreateGraphicData();

            res.Create(mas, 80);
            
            var gg = new GetMuSigma(list.ToArray());
            Console.WriteLine(gg.ResultMu + "\n" + gg.ResultSigma);
            Console.WriteLine(list.Min());
            Console.ReadLine();

            return true;
        }
    }
}
