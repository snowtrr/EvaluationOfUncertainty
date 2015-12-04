namespace LogNormal
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class CreateGraphicData
    {
        public void Create(double[] numbers, int numberIntervals)
        {
            var max = numbers.Max();
            var min = numbers.Min();

            var interval = (max - min) / numberIntervals;

            var upBorder = min + interval;
            var downBorder = min;

            var result = new List<string>();

            // Идем по X
            for (int i = 1; i <= numberIntervals; i++)
            {
                var j = numbers.Count(number => number <= upBorder && number >= downBorder);

                // Console.WriteLine($"от {DownBorder} до {UpBorder} - {j}");
                result.Add(j.ToString());
                downBorder += interval;
                upBorder += interval;
            }

            File.WriteAllLines(@"E:\1.txt", result.ToArray());
        }
    }
}
