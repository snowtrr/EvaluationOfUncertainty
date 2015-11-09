using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Log_normal
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Normal.N = 4;
            Normal.GenNorm(1, 2);

            //Normal.GenNorm(Random.Iseed, 1, f);
            Console.WriteLine(Normal.Mass[1]);*/

            //// Console.WriteLine(CheckRandom.Integral());

            /*Random.Iseed = 2;
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(Random.GenRandNumb(Random.Iseed));
            }*/

            /*Console.WriteLine(Normal.GenNorm(67709809, 2)[0]);
            Console.WriteLine(LogNormal.GeneralNormal(3, 0.11, Normal.GenNorm(67709809, 2))[1]);*/

            CultureInfo ci = new CultureInfo("en-US");
            List<string> listMaterial = new List<string>();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please, enter path to cell folder ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            string pathFCell = Console.ReadLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please, enter quantity of material: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            string quanMaterial = Console.ReadLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please, enter sigma: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            string sigma = Console.ReadLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter number of material: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            int j = 0;
            while (j != Convert.ToInt32(quanMaterial))
            {
                listMaterial.Add(Console.ReadLine());
                j++;
            }
            Console.ResetColor();

            //// Get items contained .dat
            var dir = new DirectoryInfo(pathFCell);
            var allFileList = dir.GetFiles().Select(file => file.FullName).ToList();

            var cellFList = allFileList.Where(cell => cell.Contains(".dat")).ToList();

            int numberRandom = (from pathCell in cellFList from str in File.ReadAllLines(pathCell, Encoding.Default) from material in listMaterial where str.Contains(" multiplier bin:") && str.Contains(material) select str).Count();

            var normal = new Normal();

            //// Generate Normal Massive
            var normalMassive = normal.GenNorm(67709809, numberRandom);

            /*string outputPath = pathCell + "_new";
            string[] readText = File.ReadAllLines(pathCell, Encoding.Default);

            //// Reed amount of Massive for generate Random Massive
            int numberRandom = listMaterial.Sum(material => readText.Count(str => str.Contains(" multiplier bin:") && str.Contains(material)));

            //// Generate Normal Massive
            var normalMassive = Normal.GenNorm(67709809, numberRandom);*/

            int k = 0;
            foreach (var pathCell in cellFList)
            {
                string outputPath = pathCell;
                outputPath = outputPath.Remove(outputPath.Length - 4);
                string[] readText = File.ReadAllLines(pathCell, Encoding.Default);

                foreach (var material in listMaterial)
                {
                    int i = 0;
                    foreach (var str in readText)
                    {
                        if (str.Contains(" multiplier bin:") && str.Contains(material))
                        {
                            //// Console.WriteLine((str.Remove(0, 19)).Remove(11));
                            double value = Convert.ToDouble((readText[i + 1].Trim()).Remove(11), ci);
                            //// Console.WriteLine((readText[i+1].Trim()).Remove(11));
                            value = Math.Exp(value + Convert.ToDouble(sigma, ci)*normalMassive[k]);
                            //// Console.WriteLine((readText[i + 1].Trim()).Remove(0, 11));
                            readText[i + 1] = "\t\t\t\t " + value.ToString("#.00000E+00", ci) + " " +
                                              (readText[i + 1].Trim()).Remove(0, 11);
                            ////   Console.WriteLine(readText[i]);
                            k++;
                        }
                        i++;
                    }
                }
                File.WriteAllLines(outputPath + "_lnorm.dat", readText, Encoding.UTF8);
            }
        }
    }
}
