using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace GetResults
{
    public class CreateGraphicData
    {
        public void Create(double[] numbers, int numberIntervals)
        {
            var max = numbers.Max();
            var min = numbers.Min();

            var interval = (max - min) / numberIntervals;

            var UpBorder = min + interval;
            var DownBorder = min;

            var result = new List<string>();

            // Идем по X
            for (int i = 1; i <= numberIntervals; i++)
            {
                var j = 0;
                foreach (var number in numbers)
                {
                    if (number <= UpBorder && number >= DownBorder)
                    {
                        j++;
                    }
                }

                // Console.WriteLine($"от {DownBorder} до {UpBorder} - {j}");
                result.Add(j.ToString());
                DownBorder += interval;
                UpBorder += interval;
            }

            File.WriteAllLines(@"C:\Users\Alexandr\Desktop\1.txt", result.ToArray());
        }
    }
}