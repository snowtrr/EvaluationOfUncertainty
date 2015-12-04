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
            var normal = new Normal();
            var m = genCustom ? normal.GenCustomNormal(10000, Environment.TickCount) : normal.GenNormal(10000);

            var mas = new double[m.Count];
            var i = 0;

            foreach (var el in m)
            {
                mas[i] = el;
                i++;
            }

            var res = new CreateGraphicData();

            res.Create(mas, 80);

            return true;
        }
    }
}
