using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace LogNormal
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Checker

            // var checkRandom = new CheckRandom();
            // Console.WriteLine(checkRandom.Integral());
            // Console.ReadLine();

            #endregion Checker

            //var normal = new Normal();
            //var m = normal.GenNormal(1000);

            //string[] mas = new string[m.Count];
            //var i = 0;
            //foreach (var el in m)
            //{
            //    mas[i] = el.ToString();
            //    i++;
            //}

            //File.WriteAllLines(@"D:\a", mas);

            #region Calc

            CultureInfo ci = new CultureInfo("en-US");
            List<string> listMaterial = new List<string>();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please, enter number of folder ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            var numberOfFolder = int.Parse(Console.ReadLine());
            Console.ResetColor();

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

            int numberRandom = (from pathCell in cellFList from str in File.ReadAllLines(pathCell, Encoding.Default) from material in listMaterial where str.Contains(" multiplier bin:") && material.Split(' ').All(word => str.Contains(word)) select str).Count();

            var normal = new Normal();
            var logNormal = new LogNormal();;

            //// Generate Normal Massive
            var normalMassive = normal.GenNormal(numberRandom * numberOfFolder);

            /*string outputPath = pathCell + "_new";
            string[] readText = File.ReadAllLines(pathCell, Encoding.Default);

            //// Reed amount of Massive for generate Random Massive
            int numberRandom = listMaterial.Sum(material => readText.Count(str => str.Contains(" multiplier bin:") && str.Contains(material)));

            //// Generate Normal Massive
            var normalMassive = Normal.GenNorm(67709809, numberRandom);*/

            int k = 0;
            for (int l = 0; l < numberOfFolder; l++)
            {
                Directory.CreateDirectory(Path.Combine(dir.FullName, l.ToString()));

                foreach (var pathCell in cellFList)
                {
                    var file = new FileInfo(pathCell);
                    var outputPath = Path.Combine(dir.FullName, l.ToString(), file.Name);
                    
                    outputPath = outputPath.Remove(outputPath.Length - 4);
                    string[] readText = File.ReadAllLines(pathCell, Encoding.Default);

                    foreach (var material in listMaterial)
                    {
                        int i = 0;
                        foreach (var str in readText)
                        {
                            if (str.Contains(" multiplier bin:") && material.Split(' ').All(word => str.Contains(word)))
                            {
                                //// Console.WriteLine((str.Remove(0, 19)).Remove(11));
                                double value = Convert.ToDouble((readText[i + 1].Trim()).Remove(11), ci);
                                //// Console.WriteLine((readText[i+1].Trim()).Remove(11));
                                value = logNormal.GenLogNormalNumber(value, Convert.ToDouble(sigma, ci),
                                    normalMassive[k]);
                                //// value = Math.Exp(value + Convert.ToDouble(sigma, ci) * normalMassive[k]);
                                //// Console.WriteLine((readText[i + 1].Trim()).Remove(0, 11));
                                readText[i + 1] = "\t\t\t\t " + value.ToString("#.00000E+00", ci) + " " +
                                                  (readText[i + 1].Trim()).Remove(0, 11);
                                ////   Console.WriteLine(readText[i]);
                                k++;
                            }
                            i++;
                        }
                    }
                    File.WriteAllLines(outputPath, readText, Encoding.UTF8);
                }
            }

            #endregion Calc
        }
    }
}
