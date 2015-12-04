namespace VBO_runner
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var genInp = new GenerateInput();
            var runVboApp = new RunVboApp();

            Console.WriteLine("Enter full path to standart input file:");
            var fullPathInput = Console.ReadLine();

            Console.WriteLine("Enter full path to folder wich contains generated folders with dat files:");
            var fullPathDataFolder = Console.ReadLine();

            Console.WriteLine("Enter number of parallel start process:");
            var processNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("VBO path:");
            var vbo = Console.ReadLine();

            if (genInp.Generate(fullPathInput, fullPathDataFolder))
            runVboApp.Generate(processNumber, genInp, vbo);
        }
    }
}
