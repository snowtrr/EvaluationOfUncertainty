namespace LogNormal
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var listMaterial = new List<string>();
            var lnfReactor = new LogNormalForReactor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please, enter number of folder: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            var numberOfFolder = int.Parse(Console.ReadLine());
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please, enter path to cell folder: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            var pathFCell = Console.ReadLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please, enter quantity of material: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            var quanMaterial = Console.ReadLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please, enter sigma: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            var sigma = Console.ReadLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter number of material by a space number of reactions: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;

            var j = 0;
            while (j != Convert.ToInt32(quanMaterial))
            {
                listMaterial.Add(Console.ReadLine());
                j++;
            }
            Console.ResetColor();

            lnfReactor.GenFiles(numberOfFolder, pathFCell, quanMaterial, sigma, listMaterial, 10);
        }
    }
}
