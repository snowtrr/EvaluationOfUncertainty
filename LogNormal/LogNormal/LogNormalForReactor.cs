namespace LogNormal
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LogNormalForReactor
    {
        public bool GenFiles(
            int numberOfFolder,
            string pathFCell,
            string quanMaterial,
            string sigma,
            List<string> listMaterial,
            int multiplyKoeff,
            bool useCustomGenerator = true)
        {
            var ci = new CultureInfo("en-US");

            //// Get items contained .dat
            var dir = new DirectoryInfo(pathFCell);
            var allFileList = dir.GetFiles().Select(file => file.FullName).ToList();
            var cellFList = allFileList.Where(cell => cell.Contains(".dat")).ToList();

            var numberRandom = (from pathCell in cellFList
                from str in File.ReadAllLines(pathCell, Encoding.Default)
                from material in listMaterial
                where str.Contains(" multiplier bin:") && material.Split(' ').All(word => str.Contains(word))
                select str).Count();

            var normal = new Normal();
            var logNormal = new LogNormal();

            List<double> normalMassive;

            // Generate Normal Massive
            normalMassive = useCustomGenerator
                ? normal.GenCustomNormal(numberRandom*numberOfFolder, Environment.TickCount)
                : normal.GenNormal(numberRandom*numberOfFolder);
            
            var k = 0;
            for (var l = 0; l < numberOfFolder; l++)
            {
                Directory.CreateDirectory(Path.Combine(dir.FullName, l.ToString()));

                foreach (var pathCell in cellFList)
                {
                    var file = new FileInfo(pathCell);
                    var outputPath = Path.Combine(dir.FullName, l.ToString(), file.Name);

                    outputPath = outputPath.Remove(outputPath.Length - 4);
                    var readText = File.ReadAllLines(pathCell, Encoding.Default);

                    foreach (var material in listMaterial)
                    {
                        var i = 0;
                        foreach (var str in readText)
                        {
                            if (str.Contains(" multiplier bin:") && material.Split(' ').All(word => str.Contains(word)))
                            {
                                var value = Convert.ToDouble((readText[i + 1].Trim()).Remove(11), ci);
                                value = logNormal.GenLogNormalNumber(value, Convert.ToDouble(sigma, ci),
                                    normalMassive[k], multiplyKoeff);
                                readText[i + 1] = "\t\t\t\t " + value.ToString("#.00000E+00", ci) + " " +
                                                  (readText[i + 1].Trim()).Remove(0, 11);
                                k++;
                            }
                            i++;
                        }
                    }
                    File.WriteAllLines(outputPath + ".dat", readText);
                }
            }

            return true;
        }
    }
}