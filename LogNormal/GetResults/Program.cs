namespace GetResults
{
    using System;
    using System.IO;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var reader = new ReadResults();
            var createGraph = new CreateGraphicData();

            Console.WriteLine("Path to folder wich contains folders with burned materials:");
            var inputPathToGenFolder = Console.ReadLine();

            Console.WriteLine("Number of points on graphic:");
            var numberOfPointInGraph = int.Parse(Console.ReadLine());

            Console.WriteLine("Material's number:");
            var material = Console.ReadLine();

            Console.WriteLine("Result path:");
            var outputResult = Console.ReadLine();

            var allNum = reader.Read(inputPathToGenFolder, material);

            var content = createGraph.Create(allNum, numberOfPointInGraph).ToArray();
            var logNormalGraph = Path.Combine(outputResult, "forCreateGraph.txt");

            File.WriteAllLines(logNormalGraph, content);

            var gestMuSigma = new ResultMuSigma(allNum);
            Console.WriteLine($"Mu = {gestMuSigma.ResultMu}\nSigma = {gestMuSigma.ResultSigma}");
            Console.ReadLine();
        }
    }
}
